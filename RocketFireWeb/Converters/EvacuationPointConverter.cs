using EarthFire.Model.Entities;
using RocketFireWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RocketFireWeb.Converters
{
  public class EvacuationPointConverter : IEvacuationPointConverter
  {
    public AddEvacuationPointModel FromEvacuationPoint(EvacuationPoint model)
    {
      return new AddEvacuationPointModel
      {
        Latitude = model.Latitude,
        Longitude = model.Longitude
      };
    }

    public EvacuationPoint ToEvacuationPoint(AddEvacuationPointModel model)
    {
      return new EvacuationPoint
      {
        Latitude = model.Latitude,
        Longitude = model.Longitude
      };
    }

    public IList<AddEvacuationPointModel> FromEvacuationPoints(IList<EvacuationPoint> model) => model.Select(FromEvacuationPoint).ToList();

    public IList<EvacuationPoint> ToEvacuationPoints(IList<AddEvacuationPointModel> model) => model.Select(ToEvacuationPoint).ToList();
  }
}