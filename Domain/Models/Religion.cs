using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Religion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Caste> Castes { get; set; }
    }
}
