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

    IList<EvacuationPoint> ToEvacuationPoints(IList<AddEvacuationPointModel> model);

    AddEvacuationPointModel FromEvacuationPoint(EvacuationPoint model);

    IList<AddEvacuationPointModel> FromEvacuationPoints(IList<EvacuationPoint> model);
  }
}