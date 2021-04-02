using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgingSystem.Data
{
    public class Badges
    {
        public string BadgeID { get; set; }
        //I have to loop through this list in order to see this data 
        public List<string> DoorAccess { get; set; } = new List<string>();


        public Badges() { }

        public Badges(string badgesID, List<string> doorAccess)
        {
            BadgeID = badgesID;
            DoorAccess = doorAccess;

        }

    }
}
