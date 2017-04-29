using EarthFire.Facade.Models;
using RocketGPS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthFire.Facade.Converters
{
  public class GeoLocationConverter
  {
    public GeoLocation FromGPSCoordinate(GPSCoordinate gpsCoordinate)
    {
      return new GeoLocation
      {
        Latitude = gpsCoordinate.latitude.toDouble(),
        Longitude = gpsCoordinate.longitude.toDouble()
      };
    }

    public IEnumerable<GeoLocation> FromGPSCoordinates(IEnumerable<GPSCoordinate> gpsCoordinates) => gpsCoordinates.Select(FromGPSCoordinate);
  }
}
