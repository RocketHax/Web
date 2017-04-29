using RocketFireWeb.Entities;
using RocketFireWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RocketFireWeb.Converters
{
  public class FireLocationConverter : IFireLocationConverter
  {
    public GeoLocation ToGeoLocation(ReportLocationModels model)
    {
      return new GeoLocation
      {
        Latitude = model.Latitude,
        Longitude = model.Longitude
      };
    }
  }
}