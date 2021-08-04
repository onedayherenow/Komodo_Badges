//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using KomodoBadges_Repo;

//namespace KomodoBadges_Repo
//{

	//POCO -- Plaing old Csharp object
	//Simple object that holds data
//	public class Badge
//	{
//		//properties
//		public int BadgeID { get; set; }


//		//constructors

//		public Badge() { }

//		//cant go out using title, can only go in,, scope
//		public Badge(int badgeID)
//		{
//			BadgeID = badgeID;
//		}

//	}

	

//	public class SecurityBadge : Badge
//	{
//		public List<string> Doors { get; set; }

//		public string BadgeName = "Security"; 

//		public SecurityBadge(){}
//		public SecurityBadge(int badgeID)
//			: base(badgeID)
//		{
//			Doors = new List<string>();
//			BadgeID = badgeID;
//		}

//	}

//	public class AgentBadge : Badge
//	{
//		public List<string> Doors { get; set; }

//		public string BadgeName = "Security";

//		public AgentBadge() { }
//		public AgentBadge(int badgeID)
//			: base(badgeID)
//		{
//			Doors = new List<string>();

//		}
//	}

//	public class DeveloperBadge : Badge
//	{
//		public List<string> Doors { get; set; }

//		public string BadgeName = "Security";

//		public DeveloperBadge() { }
//		public DeveloperBadge(int badgeID)
//			: base(badgeID)
//		{
//			Doors = new List<string>();

//		}

//		////methods
//		//public string DisplayDoors(List<string> list)
//		//{

//		//	foreach (string door in list)
//		//	{
//		//		return door;
//		//	}
//		//}

//	}

//}
