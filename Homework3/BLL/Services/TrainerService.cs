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
            try
            {
                await Add(trainer);

                if (trainer is null)
                {
                    throw new Exception("Trainer is null");
                }
                
                return trainer;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add trainer {trainer}. Exception: {ex.Message}");
            }
        }

        public async Task<List<Trainer>> GetTrainersBySpecialization(string specialization)
        {
            try
            {
                var trainers = await GetAll();
                
                if (trainers is null)
                {
                    throw new Exception("Trainers are null");
                }

                return trainers.Where(t => t.Specialization == specialization).ToList();
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

                if (trainers is null)
                {
                    throw new Exception("Trainers are null");
                }

                return trainers.Where(t => t.AvailableDates.Contains(date)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get trainers by date {date.ToShortDateString()}. Exception: {ex.Message}");
            }
        }
        
        public async Task<bool> CheckTrainerAvailability(Guid trainerId, DateTime date)
        {
            try
            {
                var trainer = await GetById(trainerId);
                
                if (trainer is null)
                {
                    throw new Exception("Trainer is null");
                }

                if (trainer.AvailableDates.Contains(date))
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to check trainer availability for trainerId {trainerId} on {date.ToShortDateString()}. Exception: {ex.Message}");
            }
        }

        public async Task AssignTrainerToClass(Guid trainerId, Guid classId)
        {
            try
            {
                var trainer = await GetById(trainerId);
                var fitClass = await _classService.GetById(classId);
                
                if (trainer is null)
                {
                    throw new Exception("Trainer is null");
                }
                
                if (fitClass is null)
                {
                    throw new Exception("Class is null");
                }

                if (fitClass.Trainer == trainer)
                {
                    throw new Exception("Trainer already assigned to class");
                }

                fitClass.Trainer = trainer;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to check assign trainer {trainerId} to class {classId}. Exception: {ex.Message}");
            }
        }
    }
}