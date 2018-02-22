using System;
using System.Net;
using System.Xml.Linq;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "99 Marsden Hall Road North, Nelson, Lancashire BB9 8JH";

            // You need to fill you API key from Google for this to work
            string key = "";

            string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&key={1}", Uri.EscapeDataString(address), key);

            WebRequest request = WebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());

            XElement result = xdoc.Element("GeocodeResponse").Element("result");
            XElement locationElement = result.Element("geometry").Element("location");

            string lat = ((XElement)locationElement.Element("lat")).Value;
            string lng = ((XElement)locationElement.Element("lng")).Value;

            Console.Out.WriteLine(lat + "," + lng);

            Console.In.ReadLine();
        }
    }
}
