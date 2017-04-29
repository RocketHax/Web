using EarthFire.Facade.Models;
using RocketFireWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RocketFireWeb.Converters
{
  public class NasaFireDataModelConverter : INasaFireDataModelConverter
  {
    public NasaFireDataModel FromFadaceData(NasaFireData data)
    {
      return new NasaFireDataModel
      {
        Coordinate = new GeoLocationModel { Latitude = data.Coordinate.Latitude, Longitude = data.Coordinate.Longitude },
        Date = data.Date,
        Description = data.Description,
        FireConfidence = data.FireConfidence,
        Name = data.Name,
        SatelliteSource = data.SatelliteSource
      };
    }

    public IEnumerable<NasaFireDataModel> FromFadaceData(IEnumerable<NasaFireData> model) => model.Select(FromFadaceData);
  }
}