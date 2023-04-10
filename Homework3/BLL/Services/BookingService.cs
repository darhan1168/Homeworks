using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;

namespace BLL.Services
{
    public class BookingService : GenericService<Booking>, IBookingService
    {
        private readonly IClassService _classService;
        private readonly IMemberService _memberService;

        public BookingService(IRepository<Booking> repository, IClassService classService, IMemberService memberService)
            : base(repository)
        {
            _classService = classService;
            _memberService = memberService;
        }

        public async Task<Booking> BookClass(Guid memberId, Guid classId)
        {
            try
            {
                var member = await _memberService.GetById(memberId);
                var fitClass = await _classService.GetById(classId);

                if (member is null)
                {
                    throw new Exception("Member is null");
                }
                
                if (fitClass is null)
                {
                    throw new Exception("Class is null");
                }
            
                var booking = new Booking()
                {
                    Id = Guid.NewGuid(),
                    Member = member,
                    Class = fitClass,
                    Date = DateTime.Now,
                    IsConfirmed = false
                };
            
                await Add(booking);
            
                return booking;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add booking. Exception: {ex.Message}");
            }
        }

        public async Task<List<Booking>> GetBookingsByMember(Guid memberId)
        {
            try
            {
                var member = await _memberService.GetById(memberId);
                var bookings = await GetAll();
                
                if (member is null)
                {
                    throw new Exception("Member is null");
                }
                
                if (bookings is null)
                {
                    throw new Exception("Bookings is null");
                }

                return bookings.Where(b => b.Member == member).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get bookings by member {memberId}. Exception: {ex.Message}");
            }
        }

        public async Task<List<Booking>> GetBookingsByClass(Guid classId)
        {
            try
            {
                var fitClass = await _classService.GetById(classId);
                var bookings = await GetAll();
                
                if (fitClass is null)
                {
                    throw new Exception("Class is null");
                }
                
                if (bookings is null)
                {
                    throw new Exception("Bookings is null");
                }

                return bookings.Where(b => b.Class == fitClass).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get bookings by class {classId}. Exception: {ex.Message}");
            }
        }

        public async Task<List<Booking>> GetBookingsByDate(DateTime date)
        {
            try
            {
                var bookings = await GetAll();

                if (bookings is null)
                {
                    throw new Exception("Bookings is null");
                }

                return bookings.Where(b => b.Date == date).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get bookings by date {date}. Exception: {ex.Message}");
            }
        }

        public async Task ConfirmBooking(Guid bookingId)
        {
            try
            {
                var booking = await GetById(bookingId);

                if (booking is null)
                {
                    throw new Exception("Booking is null");
                }

                booking.IsConfirmed = true;

                await Update(bookingId, booking);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to confirm booking {bookingId}. Exception: {ex.Message}");
            }
        }
    }
}