using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4.Core.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Species { get; set; } 
        public string Breed { get; set; } 
        public decimal Weight { get; set; }


        public int UserId { get; set; }
        public virtual User User { get; set; }

        public  ICollection<HealthStatus> Statutes { get; set; }

        public ICollection<Activities> Activities { get; set; }

        public ICollection<Foods> Foods { get; set; }
    }
}
