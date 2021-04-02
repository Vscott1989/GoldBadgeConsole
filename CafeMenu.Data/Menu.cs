using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenu.Data
{
    public class Menu
    {
        //POCO
        
        
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Ingredients { get; set; }

        public string MealDescription { get; set; }
        public Double MealPrice { get; set; }


        public Menu(){ }

        public Menu(int mealNumber, string mealName, string ingredients,  string mealDescription, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Ingredients = ingredients;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
        }
    }
}
