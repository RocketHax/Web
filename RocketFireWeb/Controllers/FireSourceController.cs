using EarthFire.Data;
using EarthFire.Facade;
using RocketFireWeb.Converters;
using RocketFireWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RocketFireWeb.Controllers
{
  public class FireSourceController : ApiController
  {

    private IFirePointRepository _repository;
    private IGeoLocationModelConverter _converter;
    private IFireReportToFireSourceFacade _facade;

    public FireSourceController(IFirePointRepository repository, IGeoLocationModelConverter converter, IFireReportToFireSourceFacade facade)
    {
      _repository = repository;
      _converter = converter;
      _facade = facade;
    }

    // GET api/reportfire?latitude1= ...
    public FireSourcesModel Get(double latitude1, double latitude2, double longitude1, double longitude2)
    {
      var geoLocations = _facade.TriangulateFireSourceCoordinates(_repository.GetAll().ToList());
      return new FireSourcesModel
      {
        Locations = _converter.FromGeoLocation(geoLocations)
      };
    }
  }
}
