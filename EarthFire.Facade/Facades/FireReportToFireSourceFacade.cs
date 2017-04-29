using EarthFire.Facade.Converters;
using EarthFire.Facade.Models;
using EarthFire.Model.Entities;
using RocketGPSMath.GPSMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthFire.Facade.Facades
{
  public class FireReportToFireSourceFacade : IFireReportToFireSourceFacade
  {
    private FireLocationReportConverter _fireLocationReportConverter;
    private GeoLocationConverter _getLocationConverter;

    public FireReportToFireSourceFacade(FireLocationReportConverter fireLocationReportConverter, GeoLocationConverter getLocationConverter)
    {
      _fireLocationReportConverter = fireLocationReportConverter;
      _getLocationConverter = getLocationConverter;
    }

    public IList<GeoLocation> TriangulateFireSourceCoordinates(IList<FireLocationReport> fireReports)
    {
      var triangulator = new RegionTriangulator(_fireLocationReportConverter.ToGPSCoordinates(fireReports).ToList());
      return _getLocationConverter.FromGPSCoordinates(triangulator.Triangulate()).ToList();
    }
  }
}
