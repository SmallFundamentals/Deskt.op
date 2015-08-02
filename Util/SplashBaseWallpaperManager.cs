using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;

namespace Deskt.op.Util
{
    public class SplashBaseWallpaperManager : BaseWallpaperManager
    {
        private HttpClient httpClient;
        private HttpResponseMessage response;
        IDictionary<string, object> responseDict;
        private JavaScriptSerializer json_serializer;

        public SplashBaseWallpaperManager() { }

        public override string GetNextRandomUrl()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(RANDOM_IMAGE_API_ROUTE);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            response = httpClient.GetAsync(IMAGE_ONLY_QUERY_PARAM).Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                string responseString = response.Content.ReadAsStringAsync().Result;
                json_serializer = new JavaScriptSerializer();
                responseDict = (IDictionary<string, object>)json_serializer.DeserializeObject(responseString);
                return this.getUrl();
            }
            else
            {
                // TODO: Do some logging and/or error handling.
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }  
        }

        public override string getUrl()
        {
            try
            {
                return responseDict["url"].ToString();
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public override Uri getUri()
        { 
            return new Uri(getUrl());
        }

        private const string IMAGE_BY_ID_API_ROUTE = "http://www.splashbase.co/api/v1/images/1";
        private const string RANDOM_IMAGE_API_ROUTE = "http://www.splashbase.co/api/v1/images/random";
        private const string LATEST_10_IMAGE_API_ROUTE = "http://www.splashbase.co/api/v1/images/latest";
        private const string IMAGE_ONLY_QUERY_PARAM = "?images_only=true";
        
        private Dictionary<Sources, string> SourceToStringDict = new Dictionary<Sources, string>
        {
            /*{ Sources.travelcoffeebook, "travelcoffeebook" },
            { Sources.getrefe, "getrefe" },
            { Sources.jaymantri, "jaymantri" },
            { Sources.snapographic, "snapographic" },
            { Sources.splitshire, "splitshire" },
            { Sources.lifeofpix, "lifeofpix"},*/
            { Sources.unsplash, "unsplash"}
        };

        private enum Sources 
        {
            travelcoffeebook, 
            startupstockphotos, 
            littlevisuals, 
            gratisography, 
            getrefe, 
            jaymantri, 
            superfamous, 
            mazwai, 
            unsplash, 
            snapographic, 
            moveast, 
            snapwiresnaps, 
            newoldstock, 
            splitshire, 
            camarama, 
            mmt, 
            lifeofpix, 
            crowthestone, 
            skitterphoto
        };
    }
}
