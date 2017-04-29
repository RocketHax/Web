using RocketGPS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketGPSMath.Model
{
    public class GPSCoordinateBearing : GPSCoordinate
    {
        public GPSDegree bearing;

        public GPSCoordinateBearing()
        {
            bearing = new GPSDegree();
        }

        public GPSCoordinateBearing(GPSCoordinate location, GPSDegree bearing)   
        {
            this.latitude = location.latitude;
            this.longitude = location.longitude;
            this.bearing = bearing;
        }

        public GPSCoordinateBearing(double latitude, double longitude, double bearing)
        {
            this.latitude = new GPSDegree(latitude);
            this.longitude = new GPSDegree(longitude);
            this.bearing = new GPSDegree(bearing);
        }

        public static bool operator ==(GPSCoordinateBearing instance, GPSCoordinateBearing other)
        {
            return (instance.bearing == other.bearing && instance.latitude == other.latitude && instance.longitude == other.longitude);
        }

        public static bool operator !=(GPSCoordinateBearing instance, GPSCoordinateBearing other)
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
