using EarthFire.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthFire.Data
{
  public interface IFirePointRepository : IEntityBaseRepository<FireLocationReport> { }

  public interface IEvacuationPointRepository : IEntityBaseRepository<EvacuationPoint> { }
}
