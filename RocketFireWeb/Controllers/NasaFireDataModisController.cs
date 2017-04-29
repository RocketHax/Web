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
  public class NasaFireDataModisController : ApiController
  {
    private INasaFireDataFacade _facade;
    private INasaFireDataModelConverter _converter;

    public NasaFireDataModisController(INasaFireDataFacade facade, INasaFireDataModelConverter converter)
    {
      _facade = facade;
      _converter = converter;
    }

    public IList<NasaFireDataModel> Get()
    {
      return _converter.FromFadaceData(_facade.GetModisNasaDataWithin24Hours()).ToList();
    }
  }
}
