using System;
using System.Data.Entity;

namespace EarthFire.Data
{
  public class EarthFireInitializer : DropCreateDatabaseIfModelChanges<EarthFireContext>
  {
    protected override void Seed(EarthFireContext context)
    {
      base.Seed(context);

      context.EvacuationPoints.Add(new Model.Entities.EvacuationPoint { Id = 1, Latitude = 39.502782, Longitude = -105.334892, Type = "FireDepartment" });
      context.EvacuationPoints.Add(new Model.Entities.EvacuationPoint { Id = 2, Latitude = 39.715525, Longitude = -105.327130, Type = "FireDepartment" });
      context.EvacuationPoints.Add(new Model.Entities.EvacuationPoint { Id = 3, Latitude = 39.812643, Longitude = -105.498791, Type = "FireDepartment" });
      context.EvacuationPoints.Add(new Model.Entities.EvacuationPoint { Id = 4, Latitude = 40.038413, Longitude = -105.341069, Type = "FireDepartment" });
      context.EvacuationPoints.Add(new Model.Entities.EvacuationPoint { Id = 5, Latitude = 40.080193, Longitude = -105.929112, Type = "FireDepartment" });

      context.EvacuationPoints.Add(new Model.Entities.EvacuationPoint { Id = 6, Latitude = 40.014041, Longitude = -105.274642, Type = "Evacs" });
      context.EvacuationPoints.Add(new Model.Entities.EvacuationPoint { Id = 7, Latitude = 40.067321, Longitude = -105.411979, Type = "Evacs" });
      context.EvacuationPoints.Add(new Model.Entities.EvacuationPoint { Id = 8, Latitude = 40.035906, Longitude = -105.281822, Type = "Evacs" });
      context.EvacuationPoints.Add(new Model.Entities.EvacuationPoint { Id = 9, Latitude = 39.944586, Longitude = -105.347654, Type = "Evacs" });
      context.EvacuationPoints.Add(new Model.Entities.EvacuationPoint { Id = 10, Latitude = 39.971085, Longitude = -105.511508, Type = "Evacs" });
    }
  }
}