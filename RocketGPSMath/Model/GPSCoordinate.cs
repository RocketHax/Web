using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketGPS.Model
{
    public class GPSCoordinate
    {
        public GPSDegree latitude;
        public GPSDegree longitude;

        public GPSCoordinate()
        {
            latitude = new GPSDegree();
            longitude = new GPSDegree();
        }

        public GPSCoordinate(GPSDegree latitude, GPSDegree longitute)
        {
            this.latitude = latitude;
            this.longitude = longitute;
        }

        public GPSCoordinate(double latitude, double longitute)
        {
            this.latitude = new GPSDegree(latitude);
            this.longitude = new GPSDegree(longitute);
        }

        //in KM
        public double DistanceTo(GPSCoordinate other)
        {
            return GPSMath.GPSMathProcessor.Get().CalculateDistance(this, other);
        }

        public new string ToString()
        {
            var s = latitude.degrees;
            string lat = "Latitute : " + latitude.degrees.ToString() + " " + latitude.minutes.ToString() + " " + latitude.seconds.ToString();
            string lgt = "Longitude : " + longitude.degrees.ToString() + " " + longitude.minutes.ToString() + " " + longitude.seconds.ToString();
            return lat + " " + lgt;
        }

        public static bool operator ==(GPSCoordinate instance, GPSCoordinate other)
        {
            return ((instance.latitude == other.latitude) && (instance.longitude == other.longitude));

        }

        public static bool operator !=(GPSCoordinate instance, GPSCoordinate other)
        {
            return instance == other;
        }

        //[AH] Not changing this until it makes sense
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
