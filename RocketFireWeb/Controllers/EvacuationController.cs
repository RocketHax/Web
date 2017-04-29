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
  public class EvacuationController : ApiController
  {

    private IEvacuationPointRepository _repository;
    private IEvacuationPointConverter _converter;

    public EvacuationController(IEvacuationPointRepository repository, IEvacuationPointConverter converter)
    {
      _repository = repository;
      _converter = converter;
    }
    
    // POST api/evacuation
    public void Post(AddEvacuationPointModel model)
    {
      _repository.Add(_converter.ToEvacuationPoint(model));
      _repository.Commit();
    }

    // GET api/evacuation?latitude=00?
    public GetEvacuationPointsModel Get(double latitude, double longitude)
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
