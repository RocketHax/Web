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

    private IFirePointRepository _repository;
    private IFireLocationConverter _converter;

    public ReportFireController(IFirePointRepository repository, IFireLocationConverter converter)
    {
      _repository = repository;
      _converter = converter;
    }

    [HttpPost]
    public void AddFireLocation(AddFireLocationModel model)
    {
      _repository.Add(_converter.ToFireLocationReport(model));
    }

    [HttpGet]
    public ReportedFireInAreaModel GetFireLocations(double latitude1, double latitude2, double longitude1, double longitude2)
    {
      //_repository.GetReportedFireInArea(_converter.ToGeoLocation(model.First), _converter.ToGeoLocation(model.Second));
      //_repository.AllIncluding()

      return new ReportedFireInAreaModel {
        Locations = _converter.FromFireLocationReports(_repository.GetAll().ToList())
      };
    }
  }
}
