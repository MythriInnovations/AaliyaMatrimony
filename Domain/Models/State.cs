using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class State
    {
        public int id { get; set; }
        public string name { get; set; }
        public Country Country { get; set; }
        public int country_id { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
