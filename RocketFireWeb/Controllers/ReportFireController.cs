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
  public class ReportFireController : ApiController
  {

    private IGeoLocationRepository _repository;
    private IFireLocationConverter _converter;

    public ReportFireController(IGeoLocationRepository repository, IFireLocationConverter converter)
    {
      _repository = repository;
      _converter = converter;
    }

    public string Get()
    {
      return "Report fire";
    }

    public string ReportFire(string fire_name)
    {
      return fire_name;
    }

    [Route("ReportLocation")]
    [HttpPost]
    public void ReportLocation(ReportLocationModel model)
    {
      _repository.Add(_converter.ToGeoLocation(model));
    }

    [Route("GetFireLocation")]
    public ReportedFireInAreaModel GetFireLocations(FireLocationAreaModel model)
    {
      //_repository.GetReportedFireInArea(_converter.ToGeoLocation(model.First), _converter.ToGeoLocation(model.Second));
      //_repository.AllIncluding()

      return new ReportedFireInAreaModel {
        area = model,
        locations = _converter.FromGeoLocations(_repository.GetAll().ToList())
      };
    }
  }
}
