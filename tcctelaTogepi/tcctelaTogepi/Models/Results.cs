using System;
using System.Collections.Generic;
using System.Text;

namespace tcctelaTogepi.Models
{
    public class Results
    {
        public Results()
        {
            forecast = new List<Forecast>();

        }

        public int temp { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string condition_code { get; set; }
        public string description { get; set; }
        public string currently { get; set; }
        public string cid { get; set; }
        public string city { get; set; }
        public string img_id { get; set; }
        public int humidity { get; set; }
        public double cloudiness { get; set; }
        public double rain { get; set; }
        public string wind_speedy { get; set; }
        public int wind_direction { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string condition_slug { get; set; }
        public string city_name { get; set; }
        public List<Forecast> forecast { get; set; }
        public string cref { get; set; }
    }
}
