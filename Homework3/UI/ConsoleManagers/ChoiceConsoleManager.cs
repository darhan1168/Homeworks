using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using BLL.Services;
using Core.Models;
using DAL.Abstractions.Interfaces;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class ChoiceConsoleManager : IConsoleManager
    {
        private readonly BookingConsoleManager _bookingConsoleManager;
        private readonly ClassConsoleManager _classConsoleManager;
        private readonly MemberConsoleManager _memberConsoleManager;
        private readonly SubscriptionConsoleManager _subscriptionConsoleManager;
        private readonly TrainerConsoleManager _trainerConsoleManager;
        private readonly UserConsoleManager _userConsoleManager;

        public ChoiceConsoleManager(ISubscriptionService subscriptionService, IMemberService memberService, IBookingService bookingService, IClassService classService, ITrainerService trainerService, IUserService userService)
        {
            _bookingConsoleManager = new BookingConsoleManager(bookingService, new ClassConsoleManager(classService), new MemberConsoleManager(memberService));
            _classConsoleManager = new ClassConsoleManager(classService);
            _memberConsoleManager = new MemberConsoleManager(memberService);
            _subscriptionConsoleManager = new SubscriptionConsoleManager(subscriptionService, new MemberConsoleManager(memberService));
            _trainerConsoleManager = new TrainerConsoleManager(trainerService);
            _userConsoleManager = new UserConsoleManager(userService);
        }
    }
}