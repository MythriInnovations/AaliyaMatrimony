using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp.Models
{
    public class SearchVoewModel
    {
        public string SearchFor { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public int HeightFrom { get; set; }
        public int HeightTo { get; set; }
        public Religion Religion { get; set; }
        public Caste Caste { get; set; }
    }
}
