using CafeMenu.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenuRepository
{
    public class MenuRepo
    {
        private List<Menu> _menuDataBase = new List<Menu>();
        //CRUD but with no update

        //Create
        public bool AddContnetToMenuDataBase(Menu menu)
        {
            int statingCount = _menuDataBase.Count;
            _menuDataBase.Add(menu);
            bool wasAdded = (_menuDataBase.Count > statingCount) ? true : false;
            return wasAdded;
        }
        //Read
        public List<Menu> GetMenuDataBase()
        {
            return _menuDataBase;
        }
        public Menu GetMenuByMealNumber(int mealNumber)
        {
                     
            foreach (Menu menu in _menuDataBase)
            {
                if (menu.MealNumber == mealNumber)
                {
                    return menu;
                }
            }
            return null;
        }
        public Menu GetMenuByMealName(string mealName)
        {


            foreach(Menu menu in _menuDataBase)
            {
              
                if(menu.MealName == mealName)
                {
                        return menu;
                }
            }
            return null;
        }
        public Menu GetMenuByIngredeants(string ingredient)
        {
            foreach (Menu menu in _menuDataBase)
            {
                if (menu.Ingredients == ingredient)
                {
                    return menu;
                }
            }
            return null;
        }
        public Menu GetMeueByMealDescription(string mealDescription)
        {

            foreach (Menu menu in _menuDataBase)
            {
                if (menu.MealDescription == mealDescription)
                {
                    return menu;
                }
            }
            return null;
        }

        public bool DeleteMeal(Menu menu)
        {
            throw new NotImplementedException();
        }

        public Menu GetMenuByMealPrice(Double mealPrice)
        {

            foreach(Menu menu in _menuDataBase)
            {
                if (menu.MealPrice == mealPrice)
                {
                   return menu;
                }
            }
            return null;
        }

        //Delete
        public bool DeleteMeal(string mealName)
        {
            foreach (Menu menu in _menuDataBase)
            {
                if (menu.MealName == mealName)
                {
                    _menuDataBase.Remove(menu);
                    return true;
                }
            }
            return false;
        }
      

    }



}
