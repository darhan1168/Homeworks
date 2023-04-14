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
    public class MemberConsoleManager : ConsoleManager<IMemberService, Member>, IConsoleManager<Member>
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
                Console.Clear();
                
                var members = await Service.GetAll();

                if (members.Count == 0)
                {
                    throw new Exception("Members are not added yet");
                }
                
                if (members is null)
                {
                    throw new Exception("Members are not found");
                }
                
                int index = 1;

                foreach (var member in members)
                {
                    Console.WriteLine($"{index} - Firstname: {member.FirstName}, Lastname: {member.LastName}, Email: {member.Email}, Subscription type: {member.SubscriptionType}, Phone number: {member.PhoneNumber}, DateOfBirth: {member.DateOfBirth}, SubscriptionStartDate: {member.SubscriptionStartDate}, SubscriptionEndDate: {member.SubscriptionEndDate}");
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
                Console.Clear();
                
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
                Console.Clear();
                
                var members = await Service.GetAll();
                
                if (members is null)
                {
                    throw new Exception("Members are not added yet");
                }

                await DisplayAllMembersAsync();
                
                Console.WriteLine("Enter the serial number of member");
                int index = Int32.Parse(Console.ReadLine());
                var member = members[index - 1];
            
                Console.WriteLine("Enter what yoy need to change (1 - Firstname, 2 - Lastname, 3 - DateOfBirth, 4 - Email, 5 - Phone number, 6 - SubscriptionType)");
                var answerUpdate = Console.ReadLine();

                switch (answerUpdate)
                {
                    case "1":
                        Console.WriteLine("Enter new firstname");
                        var newFirstName = Console.ReadLine();
                        member.FirstName = newFirstName;
                        break;
                    case "2":
                        Console.WriteLine("Enter new lastname");
                        var newLastName = Console.ReadLine();
                        member.LastName = newLastName;
                        break;
                    case "3":
                        Console.WriteLine("Enter new DateOfBirth");
                        string format = "dd.MM.yyyy";
                        DateTime newDateBrth = DateTime.ParseExact(Console.ReadLine(), format, null);
                        member.DateOfBirth = newDateBrth;
                        break;
                    case "4":
                        Console.WriteLine("Enter new Email");
                        var newEmail = Console.ReadLine();
                        member.Email = newEmail;
                        break;
                    case "5":
                        Console.WriteLine("Enter new Phone number");
                        var newPhoneNum = Console.ReadLine();
                        member.PhoneNumber = newPhoneNum;
                        break;
                    case "6":
                        Console.WriteLine("Enter new type (1 - Monthly, 2 - Quarterly, 3 - Annual,)");
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
                        
                        member.SubscriptionStartDate = subscriptionStartDate;
                        member.SubscriptionEndDate = subscriptionEndDate;
                        member.SubscriptionType = type;
                        break;
                    default:
                        throw new Exception("Incorrect answer");
                }

                await UpdateAsync(member.Id, member);
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
                Console.Clear();
                
                var members = await Service.GetAll();
                
                if (members is null)
                {
                    throw new Exception("Members are not added yet");
                }

                await DisplayAllMembersAsync();
                
                Console.WriteLine("Enter the serial number of member");
                int index = Int32.Parse(Console.ReadLine());
                var member = members[index - 1];

                await DeleteAsync(member.Id);
                Console.WriteLine("Member was deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete member. Exception: {ex.Message}");
            }
        }
    }
}