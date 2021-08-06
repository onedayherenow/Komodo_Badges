using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoBadges_Repo;

namespace KomodoBadges_Repo
{		public class Badge
	{
		//properties
		public int BadgeID { get; set; }
		public List<string> Doors { get; set; }  //a list of doors

		public string BadgeName;

		public Badge() { }
		public Badge(int badgeID, string badgeName)  
		{
			Doors = new List<string>();  //instantiates the list for new doors to be added
			BadgeID = badgeID;
			BadgeName = badgeName;
		}

		//methods
		public List<string> DoorListAddition(List<string> newDoors)   //we can add a list of new doors to our badge door list
		{
			Doors.AddRange(newDoors);  //adds these doors to the end of the list
			return Doors;  //return the list of doors after adding newDoors
		}
	}
}
