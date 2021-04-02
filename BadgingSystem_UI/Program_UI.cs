using BadgingSystem.Data;
using BadgingSystemRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgingSystem_UI
{
    public class Program_UI
    {
        private readonly BadgesRepo _badgeRepo = new BadgesRepo();

        public void Run()
        {
            SeedBadgeList();
            RunApp();

        }
        private void RunApp()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("\t\t\t   **Hello Security Admin, What would you like to do?**\n" +
                    "\t\t\t\t\t1. Add a Badge \n" +
                    "\t\t\t\t\t2. Edit Badge\n" +
                    "\t\t\t\t\t3. List All Badges\n" +
                    "\t\t\t\t\t4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {

                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        isRunning = false;
                        Console.WriteLine("Thank You, Press any key to Continue..");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Invalid please enter a number 1 - 4");
                        Console.ReadLine();
                        break;
                }
            }

        }


        private void AddABadge()
        {
            Console.Clear();
            Badges badges = new Badges();

            Console.WriteLine("\t\tWhat is the number on the badge: ");
            string userInputBadgeID = Console.ReadLine();
            badges.BadgeID = userInputBadgeID;


            bool continueAdd = true;
            while (continueAdd)
            {

                Console.WriteLine("\t\tList a Door that it needs access to: ");
                string door = Console.ReadLine();
                badges.DoorAccess.Add(door);


                Console.WriteLine("\t\tDo you want to add another Door? (y/n)");
                string entry = Console.ReadLine().ToLower();
                if (entry == "n")
                {
                    continueAdd = false;
                }

            }

            bool isSuccessful =_badgeRepo.AddToDictionary(badges);

            if (isSuccessful)
            {
                Console.WriteLine("Created new Badge");
            }
            else
            {
                Console.WriteLine("FAILED!!!");
            }


            Console.ReadKey();

        }
        private void EditBadge()
        {
            Console.Clear();

            Console.WriteLine("What is the badge Number to Update: ");
            int userInputBadgeNumber = int.Parse(Console.ReadLine());


            Badges updateBadge = _badgeRepo.GetBadgeByKey(userInputBadgeNumber);

            

            Console.WriteLine("What would you like to do\n" +
                "1. Remove a Door\n" +
                "2. Add a door");
            string userInputDoorAction = Console.ReadLine();

            if (userInputDoorAction == "1")
            {
                Console.WriteLine("which door would you like to remove? ");
                string userInputRemoveDoor = Console.ReadLine();
                updateBadge.DoorAccess.Remove(userInputRemoveDoor);
                
            }
            else if(userInputDoorAction== "2")
            {
                Console.WriteLine("which door would you like to add?");
                string userInputAddDoor = Console.ReadLine();
                updateBadge.DoorAccess.Add(userInputAddDoor);

            }
            else
            {
                Console.WriteLine("Sorry Invalid");
                Console.ReadKey();
                RunApp();
            }

            bool isSuccessful = _badgeRepo.UpdateBadges(userInputBadgeNumber, updateBadge);

            if (isSuccessful)
            {
                Console.WriteLine("Update Successful!");
            }
            else
            {
                Console.WriteLine("Sorry Update Failed");
            }

            Console.ReadKey();
        }
        private void ListAllBadges()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t**LIST OF BADGES**");

            foreach (var badges in _badgeRepo.GetAllBadges())
            {
                Console.WriteLine("");
                Console.WriteLine($"\tKeys{badges.Key}\n" +
                    $"   Badge ID #: {badges.Value.BadgeID}\n");
                foreach (var door in badges.Value.DoorAccess)
                {
                    Console.WriteLine(door);
                }
                Console.WriteLine("-----------------------");
            }

            Console.ReadKey();
        }

        private void SeedBadgeList()
        {



            Badges badgeA = new Badges("12345", new List<string> { "A1", "B3" });
            Badges badgeB = new Badges("22345", new List<string> { "A1", "B3", "C1" });
            Badges badgeC = new Badges("32345", new List<string> { "A1", "B8", "F8", "D5" });


            _badgeRepo.AddToDictionary(badgeA);
            _badgeRepo.AddToDictionary(badgeB);
            _badgeRepo.AddToDictionary(badgeC);

        }



    }
}
