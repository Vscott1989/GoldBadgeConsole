using CafeMenu.Data;
using CafeMenuRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenu_UI
{
    public class Program_UI
    {
        private readonly MenuRepo _menuRepo = new MenuRepo();

        public void Run()
        {
            Seed();
            StartApp();
        }
        
        private void StartApp()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("\t\t\t\t\t\t  **CAFE MENU**\n" +
                    "\t\t\t\t\t\t1. Create New Item\n" +
                    "\t\t\t\t\t\t2. View All Items \n" +
                    "\t\t\t\t\t\t3. View Meal By Number\n" +
                    "\t\t\t\t\t\t4. Delete\n" +
                    "\t\t\t\t\t\t5. Close App");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateNewItem();
                        break;
                    case "2":
                        ViewAllItems();
                        break;
                    case "3":
                        ViewMealByNumber();
                        break;
                    case "4":
                        Delete();
                        break;
                    case "5":
                        isRunning = false;
                        Console.WriteLine("thank You, Press any key to Continue....");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Please Enter Number option 1-5\n" +
                            "Press any key to Continue...");
                        Console.ReadKey();
                        break;

                }

            }
        }

        private void Delete()
        {
            Console.Clear();

            Console.WriteLine("What Item would You like to Delete?");
            string userInputDeleteMealFromMenu = Console.ReadLine();

            bool isSuccessful = _menuRepo.DeleteMeal(userInputDeleteMealFromMenu);
            if (isSuccessful)
            {
                Console.WriteLine("Meal was Deleted from Menu");

            }
            else
            {
                Console.WriteLine("Meal was NOT Deleted from menu");
            }
            Console.ReadKey();
        }

        private void ViewMealByNumber()
        {
            Console.Clear();
            
            Console.WriteLine("Please Enter Meal Number:");
            int userInputMealbyNumber =int.Parse(Console.ReadLine());
            Menu menu = _menuRepo.GetMenuByMealNumber(userInputMealbyNumber);

            if (menu == null)
            {
                Console.WriteLine($"the menu Item with name: {userInputMealbyNumber}Dose NOt Exist");
            }
            else
            {
                DisplayMenuInfo(menu);
            }
            Console.ReadKey();
        }

        private void ViewAllItems()
        {
            Console.Clear();

            List<Menu> mealMenus = _menuRepo.GetMenuDataBase();
            foreach (Menu menu in mealMenus)
            {
                DisplayMenuInfo(menu);
                Console.WriteLine("------------------------------------------------");
            }

            Console.ReadKey();

        }
        private void DisplayMenuInfo(Menu menu)
        {
            
            Console.WriteLine($"Meal Number: {menu.MealNumber}\n" +
                $"Meal Name: {menu.MealName}\n" +
                $"Ingredients: {menu.Ingredients}\n" +
                $"Meal Description: {menu.MealDescription}\n" +
                $"Meal Price: {menu.MealPrice}\n");
        }

        private void CreateNewItem()
        {
            Console.Clear();

            Menu menu = new Menu();
            Console.WriteLine("\t\t\t\t\t**Welcome To Create new Meal Page!!**");

            Console.WriteLine("Please Enter the Meal Number:");
            int userInputMealNumer = int.Parse(Console.ReadLine());
            menu.MealNumber = userInputMealNumer;

            Console.WriteLine("Please Enter Meal Name:");
            string userInputMenuName = Console.ReadLine();
            menu.MealName = userInputMenuName;


            Console.WriteLine("Please Enter Meal Description:");
            string userInputMealDescription = Console.ReadLine();
            menu.MealDescription = userInputMealDescription;

            Console.WriteLine("Please Enter Meal Price:");
            double userInputMealPrice = double.Parse(Console.ReadLine());
            menu.MealPrice = userInputMealPrice;

            Console.WriteLine("Please enter Ingredents: ");
            string userInputIngredient = Console.ReadLine();
            menu.Ingredients = userInputIngredient;

            _menuRepo.AddContnetToMenuDataBase(menu);
            Console.ReadKey();
        }

        private void Seed()
        {
            Menu menuA = new Menu(1, "Chiken Sandwich", "Lettus_Meyo", "chicken sandwichwith and chips", 5.49);
            Menu menuB = new Menu(2, "Club Bacon Sandwich", "Tomatos_Lettus", "Bacon sandwichwith and chips", 5.99);
            Menu menuC = new Menu(3, "Ham Sandwich", "Tomatos_Lettus_Meyo", "Hams sandwichwith and chips", 5.59);
            Menu menuD = new Menu(4, "Turkey Sandwich", "Tomatos_Meyo", "Turkey sandwichwith and chips", 5.39);

            _menuRepo.AddContnetToMenuDataBase(menuA);
            _menuRepo.AddContnetToMenuDataBase(menuB);
            _menuRepo.AddContnetToMenuDataBase(menuC);
            _menuRepo.AddContnetToMenuDataBase(menuD);

        }
    }
}
