using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;

namespace BLL.Services
{
    public class ClassService : GenericService<FitnessClass>, IClassService
    {
        private readonly ITrainerService _trainerService;

        public ClassService(IRepository<FitnessClass> repository, ITrainerService trainerService)
            : base(repository)
        {
            _trainerService = trainerService;
        }

        public async Task<FitnessClass> ScheduleClass(FitnessClass fitnessClass)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FitnessClass>> GetClassesByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FitnessClass>> GetClassesByType(string classType)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FitnessClass>> GetClassesByTrainer(Guid trainerId)
        {
            throw new NotImplementedException();
        }

        public async Task AddAttendeeToClass(Guid classId, Guid memberId)
        {
            throw new NotImplementedException();
        }
    }
}