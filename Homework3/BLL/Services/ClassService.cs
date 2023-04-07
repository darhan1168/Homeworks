using System;
using System.Collections.Generic;
using System.Linq;
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
            await Add(fitnessClass);

            return fitnessClass;
        }

        public async Task<List<FitnessClass>> GetClassesByDate(DateTime date)
        {
            var classes = await GetAll();

            return classes.Where(c => c.Date == date).ToList();
        }

        public async Task<List<FitnessClass>> GetClassesByType(string classType)
        {
            var classes = await GetAll();

            return classes.Where(c => c.Type == classType).ToList();
        }

        public async Task<List<FitnessClass>> GetClassesByTrainer(Guid trainerId)
        {
            var classes = await GetAll();
            var trainer = await _trainerService.GetById(trainerId);

            return classes.Where(c => c.Trainer == trainer).ToList();
        }

        public async Task AddAttendeeToClass(Guid classId, Guid memberId)
        {
            throw new NotImplementedException();
        }
    }
}