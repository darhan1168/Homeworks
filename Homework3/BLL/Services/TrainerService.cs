using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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