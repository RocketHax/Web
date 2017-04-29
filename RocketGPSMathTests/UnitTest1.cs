using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocketGPSMath.GPSMath;
using System.Collections.Generic;
using RocketGPSMath.Model;

namespace GPSTriangulatorTests
{
    [TestClass]
    public class RegionTriangulatorTests
    {
        [TestMethod]
        public void TestTriangulateRegion()
        {
            List<GPSCoordinateBearing> reports = new List<GPSCoordinateBearing>();

            RegionTriangulator triangulator = new RegionTriangulator(reports);

            Assert.IsNull(triangulator.Triangulate());

            reports.Add(new GPSCoordinateBearing(52.00000, 5.00000, 90));
            reports.Add(new GPSCoordinateBearing(51.00000, 7.00000, 0));
            reports.Add(new GPSCoordinateBearing(51.44374, 5.98755, 90));
            reports.Add(new GPSCoordinateBearing(51.08972, 6.4270, 0));

            var res = triangulator.Triangulate();

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Count == 6);
        }
    }
}
