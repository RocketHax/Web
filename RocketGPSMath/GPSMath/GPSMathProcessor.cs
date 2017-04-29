using RocketGPS.Model;
using RocketGPSMath.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RocketGPS.GPSMath
{
    public class GPSMathProcessor
    {
        //Constants
        const int DistancePrecision = 1;
        const double EarthRadius = 6371e3; // Earth radius = 6,371km

        //Core Instance for lazy bum
        static GPSMathProcessor Processor = new GPSMathProcessor();

        //For lazy bum
        public static GPSMathProcessor Get()
        {
            return Processor;
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        //Basic Calculations//////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////

        public double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        public double RadiansToDegree(double radians)
        {
            return radians * (180.0 / Math.PI);
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        //Distance in KM, using Haversine formula/////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////

        public double CalculateDistance(GPSCoordinate from, GPSCoordinate to)
        {
            var lat1Rad = from.latitude.toRadians();
            var lat2Rad = to.latitude.toRadians();
            var dlat1lat2 = to.latitude.toRadians() - from.latitude.toRadians();
            var dlong1long2 = to.longitude.toRadians() - from.longitude.toRadians();

            var a = Math.Sin(dlat1lat2 / 2) * Math.Sin(dlat1lat2 / 2) +
                    Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                    Math.Sin(dlong1long2 / 2) * Math.Sin(dlong1long2 / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            //Set to one decimal places
            return Math.Round((EarthRadius * c) / 1000, DistancePrecision);
        }

        //Calculate total distance
        public double CalculateDistance(params GPSCoordinate[] coordinates)
        {
            double totalDistance = 0.0;

            for (int i = 0; i < coordinates.Length - 1; i++)
            {
                GPSCoordinate current = coordinates[i];
                GPSCoordinate next = coordinates[i + 1];

                totalDistance += CalculateDistance(current, next);
            }

            return totalDistance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        //Mid Point calculation///////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////

        public GPSCoordinate CalculateMiddle(GPSCoordinate from, GPSCoordinate to)
        {
            double lat1Rad = from.latitude.toRadians();
            double lat2Rad = to.latitude.toRadians();
            double long1Rad = from.longitude.toRadians();
            double long2Rad = to.longitude.toRadians();

            double Bx = Math.Cos(lat2Rad) * Math.Cos(long2Rad - long1Rad);
            double By = Math.Cos(lat2Rad) * Math.Sin(long2Rad - long1Rad);
            double latM = Math.Atan2(Math.Sin(lat1Rad) + Math.Sin(lat2Rad),
                                Math.Sqrt((Math.Cos(lat1Rad) + Bx) * (Math.Cos(lat1Rad) + Bx) + By * By));
            double longM = long1Rad + Math.Atan2(By, Math.Cos(lat1Rad) + Bx);

            var a = RadiansToDegree(latM);
            var b = RadiansToDegree(longM);

            return new GPSCoordinate(new GPSDegree(RadiansToDegree(latM)), new GPSDegree(RadiansToDegree(longM)));
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        //DMS to DD///////////////////////////////////////////////////////////////////////////////
        //DMS(127o 30' 00") = 127 + (30/60) + (0/3600) = DEC(127.5)///////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////

        public double GPSDegreeToDecimal(int d, int m, double s)
        {
            return GPSDegreeToDecimal(new GPSDegree(d, m, s));
        }

        public double GPSDegreeToDecimal(GPSDegree source)
        {
            double d = source.degrees;
            double m = source.minutes;
            double s = source.seconds;

            return (d + (m / 60) + (s / 3600)) * (d < 0 ? -1 : 1);
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        //DD to DMS///////////////////////////////////////////////////////////////////////////////
        //DEC(127.5) = D(floor(127.5))o M(floor(fraction of deg*60))' S(fraction of min*60)"//////
        //////////////////////////////////////////////////////////////////////////////////////////

        public GPSDegree DecimalToGPSDegree(double source)
        {
            //decimal degrees
            double decdeg = source;
            double minsec = (decdeg - Math.Truncate(decdeg)) * 60;
            double sec = (minsec - Math.Truncate(minsec)) * 60;

            return new GPSDegree((int)Math.Truncate(decdeg), (int)Math.Truncate(minsec), sec);
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        //Point Translation///////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////

        //#1
        //Dim Distance, Bearing As Double
        //Dim Radius As Double = 6372.795477598
        //
        //
        //Distance = Distance / Radius
        //LatB = ASinD(SinD(LatA) * Cos(Distance) + CosD(LatA) * Sin(Distance) * CosD(Bearing))
        //LonB = LonA + ATan2D(SinD(Bearing) * Sin(Distance) * CosD(LatA), Cos(Distance) - SinD(LatA) * SinD(LatB))

        //#2
        //Dim Distance, Bearing As Double
        //Dim Radius As Double = 6372.795477598
        //'
        //'
        //Distance = (Distance / Radius)
        //LatB = ASinD(SinD(LatA) * Cos(Distance/Radius) + CosD(LatA) * Sin(Distance/Radius) * CosD(Bearing))
        //LonB = LonA + ATan2D(SinD(Bearing) * Sin(Distance / Radius) * CosD(LatA), Cos(Distance / Radius) - SinD(LatA) * SinD(LatB))

        //////////////////////////////////////////////////////////////////////////////////////////
        //Bearing Intersection////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////

        public GPSCoordinate CalculateIntersection(GPSCoordinateBearing p1, GPSCoordinateBearing p2)
        {
            //φ is latitude, λ is longitude, R is earth’s radius (mean radius = 6, 371km);
            //note that angles need to be in radians to pass to trig functions!

            //φ1, λ1, θ13: 1st start point & (initial)bearing from 1st point towards intersection point
            //φ2, λ2, θ23 : 2nd start point & (initial)bearing from 2nd point towards intersection point
            //φ3, λ3 : intersection point

            var φ1 = p1.latitude.toRadians();
            var λ1 = p1.longitude.toRadians();
            var φ2 = p2.latitude.toRadians();
            var λ2 = p2.longitude.toRadians();
            var θ13 = p1.bearing.toRadians();
            var θ23 = p2.bearing.toRadians();
            var Δφ = φ2 - φ1;
            var Δλ = λ2 - λ1;

            var δ12 = 2 * Math.Asin(Math.Sqrt(Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) + Math.Cos(φ1) * Math.Cos(φ2) * Math.Sin(Δλ / 2) * Math.Sin(Δλ / 2)));

            if (δ12 == 0)
                return null;

            double θa;
            if (!Double.IsNaN(Math.Acos((Math.Sin(φ2) - Math.Sin(φ1) * Math.Cos(δ12)) / (Math.Sin(δ12) * Math.Cos(φ1)))))
                θa = Math.Acos((Math.Sin(φ2) - Math.Sin(φ1) * Math.Cos(δ12)) / (Math.Sin(δ12) * Math.Cos(φ1)));
            else
                θa = 0;

            var θb = Math.Acos((Math.Sin(φ1) - Math.Sin(φ2) * Math.Cos(δ12)) / (Math.Sin(δ12) * Math.Cos(φ2)));
            var θ12 = Math.Sin(λ2 - λ1) > 0 ? θa : 2 * Math.PI - θa;
            var θ21 = Math.Sin(λ2 - λ1) > 0 ? 2 * Math.PI - θb : θb;
            var α1 = (θ13 - θ12 + Math.PI) % (2 * Math.PI) - Math.PI; // angle 2-1-3
            var α2 = (θ21 - θ23 + Math.PI) % (2 * Math.PI) - Math.PI; // angle 1-2-3

            if (Math.Sin(α1) == 0 && Math.Sin(α2) == 0)
                return null; // infinite intersections

            if (Math.Sin(α1) * Math.Sin(α2) < 0)
                return null;

            var α3 = Math.Acos(-Math.Cos(α1) * Math.Cos(α2) + Math.Sin(α1) * Math.Sin(α2) * Math.Cos(δ12));
            var δ13 = Math.Atan2(Math.Sin(δ12) * Math.Sin(α1) * Math.Sin(α2), Math.Cos(α2) + Math.Cos(α1) * Math.Cos(α3));
            var φ3 = Math.Asin(Math.Sin(φ1) * Math.Cos(δ13) + Math.Cos(φ1) * Math.Sin(δ13) * Math.Cos(θ13));
            var Δλ13 = Math.Atan2(Math.Sin(θ13) * Math.Sin(δ13) * Math.Cos(φ1), Math.Cos(δ13) - Math.Sin(φ1) * Math.Sin(φ3));
            var λ3 = λ1 + Δλ13;

            var rLat = GPSMathProcessor.Get().RadiansToDegree(φ3);
            var rLong = (GPSMathProcessor.Get().RadiansToDegree(λ3) + 540) % 360 - 180;

            return new GPSCoordinate(new GPSDegree(rLat), new GPSDegree(rLong));
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        //GPS Coordinate within radius of GPS Coordinate//////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////

        public bool GPSPointWithinRadius(GPSCoordinate p1, GPSCoordinate p2, double radiusKM)
        {
            return p1.DistanceTo(p2) < radiusKM;
        }
    }
}