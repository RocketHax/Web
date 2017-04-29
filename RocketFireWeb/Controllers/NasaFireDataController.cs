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
  [RoutePrefix("api/NasaFireData")]
  public class NasaFireDataController : ApiController
  {

    private INasaFireDataFacade _facade;
    private INasaFireDataModelConverter _converter;

    public NasaFireDataController(INasaFireDataFacade facade, INasaFireDataModelConverter converter)
    {
      _facade = facade;
      _converter = converter;
    }
    
    public async Task<IList<NasaFireDataModel>> GetViirsData()
    {
      return await Task.Run(() => _converter.FromFadaceData(_facade.GetViirsNasaDataWithin24Hours()).ToList());
    }

    public async Task<IList<NasaFireDataModel>> GetModisData()
    {
      return await Task.Run(() => _converter.FromFadaceData(_facade.GetModisNasaDataWithin24Hours()).ToList());
    }
  }
}
