using System.Collections.Generic;
using RocketFireWeb.Models;

public class GetEvacuationPointsModel
{
  //TODO
  // Model
  // id, name, latitide, longitude, bearing, type ("fire", "evac", "station", "others")
  public IList<AddEvacuationPointModel> Locations { get; internal set; }
}