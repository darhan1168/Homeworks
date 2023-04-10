using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Enums;
using Core.Models;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class MemberConsoleManager : ConsoleManager<IMemberService, Member>, IConsoleManager
    {
        public MemberConsoleManager(IMemberService memberService) : base(memberService)
        {
        }

        public override async Task PerformOperationsAsync()
        {
            Dictionary<string, Func<Task>> actions = new Dictionary<string, Func<Task>>
            {
                { "1", DisplayAllMembersAsync },
                { "2", AddMemberAsync },
                { "3", UpdateMemberAsync },
                { "4", DeleteMemberAsync },
            };

            while (true)
            {
                Console.WriteLine("\nMember operations:");
                Console.WriteLine("1. Display all members");
                Console.WriteLine("2. Add a new member");
                Console.WriteLine("3. Update a member");
                Console.WriteLine("4. Delete a member");
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
        
        public async Task DisplayAllMembersAsync()
        {
            try
            {
                var members = await Service.GetAll();

                if (members is null)
                {
                    throw new Exception("Members are not found");
                }
                
                int index = 1;

                foreach (var member in members)
                {
                    Console.WriteLine($"{index} - Firstname: {member.FirstName}, Lastname: {member.LastName}, Email: {member.Email}, Subscription type: {member.SubscriptionType}, Phone number: {member.PhoneNumber}, DateOfBirth: {member.DateOfBirth}, SubscriptionStartDate: {member.SubscriptionStartDate}, SubscriptionEndDate: {member.SubscriptionEndDate}, Id: {member.Id},");
                    index++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to display all members. Exception: {ex.Message}");
            }
        }

        public async Task AddMemberAsync()
        {
            try
            {
                Console.WriteLine("Enter firstname");
                var firstName = Console.ReadLine();

                if (firstName is null)
                {
                    throw new Exception("Firstname is null");
                }
                
                Console.WriteLine("Enter lastname");
                var lastName = Console.ReadLine();

                if (lastName is null)
                {
                    throw new Exception("LastName is null");
                }
                
                Console.WriteLine("Enter day of birthday");
                string format = "dd.MM.yyyy";
                DateTime dateOfBirth = DateTime.ParseExact(Console.ReadLine(), format, null);

                Console.WriteLine("Enter your email");
                var email = Console.ReadLine();

                MailAddress mailAddress;
                if (!MailAddress.TryCreate(email, out mailAddress))
                {
                    throw new Exception("Email is not correct");
                }

                Console.WriteLine("Enter phone number");
                var phoneNum = Console.ReadLine();

                if (phoneNum is null)
                {
                    throw new Exception("Phone number is null");
                }
                
                Console.WriteLine("Enter type (1 - Monthly, 2 - Quarterly, 3 - Annual,)");
                var answerType = Console.ReadLine();
                SubscriptionType type;
                DateTime subscriptionStartDate = DateTime.Now;
                DateTime subscriptionEndDate;
                
                if (answerType == "1")
                {
                    subscriptionEndDate = DateTime.Now.AddMonths(1);
                    type = SubscriptionType.Monthly;
                }
                else if (answerType == "2")
                {
                    subscriptionEndDate = DateTime.Now.AddMonths(3);
                    type = SubscriptionType.Quarterly;
                }
                else if (answerType == "3")
                {
                    subscriptionEndDate = DateTime.Now.AddYears(1);
                    type = SubscriptionType.Annual;
                }
                else
                {
                    throw new Exception("Incorrect answer about type");
                }

                await Service.RegisterMember(new Member()
                {
                    Id = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth,
                    Email = email,
                    PhoneNumber = phoneNum,
                    SubscriptionType = type,
                    SubscriptionStartDate = subscriptionStartDate,
                    SubscriptionEndDate = subscriptionEndDate,
                    IsActive = true
                });
                
                Console.WriteLine("Member succeeded added");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to create member. Exception: {ex.Message}");
            }
        }

        public async Task UpdateMemberAsync()
        {
            try
            {
                Console.WriteLine("Enter id of member, which you need to update");
                var member = await Service.GetById(Guid.Parse(Console.ReadLine()));
            
                Console.WriteLine("Enter what yoy need to change (1 - Lastname, 2 - Firstname)");
                var answerUpdate = Console.ReadLine();

                if (answerUpdate == "1")
                {
                    Console.WriteLine("Enter new lastname");
                    var newLastName = Console.ReadLine();
                    member.LastName = newLastName;
                }
                else if (answerUpdate == "2")
                {
                    Console.WriteLine("Enter new firstname");
                    var newFirstName = Console.ReadLine();
                    member.FirstName = newFirstName;
                }
                else
                {
                    throw new Exception("Incorrect answer");
                }

                await Service.Update(member.Id, member);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to update member. Exception: {ex.Message}");
            }
        }

        public async Task DeleteMemberAsync()
        {
            try
            {
                Console.WriteLine("Enter your member id");
                Guid memberId = Guid.Parse(Console.ReadLine());
                
                await Service.Delete(memberId);
                Console.WriteLine("Trainer was deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete member. Exception: {ex.Message}");
            }
        }
    }
}