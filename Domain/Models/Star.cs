using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Star
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Rashi> Rashi { get; set; }
    }
}
