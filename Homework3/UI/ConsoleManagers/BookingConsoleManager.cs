﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class BookingConsoleManager : ConsoleManager<IBookingService, Booking>, IConsoleManager
    {
        private readonly ClassConsoleManager _classConsoleManager;
        private readonly MemberConsoleManager _memberConsoleManager;
        
        public BookingConsoleManager(IBookingService bookingService, ClassConsoleManager classConsoleManager, MemberConsoleManager memberConsoleManager)
            : base(bookingService)
        {
            _classConsoleManager = classConsoleManager;
            _memberConsoleManager = memberConsoleManager;
        }

        public override async Task PerformOperationsAsync()
        {
            Dictionary<string, Func<Task>> actions = new Dictionary<string, Func<Task>>
            {
                { "1", DisplayAllBookingsAsync },
                { "2", CreateBookingAsync },
                { "3", UpdateBookingAsync },
                { "4", DeleteBookingAsync },
            };

            while (true)
            {
                Console.WriteLine("\nBooking operations:");
                Console.WriteLine("1. Display all bookings");
                Console.WriteLine("2. Create a new booking");
                Console.WriteLine("3. Update a booking");
                Console.WriteLine("4. Delete a booking");
                Console.WriteLine("5. Exit");

                Console.Write("Enter the operation number: ");
                string input = Console.ReadLine();

                if (input == "5")
                {
                    break;
                }

                if (actions.ContainsKey(input))
                {
                    await actions[input]();
                }
                else
                {
                    Console.WriteLine("Invalid operation number.");
                }
            }
        }

        public async Task DisplayAllBookingsAsync()
        {
            Service.Add(new Booking());
            // Implementation for displaying all bookings
        }

        public async Task CreateBookingAsync()
        {
            try
            {
                Console.WriteLine("Enter id of member");
                Guid memberId = Guid.Parse(Console.ReadLine());

                Console.WriteLine("Enter id of class");
                Guid classId = Guid.Parse(Console.ReadLine());

                var booking = await Service.BookClass(memberId, classId);
                await CreateAsync(booking);

                await Service.ConfirmBooking(booking.Id);
                
                Console.WriteLine("Booking added and confirmed");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create booking. Exception: {ex.Message}");
            }
        }

        public async Task UpdateBookingAsync()
        {
            // Implementation for updating a booking
        }

        public async Task DeleteBookingAsync()
        {
            try
            {
                Console.WriteLine("Enter your booking id");
                Guid bookingId = Guid.Parse(Console.ReadLine());
                
                await Service.Delete(bookingId);
                Console.WriteLine("Booking was deleted");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete booking. Exception: {ex.Message}");
            }
        }
    }
}