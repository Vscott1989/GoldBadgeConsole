using BadgingSystem.Data;
using BadgingSystemRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BadgingSystemTest
{
    [TestClass]
    public class BadgesTest
    {
        [TestMethod]
        public void AddToDirectory_ShouldBeCorrect()
        {
            Badges badges = new Badges();
            BadgesRepo repo = new BadgesRepo();

            bool addResult = repo.AddToDictionary(badges);
            Assert.IsTrue(addResult);
        }



    }
}
