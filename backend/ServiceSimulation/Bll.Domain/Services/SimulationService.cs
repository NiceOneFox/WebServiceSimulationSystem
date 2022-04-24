﻿using Api.enums;
using Bll.Domain.Entities;
using Bll.Domain.Factories;
using Bll.Domain.Interfaces;

namespace Bll.Domain.Services;

public class SimulationService : ISimulationService
{
    private readonly ISourceManager _sourceManager;
    private readonly IDeviceManager _deviceManager;
    private readonly IBufferManagerFactory _bufferManagerFactory;
    private readonly IResults _results;

    public SimulationService(ISourceManager sourceManager, IDeviceManager deviceManager, IBufferManagerFactory bufferManagerFactory, IResults results)
    {
        _sourceManager = sourceManager;
        _deviceManager = deviceManager;
        _bufferManagerFactory = bufferManagerFactory;
        _results = results;
    }

    public void StartSimulation(InputParameters parameters)
    {
        List<Source> sources = new List<Source>(parameters.NumberOfSources);
        List<Device> devices = new List<Device>(parameters.NumberOfDevices);

        for (int i = 0; i < parameters.NumberOfSources; i++)
        {
            sources.Add(new Source()
            {
                SourceId = i,
                SerialNumber = 0,
                Lambda = parameters.Lambda,
                Priority = 1,
                TimeOfNextRequest = 0,
            });
        }

        for (int i = 0; i < parameters.NumberOfDevices; i++)
        {
            devices.Add(new Device()
            {
                DeviceId = i,
                IsWorking = false,
                Lambda = parameters.Lambda,
                Request = null,
                TimeOfDeviceWillBeFree = 0,
            });
        }

        var bufferManager = _bufferManagerFactory.CreateBufferManager(parameters.SimulationType);

        foreach (var source in sources) // Generate first requests that generated by sources.
        {
            _sourceManager.GetNewRequest(source);
        }

        while (true)
        {
            if (_results.AmountOfGeneratedRequests >= parameters.AmountOfRequests &&
                bufferManager.IsFree() &&
                IsAllDevicesFree(devices))
            {
                break;
            }
            FindNextSpecialEvent(devices, sources, bufferManager, parameters);
        }


        //while (_results.AmountOfServedRequest >= parameters.AmountOfRequests &&
        //       !bufferManager.IsFree() &&
        //       !IsAllDevicesFree(devices))
        //{
        //    // TODO CHECK FOR NEXT SPECIAL EVENT
        //    double timeOfClosestRequestCome = double.MaxValue;
        //    double timeOfClosestDeviceFree = double.MaxValue;

        //    // Check requests
        //    int indexOfRequestWithClosestTimeCome = -1;
        //    for (int i = 0; i < sources.Count; i++)
        //    {
        //        if (sources[i].TimeOfNextRequest < timeOfClosestRequestCome)
        //        {
        //            timeOfClosestRequestCome = sources[i].TimeOfNextRequest;
        //            indexOfRequestWithClosestTimeCome = i;
        //        }
        //    }

        //    int indexOfDeviceWithClosestTimeFree = -1;
        //    for (int i = 0; i < devices.Count; i++)
        //    {
        //        if (devices[i].TimeOfDeviceWillBeFree < indexOfDeviceWithClosestTimeFree)
        //        {
        //            timeOfClosestDeviceFree = devices[i].TimeOfDeviceWillBeFree;
        //            indexOfDeviceWithClosestTimeFree = i;
        //        }
        //    }

        //    if (timeOfClosestDeviceFree < timeOfClosestRequestCome)
        //    {
        //        _deviceManager.FreeDevice(devices[indexOfDeviceWithClosestTimeFree]);

        //        // Take from buffer and put on device.
        //        _deviceManager.TakeRequest(bufferManager.Get(), devices[indexOfDeviceWithClosestTimeFree]);
        //    }
        //    else
        //    {
        //        // Take request on work or add to buffer.
        //        var newRequestInSystem = _sourceManager.GetNewRequest(sources[indexOfRequestWithClosestTimeCome]);
        //        // find out free device
        //        bool wasFreeDevice = false;
        //        foreach (var device in devices)
        //        {
        //            if (!device.IsWorking)
        //            {
        //                _deviceManager.TakeRequest(newRequestInSystem, device);
        //                wasFreeDevice = true;
        //            }
        //        }

        //        if (!wasFreeDevice)
        //        {
        //            // Add request to buffer if no free devices were found
        //            bufferManager.Add(newRequestInSystem);
        //        }
        //    }
        //}
    }

    private void FindNextSpecialEvent(List<Device> devices, List<Source> sources, IBufferManager bufferManager, InputParameters parameters)
    {
        double timeOfClosestRequestCome = double.MaxValue;
        double timeOfClosestDeviceFree = double.MaxValue;

        int indexOfRequestWithClosestTimeCome = -1;
        for (int i = 0; i < sources.Count; i++)
        {
            if (_results.AmountOfGeneratedRequests >= parameters.AmountOfRequests) break;
            if (sources[i].TimeOfNextRequest < timeOfClosestRequestCome)
            {
                timeOfClosestRequestCome = sources[i].TimeOfNextRequest;
                indexOfRequestWithClosestTimeCome = i;
            }
        }

        int indexOfDeviceWithClosestTimeFree = -1;
        for (int i = 0; i < devices.Count; i++)
        {
            if (devices[i].IsWorking && devices[i].TimeOfDeviceWillBeFree < timeOfClosestDeviceFree)
            {
                timeOfClosestDeviceFree = devices[i].TimeOfDeviceWillBeFree;
                indexOfDeviceWithClosestTimeFree = i;
            }
        }

        if (timeOfClosestDeviceFree < timeOfClosestRequestCome)
        {
            _deviceManager.FreeDevice(devices[indexOfDeviceWithClosestTimeFree]);

            // Take from buffer and put on device.
            if (!bufferManager.IsFree())
            {
                _deviceManager.TakeRequest(bufferManager.Get(), devices[indexOfDeviceWithClosestTimeFree]);
            }
        }
        else
        {
            // Take request on work or add to buffer.
            if (_results.AmountOfGeneratedRequests >= parameters.AmountOfRequests) return;

            var newRequestInSystem = _sourceManager.GetNewRequest(sources[indexOfRequestWithClosestTimeCome]);
            // find out free device
            bool wasFreeDevice = false;
            foreach (var device in devices)
            {
                if (!device.IsWorking)
                {
                    _deviceManager.TakeRequest(newRequestInSystem, device);
                    wasFreeDevice = true;
                    break;
                }
            }

            if (!wasFreeDevice)
            {
                // Add request to buffer if no free devices were found
                bufferManager.Add(newRequestInSystem);
            }
        }

    }

    public bool IsAllDevicesFree(List<Device> devices) =>
        devices.Any(d => d.IsWorking);

}