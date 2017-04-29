using EarthFire.Facade.Models;
using RocketFireWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RocketFireWeb.Converters
{
  public class GeoLocationConverter : IGeoLocationConverter
  {
    public GeoLocationModel FromFireLocationReport(GeoLocation model)
    {
      return new AddFireLocationModel
      {
        Latitude = model.Latitude,
        Longitude = model.Longitude
      };
    }

    public GeoLocation ToFireLocationReport(GeoLocationModel model)
    {
      return new GeoLocation
      {
        Latitude = model.Latitude,
        Longitude = model.Longitude
      };
    }

    public IList<GeoLocationModel> FromFireLocationReports(IList<GeoLocation> model) => model.Select(FromFireLocationReport).ToList();

    public IList<GeoLocation> ToFireLocationReports(IList<GeoLocationModel> model) => model.Select(ToFireLocationReport).ToList();
  }
}