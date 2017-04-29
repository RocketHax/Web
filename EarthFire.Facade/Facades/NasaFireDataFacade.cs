using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EarthFire.Facade.Models;
using KMLModule.Parser;
using RocketGPS.Model;
using EarthFire.Facade.Converters;
using System.Net;
using System.Net.Security;

namespace EarthFire.Facade.Facades
{
  public class NasaFireDataFacade : INasaFireDataFacade
  {
    NasaFireDataConverter _converter;
    public NasaFireDataFacade(NasaFireDataConverter converter)
    {
      _converter = converter;
    }

    public IList<NasaFireData> GetViirsNasaDataWithin24Hours()
    {
      return GetNasaDataFromUrl("https://firms.modaps.eosdis.nasa.gov/active_fire/viirs/kml/VNP14IMGTDL_NRT_USA_contiguous_and_Hawaii_24h.kml");
    }

    public IList<NasaFireData> GetModisNasaDataWithin24Hours()
    {
      return GetNasaDataFromUrl("https://firms.modaps.eosdis.nasa.gov/active_fire/c6/kml/MODIS_C6_USA_contiguous_and_Hawaii_24h.kml");
    }

    private IList<NasaFireData> GetNasaDataFromUrl(string nasaDataUrl)
    {
      var parser = KMLParser.Get();
      string xmlContentStr;
      using (var webClient = new WebClient())
      {
        ServicePointManager.ServerCertificateValidationCallback =
           new RemoteCertificateValidationCallback(
                delegate
                { return true; }
            );
        xmlContentStr = webClient.DownloadString(nasaDataUrl);
      }

      List<KMLSatelliteFireData> modisDatas;
      return parser.Read(xmlContentStr, out modisDatas) ?
          _converter.FromKMLSatelliteFireData(modisDatas).ToList() : new List<NasaFireData>();
    }
  }
}
