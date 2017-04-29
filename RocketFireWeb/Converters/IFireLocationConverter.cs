using EarthFire.Model.Entities;
using RocketFireWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RocketFireWeb.Converters
{
  public interface IFireLocationConverter
  {
    GeoLocation ToGeoLocation(ReportLocationModel model);

    IList<GeoLocation> ToGeoLocations(IList<ReportLocationModel> model);

    ReportLocationModel FromGeoLocation(GeoLocation model);

    IList<ReportLocationModel> FromGeoLocations(IList<GeoLocation> model);
  }
}