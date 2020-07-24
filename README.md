## **Google Geolocation / Geocoding / Batch Processing**

This is a simple WinForms application that uses Google's Geocoding service to map an address and give the Latitude and Longitude coordinates. It features batch processing of addresses (up to thousands at a time depending on your developer API - Currently it's 2,500 free before the limit is reached).

It also features a quick address / coordinates lookup with a interactive Google Map. You must provide your own API which is free from your Google Developer Console - You need to enable the Geocoding API for it to work however, i.e:

[![N|GoogleGeoBatchEncodingAPI](https://portfolio.jb-net.co.uk/shared/GeoCodeDevConsole.png)]()

Once that's up and running, clone or download this solution, and compile in Visual Studio. The application when run looks like this:

[![N|GoogleGeoBatchEncoding](https://portfolio.jb-net.co.uk/shared/GeoBatch.png)]()

Using the application is hopefully relatively straight forward.

So that you don't have to keep entering your Google API key, you can simply create a file in the bin directory (or whatever the program's working directory is) called: 

    GoogleAPIKeyt.txt

I.e:

[![N|GoogleGeoBatchEncodingAPI](https://portfolio.jb-net.co.uk/shared/Auto-Google-API-Key.png)]()

Make sure the first line contains the whole API key (no spaces).

Then when the application loads the API key field will be automatically populated.

If you have trouble compiling with the 'Telerik' dependencies, it might be worth just removing the controls and references and use the standard ones shipped with VS (textboxes and what not). I'll probably remove them myself at some point...

Use however you like!

