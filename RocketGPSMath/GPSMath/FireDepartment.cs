using RocketGPS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//HACKING BEGINS
namespace RocketGPSMath.GPSMath
{
    public class FireDepartment
    {
        //Statics
        private static FireDepartment headquarter = new FireDepartment();
        public static FireDepartment Get()
        {
            return headquarter;
        }

        //For Reference 
        //public static double DangerousMinSafeDistanceKM = 0.12;
        //public static double SafestMinDistanceKM = 0.5;
        public static double MinSafeDistanceKM = 0.37;

        public List<GPSCoordinate> fireNodes = new List<GPSCoordinate>();

        //Filter dangerous road
        public List<List<GPSCoordinate>> RemoveDangerousRoad(List<List<GPSCoordinate>> roads)
        {
            List<List<GPSCoordinate>> result = new List<List<GPSCoordinate>>();

            foreach (var r in roads)
            {
                if (IsSafeRoad(r))
                    result.Add(r);
            }

            return result;
        }

        //Road Safety check
        public bool IsSafeRoad(List<GPSCoordinate> roadNode)
        {
            foreach(var rn in roadNode)
            {
                foreach(var fn in fireNodes)
                {
                    if (rn.DistanceTo(fn) < MinSafeDistanceKM)
                        return false;
                }
            }

            return true;
        }


    }
}
