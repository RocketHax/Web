using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocketGPS.GPSMath;
using RocketGPS.Model;
using RocketGPSMath.Model;

namespace GPSTriangulatorTests
{
    [TestClass]
    public class GPSMathTest
    {
        const double dEpsilon = 0.00000001; // 10e-8 precision

        /////////////////////////////////////////////////////////////////////////
        //Auxiliary Method///////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////

        private bool DoubleEqual(double a, double b)
        {
            return Math.Abs(a - b) < dEpsilon;
        }

        /////////////////////////////////////////////////////////////////////////
        //Conversion Tests///////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void TestGPSDegreeToDD()
        {
            //#1
            double actual = GPSMathProcessor.Get().GPSDegreeToDecimal(new GPSDegree(52, 9, 28.83));
            double expected = 52.15800833;

            Assert.IsTrue(DoubleEqual(actual, expected));

            //#2
            actual = GPSMathProcessor.Get().GPSDegreeToDecimal(new GPSDegree(5, 23, 23.85));
            expected = 5.38995833;

            Assert.IsTrue(DoubleEqual(actual, expected));

            //#3
            actual = GPSMathProcessor.Get().GPSDegreeToDecimal(5, 23, 23.85);

            Assert.IsTrue(DoubleEqual(actual, expected));
        }

        [TestMethod]
        public void TestDDToGPSDegree()
        {
            //#1
            GPSDegree actual = GPSMathProcessor.Get().DecimalToGPSDegree(52.15800833);
            GPSDegree expected = new GPSDegree(52,9, 28.8300);

            Assert.IsTrue(actual == expected);

            //#2
            actual = GPSMathProcessor.Get().DecimalToGPSDegree(5.38995833);
            expected = new GPSDegree(5, 23, 23.8500);

            Assert.IsTrue(actual == expected);
        }

        /////////////////////////////////////////////////////////////////////////
        //Distance Tests/////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void TestDistanceCalculation()
        {
            GPSCoordinate f = new GPSCoordinate(new GPSDegree(50, 3, 59), new GPSDegree(5, 42, 53));
            GPSCoordinate t = new GPSCoordinate(new GPSDegree(58, 38, 38), new GPSDegree(3, 04, 12));

            double actual = GPSMathProcessor.Get().CalculateDistance(f, t);
            double expected = 968.9;

            Assert.IsTrue(DoubleEqual(expected, actual));
        }

        [TestMethod]
        public void TestTotalDistanceCalculation()
        {
            GPSCoordinate f = new GPSCoordinate(new GPSDegree(50, 3, 59), new GPSDegree(5, 42, 53));
            GPSCoordinate t = new GPSCoordinate(new GPSDegree(58, 38, 38), new GPSDegree(3, 04, 12));

            double actual = GPSMathProcessor.Get().CalculateDistance(f, t, f);
            double expected = 968.9 * 2;

            Assert.IsTrue(DoubleEqual(expected, actual));
        }

        /////////////////////////////////////////////////////////////////////////
        //Midpoint Tests/////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void TestMidPointCalculation()
        {
            GPSCoordinate f = new GPSCoordinate(new GPSDegree(50, 3, 59), new GPSDegree(5, 42, 53));
            GPSCoordinate t = new GPSCoordinate(new GPSDegree(58, 38, 38), new GPSDegree(3, 04, 12));

            GPSCoordinate actual = GPSMathProcessor.Get().CalculateMiddle(f, t);
            GPSCoordinate expected = new GPSCoordinate(new GPSDegree(54, 21, 44), new GPSDegree(4, 31, 50));

            actual.latitude.seconds = Math.Truncate(actual.latitude.seconds);
            actual.longitude.seconds = Math.Truncate(actual.longitude.seconds);

            Assert.IsTrue(actual == expected);
        }

        /////////////////////////////////////////////////////////////////////////
        //Intersection Test//////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void TestIntersectionPoint()
        {
            GPSCoordinate location1 = new GPSCoordinate(51.8853, 0.2545);
            GPSDegree bearing1 = new GPSDegree(108.547);
            GPSCoordinateBearing report1 = new GPSCoordinateBearing(location1, bearing1);

            GPSCoordinate location2 = new GPSCoordinate(49.0034, 2.5735);
            GPSDegree bearing2 = new GPSDegree(32.435);
            GPSCoordinateBearing report2 = new GPSCoordinateBearing(location2, bearing2);

            GPSCoordinate actual = GPSMathProcessor.Get().CalculateIntersection(report1, report2);
            GPSCoordinate expected = new GPSCoordinate(new GPSDegree(50.9078), new GPSDegree(4.5084));

            Assert.IsTrue(actual == expected);
        }

    }
}