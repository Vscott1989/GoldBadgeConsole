using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsDepartment.Data
{
    public class Claims
    {
        //POCO
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public string DateOfIncident { get; set; }
        public string DateOfClaim { get; set; }
        public bool IsValid { get; set; }


        //Constructors
        public Claims() { }

        public Claims(int claimID, ClaimType claimType, string description, double claimAmount, string dateOfIncident, string dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
            
        }
    }
}
