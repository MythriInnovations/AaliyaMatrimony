using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Caste
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Religion Religion { get; set; }
    }
}
