using BadgingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Badges> _badgeDict = new Dictionary<int, Badges>();

            //KEY VALUE PAIR
            //IN THIS CASE THE INT points to the BADGE
            _badgeDict.Add(1,
                new Badges
                {
                    BadgeID="15101-a-22bi-2105",
                    DoorAccess=new List<string>
                    {
                        "A1",
                        "B3"
                    }
                });

            _badgeDict.Add(2,
               new Badges
               {
                   BadgeID = "15101-a-22bi",
                   DoorAccess = new List<string>
                   {
                        "A1",
                        "B3",
                        "C1"
                   }
               });

            _badgeDict.Add(3,
               new Badges
               {
                   BadgeID = "15101-a-22bi-2105",
                   DoorAccess = new List<string>
                   {
                        "A1",
                        "B3",
                        "Z"
                   }
               });

            _badgeDict.Add(4,
               new Badges
               {
                   BadgeID = "15101-a-22bi-2105",
                   DoorAccess = new List<string>
                   {
                        "A1",
                        "B3",
                         "C1",
                         "Z",
                         "SS-275"

                   }
               });

            //Lets Loop threw this pair
            foreach (var pair in _badgeDict)
            {
                Console.WriteLine(pair.Key);
                Console.WriteLine(pair.Value.BadgeID);
                foreach (var door in pair.Value.DoorAccess)
                {
                    Console.WriteLine(door);
                }
                Console.WriteLine();
            }

            //loop threw by the key
            foreach (var keyId in _badgeDict.Keys)
            {
                Console.WriteLine(keyId);
            }

            //loop by value

            foreach (var badge in _badgeDict.Values)
            {
                Console.WriteLine(badge.BadgeID);
                foreach (var door in badge.DoorAccess)
                {
                    Console.WriteLine(door);
                }
                Console.WriteLine();

            }

            //....Exploring Further.....
            void GiveMeBadgeData(int KeyId)
            {
                Console.Clear();
                foreach (var pair in _badgeDict)
                {
                    if (pair.Key == KeyId)
                    {
                        Console.WriteLine(pair.Key);
                        Console.WriteLine(pair.Value.BadgeID);
                        foreach (var door in pair.Value.DoorAccess)
                        {
                            Console.WriteLine(door);
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("???");
                    }
                }
            }

            Console.WriteLine("Please input a KeyId");
            int userInputKeyId = int.Parse(Console.ReadLine());
            GiveMeBadgeData(userInputKeyId);
            Console.ReadKey();
        }
    }
}
