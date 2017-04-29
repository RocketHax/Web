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
    public AddFireLocationModel FromFireLocationReport(FireLocationReport model)
    {
      return new AddFireLocationModel
      {
        Latitude = model.Latitude,
        Longitude = model.Longitude,
        Bearing = model.Bearing
      };
    }

    public FireLocationReport ToFireLocationReport(AddFireLocationModel model)
    {
      return new FireLocationReport
      {
        Latitude = model.Latitude,
        Longitude = model.Longitude,
        Bearing = model.Bearing
      };
    }

    public IList<AddFireLocationModel> FromFireLocationReports(IList<FireLocationReport> model) => model.Select(FromFireLocationReport).ToList();

    public IList<FireLocationReport> ToFireLocationReports(IList<AddFireLocationModel> model) => model.Select(ToFireLocationReport).ToList();
  }
}