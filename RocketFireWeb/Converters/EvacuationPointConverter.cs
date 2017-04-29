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
        Longitude = model.Longitude,
        Type = model.Type,
        Name = model.Name
      };
    }

    public EvacuationPoint ToEvacuationPoint(AddEvacuationPointModel model)
    {
      return new EvacuationPoint
      {
        Latitude = model.Latitude,
        Longitude = model.Longitude,
        Type = model.Type,
        Name = model.Name
      };
    }

    public IEnumerable<AddEvacuationPointModel> FromEvacuationPoint(IEnumerable<EvacuationPoint> model) => model.Select(FromEvacuationPoint);

    public IEnumerable<EvacuationPoint> ToEvacuationPoint(IEnumerable<AddEvacuationPointModel> model) => model.Select(ToEvacuationPoint);
  }
}