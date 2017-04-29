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
    FireLocationReport ToFireLocationReport(AddFireLocationModel model);

    IList<FireLocationReport> ToFireLocationReports(IList<AddFireLocationModel> model);

    AddFireLocationModel FromFireLocationReport(FireLocationReport model);

    IList<AddFireLocationModel> FromFireLocationReports(IList<FireLocationReport> model);
  }
}