using ClaimsDepartment.Data;
using ClaimsDepartmentRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimsDepartmentTests
{
    [TestClass]
    public class ClaimsDepartmentDataTest
    {
        [TestMethod]
        public void AddToDataBase_ShouldBeCorrectBool()
        {
            Claims claims = new Claims();
            ClaimsRepo repository = new ClaimsRepo();

            bool addResult = repository.AddClaimToDataBase(claims);

            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void SetClamiID_ShouldSetCorrectInt()
        {
            Claims claims = new Claims();

            claims.ClaimID = 3;

            int expected = 3;
            int actual = claims.ClaimID;

            Assert.AreEqual(expected, actual);

        }



    }
} 
