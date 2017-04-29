using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RocketFireWeb.Models
{
  public class AddFireLocationModel : GeoLocationModel
  {
    public double Bearing { get; set; }
  }
}