using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoadStatus.Entities;
using RoadStatus.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadStatus.Tests
{
    [TestClass]
    public class ServiceTester
    {
        Service service;

        [TestInitialize]
        public void SetUp()
        {
            service = new Service();
        }


        [TestMethod]
        public void ValidRoadCall()
        {

            Task<RoadCorridor> result = service.GetRoadStatus("a1");
            Assert.IsFalse(result.IsFaulted);


        }

        [TestMethod]
        public void InvalidValidRoadCall()
        {
            Task<RoadCorridor> result = service.GetRoadStatus("mmm");
            Assert.IsTrue(result.IsFaulted);
        }


        [TestCleanup]
        public void Clean()
        {
            service = null;
        }

    }
}
