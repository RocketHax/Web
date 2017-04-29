using EarthFire.Facade.Models;
using RocketFireWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RocketFireWeb.Converters
{
  public class GeoLocationModelConverter : IGeoLocationModelConverter
  {
    public GeoLocationModel FromGeoLocation(GeoLocation model)
    {
      return new AddFireLocationModel
      {
        Latitude = model.Latitude,
        Longitude = model.Longitude
      };
    }

    public GeoLocation ToGeoLocation(GeoLocationModel model)
    {
      return new GeoLocation
      {
        Latitude = model.Latitude,
        Longitude = model.Longitude
      };
    }

    public IList<GeoLocationModel> FromGeoLocation(IList<GeoLocation> model) => model.Select(FromGeoLocation).ToList();

    public IList<GeoLocation> ToGeoLocation(IList<GeoLocationModel> model) => model.Select(ToGeoLocation).ToList();
  }
}