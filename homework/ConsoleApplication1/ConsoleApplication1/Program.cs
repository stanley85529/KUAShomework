using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var stations = FindStations();
        }

        public static List<Station> FindStations()
        {
            List<Station> stations = new List<Station>();
            var xml = XElement.Load(@"C:\Users\user\Desktop\homework\homework\homework.xml");
            XNamespace gml = @"http://www.opengis.net/gml/3.2";
            XNamespace twed = @"http://twed.wra.gov.tw/twedml/opendata";
            var stationsNode = xml.Descendants(twed + "RiverStageObservatoryProfile").ToList();
            for (var i = 0; i < stationsNode.Count(); i++)
            {
                var stationNode = stationsNode[i];
            }

            foreach (var stationNode in stationsNode)
            {

            }
            stationsNode
                .Where(x => !x.IsEmpty).ToList()
                .ForEach(stationNode =>
                {
                    var BasinIdentifier = stationNode.Element(twed + "BasinIdentifier").Value.Trim();
                    var ObservatoryName = stationNode.Element(twed + "ObservatoryName").Value.Trim();
                    var LocationAddress = stationNode.Element(twed + "LocationAddress").Value.Trim();
                    var LocationByTWD67pos = stationNode.Element(twed + "LocationByTWD67pos").Descendants(gml + "pos").FirstOrDefault().Value.Trim();
                    var LocationByTWD97pos = stationNode.Element(twed + "LocationByTWD97pos").Descendants(gml + "pos").FirstOrDefault().Value.Trim();
                    Station stationData = new Station();
                    stationData.ID = BasinIdentifier;
                    stationData.LocationAddress = LocationAddress;
                    stationData.ObservatoryName = ObservatoryName;
                    stationData.LocationByTWD67 = LocationByTWD67pos;
                    stationData.CreateTime = DateTime.Now;
                    stations.Add(stationData);

                });
            return stations;
        }
    }
}