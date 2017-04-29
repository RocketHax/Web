using RocketFireWeb.Entities;
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
  }
}