using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace BLL.Abstractions.Interfaces
{
    // AddTrainer: Adds a new trainer with the given create information.
    // GetTrainersBySpecialization: Retrieves a list of trainers with the specified specialization.
    // GetAvailableTrainers: Retrieves a list of available trainers on the specified date.
    // CheckTrainerAvailability: Checks the availability of the trainer on the specified date and time range.
    // AssignTrainerToClass: Assigns the trainer to the specified fitness class.
    public interface ITrainerService : IGenericService<Trainer>
    {
        Task<Trainer> AddTrainer(Trainer trainer);
        
        Task<List<Trainer>> GetTrainersBySpecialization(string specialization);
        
        Task<List<Trainer>> GetAvailableTrainers(DateTime date);
        
        Task<bool> CheckTrainerAvailability(Guid trainerId, DateTime date, TimeSpan startTime, TimeSpan endTime);
        
        Task AssignTrainerToClass(Guid trainerId, Guid classId);
    }
}