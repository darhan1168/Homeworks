using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace BLL.Abstractions.Interfaces
{
    // ScheduleClass: Schedules a new fitness class with the given scheduling information.
    // GetClassesByDate: Retrieves a list of fitness classes on the specified date.
    // GetClassesByType: Retrieves a list of fitness classes with the specified class type.
    // GetClassesByTrainer: Retrieves a list of fitness classes conducted by the specified trainer.
    // AddAttendeeToClass: Adds a member as an attendee to the specified fitness class.
    public interface IClassService : IGenericService<FitnessClass>
    {
        Task<FitnessClass> ScheduleClass(FitnessClass fitnessClass);
        
        Task<List<FitnessClass>> GetClassesByDate(DateTime date);
        
        Task<List<FitnessClass>> GetClassesByType(string classType);
        
        Task<List<FitnessClass>> GetClassesByTrainer(Guid trainerId);
        
        Task AddAttendeeToClass(Guid classId, Guid memberId);
    }
}