using Bll.Domain.Entities;
using Bll.Domain.Interfaces;
using Bll.Domain.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bll.Domain.Tests.EntitiesTests
{
    [TestFixture]
    public class DeviceManagerTests
    {
        private Mock<ITimeProvider> _time;

        private Mock<IResults> _results;

        private Mock<IFlowProvider> _flow;

        [SetUp]
        public void Setup()
        {
            _time = new Mock<ITimeProvider>();
            _flow = new Mock<IFlowProvider>();
            _results = new Mock<IResults>();
        }

        [Test]
        public void TakeRequest_NormalCondition_RequestOnDevice()
        {
            //Arrange
            var timeOfDeviceWillBeFree = 0.4d;
            var lambda = 50;
            _time.Setup(t => t.Now).Returns(timeOfDeviceWillBeFree);
            double expectedTimeOfDeviceWillBeFree = 0.45d;
            _flow.Setup(f => f.GetInterval(_time.Object.Now, lambda)).Returns(expectedTimeOfDeviceWillBeFree);

            var request = new Request(2, 15, 0.325555d, null);
            var device = new Device()
            {
                DeviceId = 4,
                IsWorking = false,
                Lambda = lambda,
                Request = null,
                TimeOfDeviceWillBeFree = timeOfDeviceWillBeFree,
            };

            var deviceManager = new DeviceManager(_time.Object, _flow.Object, _results.Object);

            //Act
            deviceManager.TakeRequest(request, device);

            //Assert
            Assert.NotNull(device.Request);
            Assert.AreEqual(device.Request, request);
            Assert.AreEqual(device.IsWorking, true);
            Assert.That(device.TimeOfDeviceWillBeFree, Is.EqualTo(expectedTimeOfDeviceWillBeFree).Within(0.000001));
        }

        [Test]
        public void FreeDevice_NormalCondition_DeviceIsFree()
        {
            //Arrange
            double timeOfDeviceWillBeFree = 0.52045;

            var requestOnDevice = new Request(4, 23, 0.45667, null);

            var device = new Device()
            {
                DeviceId = 7,
                IsWorking = true,
                Lambda = 99,
                Request = requestOnDevice,
                TimeOfDeviceWillBeFree = timeOfDeviceWillBeFree,
            };
            _results.Setup(r => r.Processed).Returns(new List<Request>());
            _time.SetupAllProperties();

            var deviceManager = new DeviceManager(_time.Object, _flow.Object, _results.Object);
            //Act
            deviceManager.FreeDevice(device);
            //Assert
            Assert.AreEqual(device.IsWorking, false);
            Assert.AreEqual(_time.Object.Now, device.TimeOfDeviceWillBeFree);
            Assert.AreEqual(_results.Object.Processed.Last().EndTime, _time.Object.Now);
            Assert.AreEqual(_results.Object.Processed.Count, 1);
        }

        [Test]
        public void FreeDevice_RequestOnDeviceIsNull_ThrowArgumentNullException()
        {
            //Arrange
            Request? requestOnDevice = null;

            var device = new Device()
            {
                DeviceId = 7,
                IsWorking = true,
                Lambda = 99,
                Request = requestOnDevice,
                TimeOfDeviceWillBeFree = 0.4d,
            };

            var deviceManager = new DeviceManager(_time.Object, _flow.Object, _results.Object);
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => deviceManager.FreeDevice(device));
        }
    }
}