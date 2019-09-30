using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
        public string iso3 { get; set; }
        public string iso2 { get; set; }
        public string phone_code { get; set; }
        public string capital { get; set; }
        public string currency { get; set; }
        public ICollection<State> States { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
