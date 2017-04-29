using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RocketGPS.Model;
using KMLModule.Parser;

namespace KMLModuleTests
{
    [TestClass]
    public class KMLParserTest
    {
        [TestMethod]
        public void TestReadKml()
        {
            var parser = KMLParser.Get();

            string path = "TestData\\MODISFire\\MODIS_C6_USA_contiguous_and_Hawaii_24h.kml";

            List<KMLSatelliteFireData> modisDatas;
            bool success = parser.ReadByFile(path, out modisDatas);

            Assert.IsTrue(success);
            Assert.IsTrue(modisDatas.Count == 904);

            path = "TestData\\VIIRSFire\\VNP14IMGTDL_NRT_USA_contiguous_and_Hawaii_24h.kml";

            List<KMLSatelliteFireData> viirsDatas;
            success = parser.ReadByFile(path, out viirsDatas);

            Assert.IsTrue(success);
            Assert.IsTrue(viirsDatas.Count == 3743);

            List<KMLSatelliteFireData> dummyDatas;
            success = parser.ReadByFile("", out dummyDatas);
            Assert.IsFalse(success);
        }
    }
}
