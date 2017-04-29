using System.Collections.Generic;
using RocketFireWeb.Models;

public class GetEvacuationPointsModel
{
  public IList<AddEvacuationPointModel> Locations { get; internal set; }
}