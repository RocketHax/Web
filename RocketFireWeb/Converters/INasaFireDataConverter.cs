using EarthFire.Facade.Models;
using RocketFireWeb.Models;
using System.Collections.Generic;

namespace RocketFireWeb.Converters
{
  public interface INasaFireDataModelConverter
  {
    NasaFireDataModel FromFadaceData(NasaFireData data);

    IEnumerable<NasaFireDataModel> FromFadaceData(IEnumerable<NasaFireData> data);
  }
}