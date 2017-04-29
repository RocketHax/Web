using EarthFire.Facade.Models;
using RocketFireWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RocketFireWeb.Converters
{
  public interface IGeoLocationConverter
  {
    GeoLocation ToFireLocationReport(GeoLocationModel model);

    IList<GeoLocation> ToFireLocationReports(IList<GeoLocationModel> model);

    GeoLocationModel FromFireLocationReport(GeoLocation model);

    IList<GeoLocationModel> FromFireLocationReports(IList<GeoLocation> model);
  }
}