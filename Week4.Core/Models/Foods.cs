using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4.Core.Models
{
    public class Foods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } 
        public int EnergyValue { get; set; } 
        public string NutritionalValues { get; set; } 
        public decimal PortionSize { get; set; } 
        public string ServingFrequency { get; set; } 
        public Dictionary<string, string> Suitability { get; set; } 
        public bool IsOrganic { get; set; }
        public bool IsContainsGluten { get; set; }

        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
