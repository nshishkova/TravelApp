using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravelRecordApp.Model;
using System.Linq;

namespace TravelRecordApp.Logic
{
    public class VenueLogic
    {
        public async static Task<List<Result>> GetVenues(double latitude, double longitude)
        {
            List<Result> venues = new List<Result>();

            var url = VenueRoot.GenerateURL(latitude, longitude);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", @"fsq3sSeMTl+puXEy/eKSDhCcNfMCh/lvDwCz7fG9swJlGWc=");
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                var venueRoot = JsonConvert.DeserializeObject<Root>(json);

                venues = venueRoot.results as List<Result>;
            }

            return venues;
        }
    }
}
