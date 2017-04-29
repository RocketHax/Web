using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpKml.Dom;
using SharpKml.Base;
using SharpKml.Engine;
using System.IO;
using System.Xml;
using RocketGPS.Model;
using System.Text.RegularExpressions;

namespace KMLModule.Parser
{
    public class KMLParser
    {
        private static KMLParser parser = new KMLParser();

        public static KMLParser Get()
        {
            return parser;
        }

        public bool ReadByFile(string filePath, out List<KMLSatelliteFireData> datas)
        {
            datas = new List<KMLSatelliteFireData>();

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                return Read(doc.InnerXml, out datas);
            }
            catch
            {
                return false;
            }
        }

        public bool Read(string xmlContent, out List<KMLSatelliteFireData> datas)
        {
            datas = new List<KMLSatelliteFireData>();

            try
            {
                KmlFile file;
                using (var stream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(xmlContent)))
                    file = KmlFile.Load(stream);

                foreach (var p in file.Root.Flatten().OfType<Placemark>())
                {
                    KMLSatelliteFireData m = new KMLSatelliteFireData();
                    m.name = p.Name;
                    m.Description = p.Description.Text;

                    var pt = p.Flatten().OfType<Point>().ElementAt(0);
                    m.coordinate = new GPSCoordinate(pt.Coordinate.Latitude, pt.Coordinate.Longitude);

                    //Time stamp
                    {
                        string regexDate = "Date Acquired : ([0-9]+)-([0-9]+)-([0-9]+)";
                        string regexTime = "Time: ([0-9]+):([0-9]+) ([a-zA-Z]{3})";

                        Match mDate = Regex.Match(p.Description.Text, regexDate, RegexOptions.IgnoreCase);
                        Match mTime = Regex.Match(p.Description.Text, regexTime, RegexOptions.IgnoreCase);

                        if (mDate.Success && mTime.Success)
                        {
                            var year = Convert.ToInt32(mDate.Groups[1].Value);
                            var month = Convert.ToInt32(mDate.Groups[2].Value);
                            var day = Convert.ToInt32(mDate.Groups[3].Value);

                            var hour = Convert.ToInt32(mTime.Groups[1].Value);
                            var minute = Convert.ToInt32(mTime.Groups[2].Value);
                            var timezone = mTime.Groups[3].Value;

                            m.date = new DateTime(year, month, day, hour, minute, 0);
                        }
                    }

                    //Fire Confidence
                    {
                        string regexConfidence = "Confidence .* : ([0-9]+)";
                        Match mConfidence = Regex.Match(p.Description.Text, regexConfidence, RegexOptions.IgnoreCase);

                        if (mConfidence.Success)
                            m.fireConfidence = Convert.ToInt32(mConfidence.Groups[1].Value);
                    }

                    //Satellite Source
                    {
                        string regexSatellite = "Satellite: ([a - zA - Z]{ 1})";
                        Match mSatellite = Regex.Match(p.Description.Text, regexSatellite, RegexOptions.IgnoreCase);

                        if (mSatellite.Success)
                            m.satelliteSource = mSatellite.Groups[1].Value;
                    }

                    datas.Add(m);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

    }
}
