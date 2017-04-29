using EarthFire.Facade.Models;
using RocketFireWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RocketFireWeb.Converters
{
  public interface IGeoLocationModelConverter
  {
    GeoLocation ToGeoLocation(GeoLocationModel model);

    IList<GeoLocation> ToGeoLocation(IList<GeoLocationModel> model);

    GeoLocationModel FromGeoLocation(GeoLocation model);

    IList<GeoLocationModel> FromGeoLocation(IList<GeoLocation> model);
  }
}