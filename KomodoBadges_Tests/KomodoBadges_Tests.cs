using KomodoBadges_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoBadges_Repo
{
	[TestClass]
	public class KomodoClaims_MethodTests
	{
		private BadgeRepository _repo;  //intitalizing
		private Badge _badge; //initiallizing

		[TestInitialize] //this will run before each test
		public void Arrange()
		{
			_repo = new BadgeRepository();  //new instance of repo field, access to all repo methods
			_badge = new Badge(1913, "Agent");  //new badge object with id and name
			List<string> _doors = new List<string>() {"A9", "B6", "C3"} ; 

			_repo.AddBadgeToRepo(_badge.BadgeID, _doors);  //added content to repo, now accessable

		}

		//create method
		[TestMethod]
		public void AddBadgeToRepo_ShouldGetNotNull()
		{
			//Arrange --> setting up field
			Badge creatorBadge = new Badge(); 
			creatorBadge.BadgeID = 3399; 
			BadgeRepository repository = new BadgeRepository();
			List<string> _creatorDoors = new List<string>() { "A3", "B6", "C9" };


			//Act  --> run code we want to test
			repository.AddBadgeToRepo(creatorBadge.BadgeID, _creatorDoors);

			//Assert -->  Use the assert to verify expected outcome
			Assert.IsNotNull(repository);  
		}

		//read test
		[TestMethod]
		public void GetBadgeList_ShouldNotGetNull()
		{
			//our "Act" is nested within our "assert"
			Assert.IsNotNull(_repo.GetBadgeList());
		}
		
		//update test
		[TestMethod]
		public void UpdateExistingContent_ShouldReturnTrue()
		{
			// Arrange
			//Test initialized at top of class
			List<string> updatedDoors = new List<string>() { "C8", "C4", "C2" };

			//act   //we pass the badge id and list of door access 
			bool updateResult = _repo.UpdateDoorsOnExistingBadge(_badge.BadgeID, updatedDoors); 

			//Assert
			Assert.IsTrue(updateResult);  //true if not null
		}

		//delete test
		[TestMethod]
		public void DeleteBadge_ShouldReturnTrue()
		{	//arrange
			//test initializer

			//act
			bool deleteResult = _repo.RemoveBadgeFromList(_badge.BadgeID);   //we pass the badge's id into the remove method

			//assert
			Assert.IsTrue(deleteResult);  //true if not null
		}
	}
}