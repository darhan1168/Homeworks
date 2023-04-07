using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;
using DAL.Services;
using Exception = System.Exception;

namespace BLL.Services
{
    public class TrainerService : GenericService<Trainer>, ITrainerService
    {
        private readonly IClassService _classService;
        
        public TrainerService(IRepository<Trainer> repository, IClassService classService)
            : base(repository)
        {
            _classService = classService;
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
            try
            {
                var trainers = await GetAll();
                var unavailableTrainers = new List<Trainer>();
                
                foreach (var trainer in trainers)
                {
                    var isAvailable = await CheckTrainerAvailability(trainer.Id, date);
                    
                    if (!isAvailable)
                    {
                        unavailableTrainers.Add(trainer);
                    }
                }
                
                return trainers.Except(unavailableTrainers).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get trainers by date {date}. Exception: {ex.Message}");
            }
        }
        
        public async Task<bool> CheckTrainerAvailability(Guid trainerId, DateTime date)
        {
            try
            {
                var trainer = await GetById(trainerId);

                foreach (var availableDate in trainer.AvailableDates)
                {
                    if (availableDate == date)
                    {
                        return true;
                    }
                }
                
                return trainer.AvailableDates.All(c => c.Date != date);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to check trainer availability for trainerId {trainerId} on {date.ToShortDateString()}. Exception: {ex.Message}");
            }
        }

        public async Task AssignTrainerToClass(Guid trainerId, Guid classId)
        {
            throw new NotImplementedException();
        }
    }
}