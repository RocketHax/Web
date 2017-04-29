using EarthFire.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthFire.Data.Repositories
{
  public class FirePointRepository : EntityBaseRepository<FireLocationReport>, IFirePointRepository
  {
    public FirePointRepository(EarthFireContext context)
        : base(context)
    { }
  }
}
