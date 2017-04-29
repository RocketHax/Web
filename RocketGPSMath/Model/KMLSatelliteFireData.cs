
using RocketGPS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketGPS.Model
{
    public class KMLSatelliteFireData
    {
        public string name;
        public GPSCoordinate coordinate;
        public string Description;
        public DateTime date; //time in UTC
        public int fireConfidence; 
        public string satelliteSource;
    }
}
