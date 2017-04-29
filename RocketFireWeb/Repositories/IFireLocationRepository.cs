using EarthFire.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RocketFireWeb.Repositories
{
  public interface IFireLocationRepository
  {
    void Add(GeoLocation location);

    IList<GeoLocation> GetReportedFireInArea(GeoLocation first, GeoLocation second);
  }
}