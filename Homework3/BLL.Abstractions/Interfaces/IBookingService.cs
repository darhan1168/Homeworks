using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace BLL.Abstractions.Interfaces
{
    // BookClass: Creates a new booking for the specified member and fitness class.
    // GetBookingsByMember: Retrieves a list of bookings made by the specified member.
    // GetBookingsByClass: Retrieves a list of bookings for the specified fitness class.
    // GetBookingsByDate: Retrieves a list of bookings on the specified date.
    // ConfirmBooking: Confirms the specified booking by setting its status to confirmed, making it an active booking.
    public interface IBookingService : IGenericService<Booking>
    {
        Task<Booking> BookClass(Guid memberId, Guid classId);
        
        Task<List<Booking>> GetBookingsByMember(Guid memberId);
        
        Task<List<Booking>> GetBookingsByClass(Guid classId);
        
        Task<List<Booking>> GetBookingsByDate(DateTime date);
        
        Task ConfirmBooking(Guid bookingId);
    }
}