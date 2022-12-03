using System;
using System.Collections.Generic;
using System.Text;

namespace tcctelaTogepi.Models
{
    public class Forecast
    {
        public string date { get; set; }
        public string weekday { get; set; }
        public int max { get; set; }
        public int min { get; set; }
        public double cloudiness { get; set; }
        public double rain { get; set; }
        public int rain_probability { get; set; }
        public string wind_speedy { get; set; }
        public string description { get; set; }
        public string condition { get; set; }
    }
}
