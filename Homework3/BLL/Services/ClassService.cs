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

        public async Task AddAttendeeToClass(Guid classId, Member member)
        {
            try
            {
                var fitClass = await GetById(classId);

                if (fitClass is null)
                {
                    throw new Exception("Class is null");
                }
                
                if (member is null)
                {
                    throw new Exception("Member is null");
                }
            
                if (fitClass.Attendees.Contains(member))
                {
                    throw new Exception("Member already added in class");
                }
                
                fitClass.Attendees.Add(member);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add attendee class {classId}. Exception: {ex.Message}");
            }
        }
        
        public async Task AssignTrainerToClass(Guid trainerId, Guid classId)
        {
            try
            {
                var trainer = await _trainerService.GetById(trainerId);
                var fitClass = await GetById(classId);
                
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
            
                await Update(classId, fitClass);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to check assign trainer {trainerId} to class {classId}. Exception: {ex.Message}");
            }
        }
    }
}