using EarthFire.Model.Entities;
using RocketGPSMath.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthFire.Facade.Converters
{
  public class FireLocationReportConverter
  {
    public GPSCoordinateBearing ToGPSCoordinate(FireLocationReport location)
    {
      return new GPSCoordinateBearing(location.Latitude, location.Longitude, location.Bearing);
    }

    public IEnumerable<GPSCoordinateBearing> ToGPSCoordinates(IEnumerable<FireLocationReport> location)
    {
      return location.Select(ToGPSCoordinate);
    }
  }
}
