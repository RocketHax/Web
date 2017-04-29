using System.Collections.Generic;
using RocketFireWeb.Models;

public class GetEvacuationPointModel : AddEvacuationPointModel
{
  public int Id { get; set; }
  //TODO
  // Model
  // id, name, latitide, longitude, bearing, type ("fire", "evac", "station", "others")
}