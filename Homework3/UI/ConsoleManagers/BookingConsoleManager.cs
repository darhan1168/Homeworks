using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class BookingConsoleManager : ConsoleManager<IBookingService, Booking>, IConsoleManager<Booking>
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
            try
            {
                Console.Clear();
                
                var bookings = await GetAllAsync();
                
                if (bookings is null)
                {
                    throw new Exception("Bookings are not found");
                }
                
                int index = 1;
            
                foreach (var booking in bookings)
                {
                    Console.WriteLine($"{index} - Member: {booking.Member?.FirstName}, {booking.Member?.LastName}, Class: {booking.Class?.Name}, Date: {booking.Date}, Id: {booking.Id}");
                    index++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to display all booking. Exception: {ex.Message}");
            }
        }

        public async Task CreateBookingAsync()
        {
            try
            {
                Console.Clear();
                
                var members = await _memberConsoleManager.GetAllAsync();
                var classes = await _classConsoleManager.GetAllAsync();

                await _memberConsoleManager.DisplayAllMembersAsync();
                
                Console.WriteLine("Enter the serial number of member");
                int indexMember = Int32.Parse(Console.ReadLine());
                var member = members.ElementAt(indexMember - 1);

                await _classConsoleManager.DisplayAllClassesAsync();
                
                Console.WriteLine("Enter the serial number of class");
                int indexClass = Int32.Parse(Console.ReadLine());
                var fitClass = classes.ElementAt(indexClass - 1);

                await Service.BookClass(member.Id, fitClass.Id);

                Console.WriteLine("Booking added and confirmed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to create booking in console manager. Exception: {ex.Message}");
            }
        }

        public async Task UpdateBookingAsync()
        {
             try
             {
                 Console.Clear();
            
                 var bookings = await Service.GetAll();
            
                 if (bookings is null)
                 {
                     throw new Exception("Bookings are not added yet");
                 }

                 await DisplayAllBookingsAsync();
                 
                 Console.WriteLine("Enter the serial number of booking");
                 int indexBooking = Int32.Parse(Console.ReadLine());
                 var booking = bookings[indexBooking - 1];
                 
                 Console.WriteLine("Enter what you need to change (1 - Member, 2 - Class)");
                 var answerUpdate = Console.ReadLine();
            
                 if (answerUpdate == "1")
                 {
                     var members = await _memberConsoleManager.GetAllAsync();
                         
                     if (members is null)
                     {
                         throw new Exception("Members are not added yet");
                     }

                     await _memberConsoleManager.DisplayAllMembersAsync();
                             
                     Console.WriteLine("Enter the serial number of members");
                     int indexMember = Int32.Parse(Console.ReadLine());
                             
                     var newMember = await _memberConsoleManager.GetByIdAsync(members.ElementAt(indexMember - 1).Id);
                     booking.Member = newMember;
                 }
                 else if (answerUpdate == "2")
                 {
                     var classes = await _classConsoleManager.GetAllAsync();
                     
                     if (classes is null)
                     {
                         throw new Exception("Сlasses are not added yet");
                     }

                     await _classConsoleManager.DisplayAllClassesAsync();
                             
                     Console.WriteLine("Enter the serial number of classes");
                     int indexClass = Int32.Parse(Console.ReadLine());
                             
                     var newClass = await _classConsoleManager.GetByIdAsync(classes.ElementAt(indexClass - 1).Id);
                     booking.Class = newClass;
                 }
                 else
                 {
                     throw new Exception("Incorrect answer");
                 }
            
                 await UpdateAsync(booking.Id, booking);
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Failed to update booking. Exception: {ex.Message}");
             }
        }

        public async Task DeleteBookingAsync()
        {
            try
            {
                Console.Clear();
                
                var bookings = await GetAllAsync();
            
                if (bookings is null)
                {
                    throw new Exception("Bookings are not added yet");
                }

                await DisplayAllBookingsAsync();
                
                Console.WriteLine("Enter the serial number of booking");
                int index = Int32.Parse(Console.ReadLine());
                
                await Service.Delete(bookings.ElementAt(index - 1).Id);
                Console.WriteLine("Booking was deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete booking. Exception: {ex.Message}");
            }
        }
    }
}