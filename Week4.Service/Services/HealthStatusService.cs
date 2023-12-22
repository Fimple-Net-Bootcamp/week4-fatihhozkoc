using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Core.DTOs;
using Week4.Core.Models;
using Week4.Core.Repositories;
using Week4.Core.Services;
using Week4.Core.UnitOfWorks;

namespace Week4.Service.Services
{
    public class HealthStatusService : IHealthStatusService
    {
        private readonly IHealthStatusRepository _healthStatusRepository;

        public HealthStatusService(IHealthStatusRepository healthStatusRepository)
        {
            _healthStatusRepository = healthStatusRepository;
        }

        public async Task<GetHealthStatusDto> GetHealthStatusAsync(int petId)
        {
            HealthStatus healthStatus = await _healthStatusRepository.GetByPetIdAsync(petId);

            if (healthStatus == null)
            {
                throw new Exception();
            }

            return new GetHealthStatusDto
            {
                Id = healthStatus.Id,
                Symptoms = healthStatus.Symptoms,
                ChronicConditions = healthStatus.ChronicConditions,
                BehaviorChanges = healthStatus.BehaviorChanges,
                Diagnosis = healthStatus.Diagnosis,
                TreatmentNotes = healthStatus.TreatmentNotes,
                VaccinationStatus = healthStatus.VaccinationStatus,
                VaccinationRecord = healthStatus.VaccinationRecord,
                Medications = healthStatus.Medications,
                Allergies = healthStatus.Allergies,
                CheckupDate = healthStatus.CheckupDate,
                PetId = healthStatus.PetId
            };
        }


    }
}
