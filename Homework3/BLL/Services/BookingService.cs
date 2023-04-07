﻿using System;
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
            var member = await _memberService.GetById(memberId);
            var fitClass = await _classService.GetById(classId);

            var booking = new Booking()
            {
                Member = member,
                Class = fitClass,
                Date = DateTime.Now,
                IsConfirmed = false
            };

            await Add(booking);

            return booking;
        }

        public async Task<List<Booking>> GetBookingsByMember(Guid memberId)
        {
            var member = await _memberService.GetById(memberId);
            var bookings = await GetAll();

            return bookings.Where(b => b.Member == member).ToList();
        }

        public async Task<List<Booking>> GetBookingsByClass(Guid classId)
        {
            var fitClass = await _classService.GetById(classId);
            var bookings = await GetAll();

            return bookings.Where(b => b.Class == fitClass).ToList();
        }

        public async Task<List<Booking>> GetBookingsByDate(DateTime date)
        {
            var bookings = await GetAll();

            return bookings.Where(b => b.Date == date).ToList();
        }

        public async Task ConfirmBooking(Guid bookingId)
        {
            throw new NotImplementedException();
        }
    }
}