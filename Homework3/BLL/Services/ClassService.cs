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
        private readonly IMemberService _memberService;

        public ClassService(IRepository<FitnessClass> repository, ITrainerService trainerService, IMemberService memberService)
            : base(repository)
        {
            _trainerService = trainerService;
            _memberService = memberService;
        }

        public async Task<FitnessClass> ScheduleClass(FitnessClass fitnessClass)
        {
            try
            {
                if (fitnessClass is null)
                {
                    throw new Exception("Fitness class is null");
                }

                await Add(fitnessClass);

                return fitnessClass;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add fitness class {fitnessClass}. Exception: {ex.Message}");
            }
        }

        public async Task<List<FitnessClass>> GetClassesByDate(DateTime date)
        {
            try
            {
                var classes = await GetAll();
                
                if (classes is null)
                {
                    throw new Exception("Classes is null");
                }

                return classes.Where(c => c.Date == date).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get classes by date {date}. Exception: {ex.Message}");
            }
        }

        public async Task<List<FitnessClass>> GetClassesByType(string classType)
        {
            try
            {
                var classes = await GetAll();
                
                if (classes is null)
                {
                    throw new Exception("Classes is null");
                }

                return classes.Where(c => c.Type == classType).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get classes by type {classType}. Exception: {ex.Message}");
            }
        }

        public async Task<List<FitnessClass>> GetClassesByTrainer(Guid trainerId)
        {
            try
            {
                var classes = await GetAll();
                var trainer = await _trainerService.GetById(trainerId);
                
                if (classes is null)
                {
                    throw new Exception("Classes is null");
                }
                
                if (trainer is null)
                {
                    throw new Exception("Trainer is null");
                }

                return classes.Where(c => c.Trainer == trainer).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get classes by trainer {trainerId}. Exception: {ex.Message}");
            }
        }

        public async Task AddAttendeeToClass(Guid classId, Guid memberId)
        {
            var fitClass = await GetById(classId);
            
            
        }
    }
}