using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Data
{
    public class Badges
    {
        public string BadgeID { get; set; }
        public string DoorAccess { get; set; }


        public Badges(){ }
         
        public Badges(string badgesID, string doorAccess)
        {
            BadgeID = badgesID;
            DoorAccess = doorAccess;

        }

               

        
       
    }
}
