using CafeMenu.Data;
using CafeMenuRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CafeMenuTests
{
    [TestClass]
    public class CafeMenuDataTest
    {
       

        [TestMethod]
        public void AddMenuToDataBase_ShouldBeCorrectBool()
        {
            Menu menu = new Menu();
            MenuRepo repo = new MenuRepo();

            bool addResults = repo.AddContnetToMenuDataBase(menu);
            Assert.IsTrue(addResults);

        }
        [TestMethod]
        public void SetMealNumber_ShouldBeCorrectInt()
        {
            Menu menu = new Menu();

            menu.MealNumber = 2;

            int expected = 2;
            int actual = menu.MealNumber;

            Assert.AreEqual(expected, actual);
        }

        



    }
}
