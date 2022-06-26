﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TravelRecordApp.Model
{
    [Table("Post")]
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Experience { get; set; }

        public string VenueName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Distance { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime LastModified18118060 { get; set;}
    }
}
