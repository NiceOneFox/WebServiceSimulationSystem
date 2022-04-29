﻿using Bll.Domain.Models;
using Bll.Domain.Factories;
using Bll.Domain.Interfaces;

namespace Bll.Domain.Services;

public class SimulationService : ISimulationService
{
    private readonly ISourceManager _sourceManager;
    private readonly IDeviceManager _deviceManager;
    private readonly IBufferManagerFactory _bufferManagerFactory;
    private readonly IResults _results;
    private readonly ITimeProvider _time;
    public SimulationService(ISourceManager sourceManager, 
        IDeviceManager deviceManager, 
        IBufferManagerFactory bufferManagerFactory, 
        IResults results, 
        ITimeProvider time)
    {
        _sourceManager = sourceManager;
        _deviceManager = deviceManager;
        _bufferManagerFactory = bufferManagerFactory;
        _results = results;
        _time = time;
    }

    public void StartSimulation(InputParameters parameters)
    {
        #region initialize
        var sources = new List<Source>(parameters.NumberOfSources);
        var devices = new List<Device>(parameters.NumberOfDevices);

        for (int i = 0; i < parameters.NumberOfSources; i++)
        {
            sources.Add(new Source()
            {
                SourceId = i,
                SerialNumber = 0,
                Lambda = parameters.LambdaForRequests,
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
                Lambda = parameters.LambdaForDevice,
                Request = null,
                TimeOfDeviceWillBeFree = 0,
            });
        }

        var bufferManager = _bufferManagerFactory.CreateBufferManager(parameters.SimulationType, parameters.BufferSize);
        
        foreach (var source in sources) // Generate first requests that generated by sources.
        {
            _sourceManager.GetNewRequest(source);
        }
        #endregion

        while (true)
        {
            if (_results.AmountOfGeneratedRequests >= parameters.AmountOfRequests &&
                bufferManager.IsFree() &&
                IsAllDevicesFree(devices) || 
                _time.Now >= parameters.ModelingTime)
               // _results.AmountOfServedRequest == parameters.AmountOfRequests) // TODO CHECK FOR REQUESTS ON SOURCES. WHEN TO END SYSTEM MODELING
            {
                break;
            }
            FindNextSpecialEvent(devices, sources, bufferManager, parameters);
        }
    }

    private void FindNextSpecialEvent(List<Device> devices, List<Source> sources, IBufferManager bufferManager, InputParameters parameters)
    {
        double timeOfClosestRequestCome = double.MaxValue;
        double timeOfClosestDeviceFree = double.MaxValue;

        int indexOfRequestWithClosestTimeCome = -1;
        for (int i = 0; i < sources.Count; i++)
        {
           // if (_results.AmountOfGeneratedRequests >= parameters.AmountOfRequests) break;
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

        if (timeOfClosestDeviceFree < timeOfClosestRequestCome 
            || _results.AmountOfGeneratedRequests == parameters.AmountOfRequests)
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
            //if (_results.AmountOfGeneratedRequests >= parameters.AmountOfRequests) return;

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

    public bool IsAllDevicesFree(List<Device> devices)
    {
        foreach (var device in devices)
        {
            if (device.IsWorking)
            {
                return false;
            }
        }
        return true;
    }
}