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
  public class FireSourceController : ApiController
  {

    private IFirePointRepository _repository;
    private IFireLocationConverter _converter;

    public FireSourceController(IFirePointRepository repository, IFireLocationConverter converter)
    {
      _repository = repository;
      _converter = converter;
    }

    // POST api/reportfire
    public void Post(AddFireLocationModel model)
    {
      _repository.Add(_converter.ToFireLocationReport(model));
      _repository.Commit();
    }

    // GET api/reportfire?latitude1= ...
    public ReportedFireInAreaModel Get(double latitude1, double latitude2, double longitude1, double longitude2)
    {
      //_repository.GetReportedFireInArea(_converter.ToGeoLocation(model.First), _converter.ToGeoLocation(model.Second));
      //_repository.AllIncluding()

      return new ReportedFireInAreaModel
      {
        Locations = _converter.FromFireLocationReports(_repository.GetAll().ToList())
      };
    }
  }
}
