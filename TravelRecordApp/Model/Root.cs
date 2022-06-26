using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TravelRecordApp.Model
{
    [Table("Category")]
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }

        [ForeignKey(typeof(Icon))]
        public int iconId { get; set; }

        [ManyToOne]
        public Icon icon { get; set; }
        public DateTime LastModified18118060 { get; set; }
    }



    public class Center
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public DateTime LastModified18118060 { get; set; }
    }



    public class Chain
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime LastModified18118060 { get; set; }
    }



    public class Child
    {
        public string fsq_id { get; set; }
        public string name { get; set; }
        public DateTime LastModified18118060 { get; set; }
    }



    public class Circle
    {
        public Center center { get; set; }
        public int radius { get; set; }
        public DateTime LastModified18118060 { get; set; }
    }



    public class Context
    {
        public GeoBounds geo_bounds { get; set; }
        public DateTime LastModified18118060 { get; set; }
    }



    public class GeoBounds
    {
        public Circle circle { get; set; }
        public DateTime LastModified18118060 { get; set; }
    }



    public class Geocodes
    {
        public Main main { get; set; }
        public Roof roof { get; set; }
        public DateTime LastModified18118060 { get; set; }
    }


    [Table("Icon")]
    public class Icon
    {
        [PrimaryKey, AutoIncrement]
        public string id { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public DateTime LastModified18118060 { get; set; }
    }



    public class Location
    {
        public string address { get; set; }
        public string census_block { get; set; }
        public string country { get; set; }
        public string cross_street { get; set; }
        public string dma { get; set; }
        public string formatted_address { get; set; }
        public string locality { get; set; }
        public List<string> neighborhood { get; set; }
        public string postcode { get; set; }
        public string region { get; set; }
        public DateTime LastModified18118060 { get; set; }
    }



    public class Main
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public DateTime LastModified18118060 { get; set; }
    }



    public class RelatedPlaces
    {
        public List<Child> children { get; set; }
        public DateTime LastModified18118060 { get; set; }
    }



    public class Result
    {
        public string fsq_id { get; set; }
        public List<Category> categories { get; set; }
        public List<Chain> chains { get; set; }
        public int distance { get; set; }
        public Geocodes geocodes { get; set; }
        public string link { get; set; }
        public Location location { get; set; }
        public string name { get; set; }
        public RelatedPlaces related_places { get; set; }
        public string timezone { get; set; }
        public DateTime LastModified18118060 { get; set; }
    }



    public class Roof
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public DateTime LastModified18118060 { get; set; }
    }



    public class Root
    {
        public List<Result> results { get; set; }
        public Context context { get; set; }
        public DateTime LastModified18118060 { get; set; }
    }
}
