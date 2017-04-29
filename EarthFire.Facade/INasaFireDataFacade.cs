using EarthFire.Facade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthFire.Facade
{
  public interface INasaFireDataFacade
  {
    IList<NasaFireData> GetViirsNasaDataWithin24Hours();
    IList<NasaFireData> GetModisNasaDataWithin24Hours();
  }
}
