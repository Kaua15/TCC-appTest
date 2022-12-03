using System;
using System.Collections.Generic;
using System.Text;

namespace tcctelaTogepi.Models
{
    public class Root
    {
        public Root()
        {
            results = new Results();
        }

        public string by { get; set; }
        public bool valid_key { get; set; }
        public Results results { get; set; }
        public double execution_time { get; set; }
        public bool from_cache { get; set; }
    }
}
