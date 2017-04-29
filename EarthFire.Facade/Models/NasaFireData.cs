using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthFire.Facade.Models
{
  public class NasaFireData
  {
    public string Name { get; set; }
    public GeoLocation Coordinate { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; } //time in UTC
    public int FireConfidence { get; set; }
    public string SatelliteSource { get; set; }
  }
}
