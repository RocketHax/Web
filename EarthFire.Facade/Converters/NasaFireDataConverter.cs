using EarthFire.Facade.Models;
using RocketGPS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthFire.Facade.Converters
{
  public class NasaFireDataConverter
  {
    GeoLocationConverter _geoConverter;
    public NasaFireDataConverter(GeoLocationConverter geoConverter)
    {
      _geoConverter = geoConverter;
    }

    public NasaFireData FromKMLSatelliteFireData(KMLSatelliteFireData data)
    {
      return new NasaFireData
      {
        Coordinate = _geoConverter.FromGPSCoordinate(data.coordinate),
        Date = data.date,
        Description = data.Description,
        FireConfidence = data.fireConfidence,
        Name = data.name,
        SatelliteSource = data.satelliteSource
      };
    }

    public IEnumerable<NasaFireData> FromKMLSatelliteFireData(IEnumerable<KMLSatelliteFireData> data) => data.Select(FromKMLSatelliteFireData);
  }
}
