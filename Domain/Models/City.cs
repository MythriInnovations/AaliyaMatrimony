using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class City
    {
        public string id { get; set; }
        public string name { get; set; }
        public int state_id { get; set; }
        public State State { get; set; }
        public int country_id { get; set; }
        public Country Country { get; set; }
    }
}
