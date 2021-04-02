using ClaimsDepartment.Data;
using ClaimsDepartmentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsDepartment_UI
{
    public class Program_UI
    {
        private readonly ClaimsRepo _claimsRepo = new ClaimsRepo();
        public void Run()
        {
            Seed();
            RunClaimsList();
        }
        private void RunClaimsList()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("Enter number option you Would like to Select:\n" +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter new Claim\n" +
                    "5. Exit\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
;
                    case "5":
                        isRunning = false;
                        Console.WriteLine("Thenk You, Press any Key to Continue");
                        Console.ReadKey();
                        break;              
                    
                    default:
                        Console.WriteLine("Please Enter valid number 1 through 4\n" +
                            "Press any key to Continue.....");
                        Console.ReadKey();
                        break;
                }


            }
        }

        private void EnterNewClaim()
        {
            Console.Clear();

            Claims claims = new Claims();

            Console.WriteLine("Enter Claim ID:");
            int userClaimID = int.Parse(Console.ReadLine());
            claims.ClaimID = userClaimID;

            Console.WriteLine("Select Claim Type: \n" + 
                 "1. Car\n" +
                 "2. House\n" +
                 "3. Theft\n");
            string claimType = Console.ReadLine();
            switch (claimType)
            {
                case "1":
                    claims.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    claims.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    claims.ClaimType = ClaimType.Theft;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Ender a Claim Descriptin: ");
            claims.Description = Console.ReadLine();

            Console.WriteLine("Enter Amount of Damage:");
            int userInputDamageAmount = int.Parse(Console.ReadLine());
            claims.ClaimAmount = userInputDamageAmount;

            Console.WriteLine("Enter Date of Accident: ");
            string userInputDateOfAccident = Console.ReadLine();
            claims.DateOfIncident = userInputDateOfAccident;

            Console.WriteLine("Enter Date of Claim: ");
            string userInputDateOfClaim = Console.ReadLine();
            claims.DateOfClaim = userInputDateOfClaim;

            Console.WriteLine("Is this Claim Valid?\n" +
                "Is this Claim over 30 Days mark? (y/n)?:\n ");
            string isValid = Console.ReadLine().ToLower();

            if (isValid == "y")
            {
                claims.IsValid = false;
                
            }
            else
            {
                claims.IsValid = true;
            }

            bool isSuccesfull = _claimsRepo.AddClaimToDataBase(claims);

            if (isSuccesfull)
            {
                Console.WriteLine("Update is Successful");
            }
            else
            {
                Console.WriteLine("FAILED");
            }
            Console.ReadKey();
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();

            Claims claims = _claimsRepo.ViewNextClaim();
            Console.WriteLine("Claim ID \t Type\t Description\t\t\t Amount\t DateOfAccident\t DateOfClaim\t IsValid");
            Console.WriteLine($"\t{claims.ClaimID}\t{claims.ClaimType}\t{claims.Description}\t\t{claims.ClaimAmount}\t{claims.DateOfIncident}\t\t{claims.DateOfClaim}\t\t{claims.IsValid}" );
            Console.ReadLine();

            Console.WriteLine("DO YOU WAT TO DEAL WITH THIS CLAIM? (y/n)");
            string userInputDealWithClaim = Console.ReadLine().ToLower();



            if (userInputDealWithClaim == "y")
            {
                DestributeClaim();            }
            else
            {
                RunClaimsList();
            }
            
        }
        public void DestributeClaim()
        {
            Console.Clear();
            bool isSuccessful = _claimsRepo.DistributeClaim();
            if (isSuccessful)
            {
                Console.WriteLine("Distributed\n" +
                    "Press Any Key to Continue...");

            }
            else
            {
                Console.WriteLine("failed");
            }
            Console.ReadKey();
        }

        private void SeeAllClaims()
        {
            Console.Clear();

            Queue<Claims> claimsInLine = _claimsRepo.GetClaims();
            foreach (Claims claims in claimsInLine)
            {
                Console.WriteLine("Claim ID \t Type\t Description\t\t\t Amount\t DateOfAccident\t DateOfClaim\t IsValid");
                Console.WriteLine($"\t{claims.ClaimID}\t{claims.ClaimType}\t{claims.Description}\t\t{claims.ClaimAmount}\t{claims.DateOfIncident}\t\t{claims.DateOfClaim}\t\t{claims.IsValid}");
            }
            Console.ReadKey();

        
        }

        private void Seed()
        {
           
            Claims claimA = new Claims(1, ClaimType.Car, "Car accident on 465", 400.00,"4/25/18", "4/27/18", true);
            Claims claimB = new Claims(2, ClaimType.Home, "House fire in Kitchen", 4000.00,"4/11/18", "4/12/18", true);
            Claims claimC = new Claims(3, ClaimType.Theft, "Stolen pancakes", 4.00,"4/25/18", "6/01/18", false);

            _claimsRepo.AddClaimToDataBase(claimA);
            _claimsRepo.AddClaimToDataBase(claimB);
            _claimsRepo.AddClaimToDataBase(claimC);
        }
       
    }
}
