using EarthFire.Model.Entities;
using RocketFireWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RocketFireWeb.Converters
{
  public class FireLocationConverter : IFireLocationConverter
  {
    public ReportLocationModel FromGeoLocation(GeoLocation model)
    {
      return new ReportLocationModel
      {
        Latitude = model.Latitude,
        Longitude = model.Longitude,
        Bearing = model.Bearing
      };
    }

    public GeoLocation ToGeoLocation(ReportLocationModel model)
    {
      return new GeoLocation
      {
        Latitude = model.Latitude,
        Longitude = model.Longitude,
        Bearing = model.Bearing
      };
    }

    public IList<ReportLocationModel> FromGeoLocations(IList<GeoLocation> model) => model.Select(FromGeoLocation).ToList();

    public IList<GeoLocation> ToGeoLocations(IList<ReportLocationModel> model) => model.Select(ToGeoLocation).ToList();
  }
}