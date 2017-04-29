using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketGPS.Model
{
    interface IGPSCoordinateMath
    {
        double toDouble();
        void fromDouble(double degrees);
        double toRadians();
    }
}
