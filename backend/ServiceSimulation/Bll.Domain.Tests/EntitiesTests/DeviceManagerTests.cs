using System;
using Bll.Domain.Interfaces;
using Bll.Domain.Entities;
using Moq;
using NUnit.Framework;
using Bll.Domain.Models;

namespace Bll.Domain.Tests.EntitiesTests
{
    [TestFixture]
    public class DeviceManagerTests
    {
        private Mock<ITimeProvider> _time;

        private Mock<IResults> _resultChannel;

        private Mock<IFlowProvider> _flow;

        [SetUp]
        public void Setup()
        {
            _time = new Mock<ITimeProvider>();
            _flow = new Mock<IFlowProvider>();
            _resultChannel = new Mock<IResults>();
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

            var request = new Request(2, 15, 0.325555d, 0.0d);
            var device = new Device()
            {
                DeviceId = 4,
                IsWorking = false,
                Lambda = lambda,
                Request = null,
                TimeOfDeviceWillBeFree = timeOfDeviceWillBeFree,
            };

            var deviceManager = new DeviceManager(_time.Object, _flow.Object, _resultChannel.Object);

            //Act
            deviceManager.TakeRequest(request, device);

            //Assert
            Assert.NotNull(device.Request);
            Assert.AreEqual(device.Request, request);
            Assert.AreEqual(device.IsWorking, true);
            Assert.AreEqual(device.TimeOfDeviceWillBeFree, expectedTimeOfDeviceWillBeFree);
        }
    }
}