using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RocketFireWeb.Models
{
  public class ReportedFireInAreaModel
  {
    public FireLocationAreaModel Area;
    public IList<AddFireLocationModel> Locations;
  }
}