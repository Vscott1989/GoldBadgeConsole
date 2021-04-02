using BadgingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgingSystemRepo
{
    public class BadgesRepo
    {
        protected readonly Dictionary<int, Badges> _badgeDatabase = new Dictionary<int, Badges>();
        int _count = 0;

        public bool AddToDictionary(Badges badges)
        {
            _count++;
            string countToString = _count.ToString();
             badges.BadgeID= countToString;
            _badgeDatabase.Add(_count, badges);
            return true;
        }

        public Dictionary<int, Badges> GetAllBadges()
        {
            return _badgeDatabase;
        }

        public Badges GetBadgeByKey(int keyID) 
        {
            foreach (var pair in _badgeDatabase)
            {
                if (pair.Key == keyID)
                {
                    return pair.Value;
                }
            }
            return null;
        }

        public bool UpdateBadges(int oldBadgesKey, Badges newBadges)
        {
            Badges oldBadges = GetBadgeByKey(oldBadgesKey);
            if (oldBadges == null)
            {
                return false;
            }
            else
            {
                oldBadges.BadgeID = newBadges.BadgeID;
                oldBadges.DoorAccess = newBadges.DoorAccess;
                return true;
            }
        }

        public bool DeleteExistingBadges(int badgeKeyID)
        {
            foreach (var pair in _badgeDatabase)
            {
                if (pair.Key == badgeKeyID)
                {
                    _badgeDatabase.Remove(pair.Key);
                    return true;
                }
            }
            return false;
        }

    }
}
