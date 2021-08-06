using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoBadges_Repo;

namespace KomodoBadges_Repo
{
	public class BadgeRepository
	{   //persisting object
		public Dictionary<int, List<string>> _listOfAllBadgesAndDoors = new Dictionary<int, List<string>>();   //dictionary field made up of the badge objects and each of their corresponding doors

		//create
		public void AddBadgeToRepo(int id, List<string> newDoors) //add badge to list
		{
			_listOfAllBadgesAndDoors.Add(id, newDoors);  //here we add badge to the dictionary with key value pairs of id, and list of doors
		}

		//read
		public Dictionary<int, List<string>> GetBadgeList()   //returns whole list
		{
			return _listOfAllBadgesAndDoors;
		}

		//update
		public bool UpdateDoorsOnExistingBadge(int originalID, List<string> newDoors) //takes in original id key, plus new door list value
		{
			if (_listOfAllBadgesAndDoors.ContainsKey(originalID) == true)  //if the dict. contains the original id
			{
				_listOfAllBadgesAndDoors[originalID] = newDoors; //then the value equals the new door list
				return true;  //update successful
			}
			else
			{
				return false;  //did not contain original id
			}
		}

		//delete
		public bool RemoveBadgeFromList(int id)
		{

			if (_listOfAllBadgesAndDoors.ContainsKey(id) == true)   //check if the repo of badges contains the id to remove
			{
				_listOfAllBadgesAndDoors.Remove(id);  //removes that badge
				return true;  //returns true if it was removed
			}
			else
			{
				return false;  //dictionary does not contain key id
			}
		}
	}
}