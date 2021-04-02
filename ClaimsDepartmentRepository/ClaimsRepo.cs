using ClaimsDepartment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsDepartmentRepository
{
    public class ClaimsRepo
    {
        private readonly Queue<Claims> _claimsDataBase = new Queue<Claims>();


        //CRUD
        //Create
        public bool AddClaimToDataBase(Claims claims)
        {
            _claimsDataBase.Enqueue(claims);
            return true;
        }

        //Read Get all 
        public Queue<Claims> GetClaims()
        {
            return _claimsDataBase;
        }

        public Claims ViewNextClaim()
        {
            return _claimsDataBase.Peek();
        }

        public bool DistributeClaim()
        {
            Claims nextClaimInList = ViewNextClaim();
            if (nextClaimInList== null)
            {
                return false;
            }
            else
            {
                
                _claimsDataBase.Dequeue();
                return true;
            }
        }


    }
}
