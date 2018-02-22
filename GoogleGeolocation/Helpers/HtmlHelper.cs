using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleGeolocation
{
    public class HtmlHelper
    {
        public static string GenerateMapHtml(string address, string apiKey)
        {
            if (string.IsNullOrEmpty(address))
            {
                return

                    @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN""
                       ""http://www.w3.org/TR/html4/loose.dtd"">
                    <html lang=""en""
                    <head>
                      <meta charset=""utf-8"">
                       <meta http-equiv=""X-UA-Compatible"" content=""IE=10"" /> 
                            <title>Google Geolocation</title>
                    </head>
                    <style type=""text/css""> 
                        .container {
                            position: absolute;
                            top: 50%;
                            left: 50%;
                            transform: translateX(-50%) translateY(-50%);
                        }
                    }
                    </style>                     
                    <body>
                        <div class=""container"">
                           <span style=""font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;font-size:10pt;"">No Address Loaded</span>
                        </div>
                    </body>
                    </html>";
            }
            else
            {
                // If we want to do any string manipulation...
                string formattedAddress = address;

                return

                    @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN""
                       ""http://www.w3.org/TR/html4/loose.dtd"">
                    <html lang=""en""
                    <head>
                      <meta charset=""utf-8"">
                       <meta http-equiv=""X-UA-Compatible"" content=""IE=10"" /> 
                            <title>Google Geolocation</title>
                    </head>
                    <style type=""text/css""> 
                    .container {
	                    height: 0;
	                    overflow: hidden;
	                    padding-bottom: 60%; /* aspect ratio */
	                    position: relative;
                    }
                    .googlemap {
	                    border: 0;
	                    height: 100%;
	                    left: 0;
	                    position: absolute;
	                    top: 0;
	                    width: 100%;
                    }
                    </style> 
                    <body class=""cont"">
	                    <iframe
		                    class=""googlemap"" frameborder=""0"" scrolling=""no""
		                    src=""https://www.google.com/maps/embed/v1/place?key=" + apiKey + "&q=" +
                                formattedAddress +
                             @" "" allowfullscreen>
	                    </iframe>
                    </body>
                    </html>";
            }
        }
    }
}
