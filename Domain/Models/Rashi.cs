using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Rashi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StarId { get; set; }
        public Star Star { get; set; }
    }
}
