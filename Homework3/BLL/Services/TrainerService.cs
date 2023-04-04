using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;
using DAL.Services;

namespace BLL.Services
{
    public class TrainerService : GenericService<Trainer>, ITrainerService
    {
        public TrainerService(IRepository<Trainer> repository)
            : base(repository)
        {
        }

        public async Task<Trainer> AddTrainer(Trainer trainer)
        {
            await Add(trainer);
            return trainer;
        }

        public async Task<List<Trainer>> GetTrainersBySpecialization(string specialization)
        {
            try
            {
                var trainers = await GetAll();
                return trainers.Where(t => t.Specialization.Equals(specialization, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get trainers by specialization {specialization}. Exception: {ex.Message}");
            }
        }

        public async Task<List<Trainer>> GetAvailableTrainers(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckTrainerAvailability(Guid trainerId, DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            throw new NotImplementedException();
        }

        public async Task AssignTrainerToClass(Guid trainerId, Guid classId)
        {
            throw new NotImplementedException();
        }
    }
}