using EarthFire.Facade.Models;
using EarthFire.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthFire.Facade
{
  public interface IFireReportToFireSourceFacade
  {
    IList<GeoLocation> TriangulateFireSourceCoordinates(IList<FireLocationReport> fireReports);
  }
}
