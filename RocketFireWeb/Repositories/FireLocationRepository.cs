using EarthFire.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RocketFireWeb.Repositories
{
  public class FireLocationRepository : IFireLocationRepository
  {
    public void Add(GeoLocation location)
    {

    }

    public IList<GeoLocation> GetReportedFireInArea(GeoLocation first, GeoLocation second)
    {
      return new List<GeoLocation>();
    }
  }
}