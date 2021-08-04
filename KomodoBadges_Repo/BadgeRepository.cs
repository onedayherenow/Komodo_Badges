using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoBadges_Repo;

namespace KomodoBadges_Repo
{
	public class BadgeRepository
	{
		public Dictionary<int, List<string>> _listOfAllBadgesAndDoors = new Dictionary<int, List<string>>();   //dictionary field made up of the badge objects
		 //field usables in all crud methods, they can all use the same list in all methods, persisting object
		//the methods need to be used outside, public
		//anything with an underscore and camelcase is a field

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



		//helper method
		//public List<string> GetDoorsById(Dictionary<int, List<string>> dictionary)   //returns the list of doors
		//{
		//	for (int Dictionary.KeyCollection in dictionary)  //for each object in list
		//	{
		//		if (_listOfAllBadgesAndDoors.ContainsKey(id) == true)     //helper methods which get with an id
		//		{
		//			return dictonary.ValueCollection;  //if equals the id of object requested, then return
		//		}
		//	}
		//	return null; //if we find it we return, if not return null
		//}

	}
}