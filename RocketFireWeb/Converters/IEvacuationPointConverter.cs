using EarthFire.Model.Entities;
using RocketFireWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RocketFireWeb.Converters
{
  public interface IEvacuationPointConverter
  {
    EvacuationPoint ToEvacuationPoint(AddEvacuationPointModel model);

    IEnumerable<EvacuationPoint> ToEvacuationPoint(IEnumerable<AddEvacuationPointModel> model);

    AddEvacuationPointModel FromEvacuationPoint(EvacuationPoint model);

    IEnumerable<AddEvacuationPointModel> FromEvacuationPoint(IEnumerable<EvacuationPoint> model);
  }
}