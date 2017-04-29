using EarthFire.Data;
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
  [RoutePrefix("api/ReportFire")]
  public class EvacuationController : ApiController
  {

    private IEvacuationPointRepository _repository;
    private IEvacuationPointConverter _converter;

    public EvacuationController(IEvacuationPointRepository repository, IEvacuationPointConverter converter)
    {
      _repository = repository;
      _converter = converter;
    }

    [HttpPost]
    public void AddEvacuationPoint(AddEvacuationPointModel model)
    {
      _repository.Add(_converter.ToEvacuationPoint(model));
    }

    [Route("GetFireLocation")]
    public GetEvacuationPointsModel GetEvacuationPoints(double latitude, double longitude)
    {
      //_repository.GetReportedFireInArea(_converter.ToGeoLocation(model.First), _converter.ToGeoLocation(model.Second));
      //_repository.AllIncluding()

      return new GetEvacuationPointsModel
      {
        Locations = _converter.FromEvacuationPoints(_repository.GetAll().ToList())
      };
    }
  }
}
