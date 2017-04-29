using RocketGPS.Model;
using RocketGPSMath.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketGPSMath.GPSMath
{
    public class FireValidator
    {
        public static double validationCheckRadiusKM = 0.5;
        public static double validationAccuracy = 3;
        public List<GPSCoordinateBearing> allUserReportedFire;

        public bool IsUserReportedFireValid(GPSCoordinateBearing userReportedFire)
        {
            if (userReportedFire == null || userReportedFire == null)
                return false;

            int counter = 0;

            foreach (var uf in allUserReportedFire)
            {
                if (uf == userReportedFire)
                    continue;

                if (userReportedFire.DistanceTo(uf) < validationCheckRadiusKM)
                    counter++;

                if (counter > validationAccuracy)
                    return true;
            }

            return false;
        }

        public List<GPSCoordinateBearing> FilterUserReportedFire()
        {
            List<GPSCoordinateBearing> validated = new List<GPSCoordinateBearing>();

            foreach (var r in allUserReportedFire)
            {
                if(IsUserReportedFireValid(r))
                    validated.Add(r);
            }

            return validated;
        }

    }
}
