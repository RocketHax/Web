using EarthFire.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RocketFireWeb.Repositories
{
  public class FireLocationRepository : IFireLocationRepository
  {
    public void Add(FireLocationReport location)
    {

    }

    public IList<FireLocationReport> GetReportedFireInArea(FireLocationReport first, FireLocationReport second)
    {
      return new List<FireLocationReport>();
    }
  }
}