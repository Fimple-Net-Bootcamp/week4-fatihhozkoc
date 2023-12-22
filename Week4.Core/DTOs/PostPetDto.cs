using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4.Core.DTOs
{
    public class PostPetDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public decimal Weight { get; set; }
        public int UserId { get; set; }
    }
}
