using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoBadges_Repo;

namespace KomodoBadges_Repo
{

		public class Badges
	{
		//properties
		public int BadgeID { get; set; }
		public List<string> Doors { get; set; }

		public string BadgeName;

		public Badges() { }
		public Badges(int badgeID, string badgeName)
		{
			Doors = new List<string>();
			BadgeID = badgeID;
			BadgeName = badgeName;
		}

		//methods
		public List<string> DoorListAddition(List<string> newDoors)   //we can add a list of new doors to our badge door list
		{
			Doors.AddRange(newDoors);  
			return Doors;
		}

		
	}
}
