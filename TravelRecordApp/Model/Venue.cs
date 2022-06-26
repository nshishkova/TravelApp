using System;
using System.Collections.Generic;
using System.Text;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.Model
{
    //    public class Location
    //    {
    //        public string address { get; set; }
    //        public string census_block { get; set; }
    //        public string country { get; set; }
    //        public string cross_street { get; set; }
    //        public string dma { get; set; }
    //        public string formatted_address { get; set; }
    //        public string locality { get; set; }
    //        public IList<string> neighborhood { get; set; }
    //        public string postcode { get; set; }
    //        public string region { get; set; }
    //    }



    //    public class Icon
    //    {
    //        public string prefix { get; set; }
    //        public string suffix { get; set; }
    //    }

    //    public class Category
    //    {
    //        public int id { get; set; }
    //        public string name { get; set; }
    //        public Icon icon { get; set; }
    //    }
    //    public class Child
    //    {
    //        public string fsq_id { get; set; }
    //        public string name { get; set; }
    //    }

    //    public class RelatedPlaces
    //    {
    //        public IList<Child> children { get; set; }
    //    }

    //    public class Venue
    //    {
    //        public string fsq_id { get; set; }
    //        public IList<Category> categories { get; set; }
    //        public IList<Chain> chains { get; set; }
    //        public int distance { get; set; }
    //        public Geocodes geocodes { get; set; }
    //        public string link { get; set; }
    //        public Location location { get; set; }
    //        public string name { get; set; }
    //        public RelatedPlaces related_places { get; set; }
    //        public string timezone { get; set; }
    //    }

    //    public class Center
    //    {
    //        public double latitude { get; set; }
    //        public double longitude { get; set; }
    //    }

    //    public class Circle
    //    {
    //        public Center center { get; set; }
    //        public int radius { get; set; }
    //    }

    //    public class Response
    //    {
    //        public IList<Venue> venues { get; set; }
    //    }

    public class VenueRoot
{
    //public Response results { get; set; }


    public static string GenerateURL(double lat, double lon)
    {
        return string.Format(Constants.VENUE_SEARCH, lat, lon, DateTime.Now.ToString("yyyyMMdd"));
    }
}
}
