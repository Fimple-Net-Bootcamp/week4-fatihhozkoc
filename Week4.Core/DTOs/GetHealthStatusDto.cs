using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Core.Models;

namespace Week4.Core.DTOs
{
    public class GetHealthStatusDto
    {
        public int Id { get; set; }
        public string Symptoms { get; set; }
        public string ChronicConditions { get; set; }
        public string BehaviorChanges { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentNotes { get; set; }
        public VaccinationStatus VaccinationStatus { get; set; }
        public List<String> VaccinationRecord { get; set; }
        public List<String> Medications { get; set; }
        public string Allergies { get; set; }
        public DateTime CheckupDate { get; set; }
        public int PetId { get; set; }
    }
}
