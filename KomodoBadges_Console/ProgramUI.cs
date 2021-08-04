using KomodoBadges_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Repo
{
	public class ProgramUI
	{
		//persister field, always existing for whole instance of this UI object
		private BadgeRepository _badgeRepo = new BadgeRepository();


		//method that runs/starts the UI part of application
		public void Run() //public so it can be called through class to method
		{
			SeedContentList();  //fires off right before the menu runs to seed it before anything
			Menu();
		}

		//menu  ---we want these private
		private void Menu()
		{
			bool keepRunning = true;
			while (keepRunning)
			{
				//1. display options to the user
				//We want to be able to build a UI that matches each of our repository methods
				Console.WriteLine("Select a menu option:\n" +
				"1. Add a Badge \n" +
				"2. View All Badges\n" +
				"3. Edit a Badge\n" +
				"4. Exit");

				//2. get the user's input
				string input = Console.ReadLine();

				//3. evaluate user's input and act accordingly
				switch (input)
				{
					case "1":
						//creates a new claim
						CreateNewBadge();
						break;
					case "2":
						//view all content
						DisplayAllBadges();
						break;
					//case "3":
					// //view content by title
					// DisplayContentByTitle();
					// break;
					//case "4":
					// //Update existing content
					// UpdateExistingContent();
					// break;
					case "3":
						//Delete existing content
						UpdateBadge();
						break;
					case "4":
						// exit
						Console.WriteLine("Goodbye");
						keepRunning = false; //breaks the while loop and exits the application
						break;
					default:
						Console.WriteLine("Please enter a valid number");
						break;
				}
				Console.WriteLine("Please press any key to continue...");
				Console.ReadLine();
				Console.Clear();
			}
		}



		//methods that we want to do something but not return anything from this method to menu (void)
		//private so that they can be used inside this class by another method but not from outside this class
		//create new streaming content
		private void CreateNewBadge()
		{
			Badges newBadge = new Badges(); //we declare it first so that we can then use the property of object for user input

			Console.Clear();
			//ID
			Console.WriteLine("Enter the Badge ID for the new badge");
			string idAsString = Console.ReadLine();  //saves user input as a string
			newBadge.BadgeID = int.Parse(idAsString);  //parse that string into int for the ID

			
			//name
			Console.WriteLine("Enter the name for the badge");
			newBadge.BadgeName = Console.ReadLine();       //receives user input and assigns that value as the new badge's name


			//new list for new doors
			List<string> newBadgeDoors = new List<string>();
			newBadgeDoors.Add("");  //so that list is not null

			bool isTrue = true;   //bool for while loop

			while (isTrue)
			{	//ask the user if they would like to add another door
				Console.WriteLine("Would you like to add a door to this badge? (y/n)");
				string doorsUserInput = Console.ReadLine().ToLower();

				if (doorsUserInput == "y")   //if yes
				{
					Console.WriteLine("Enter a door for the new badge");
					string doorToAdd = Console.ReadLine();  //save user input as string
					newBadgeDoors.Add(doorToAdd);  //add to the list of new doors
				}
				else if (doorsUserInput != "y" && doorsUserInput != "n")  //if user didnt enter yes or no
				{
					Console.WriteLine("Please enter either y for yes, or n for no");  //correction
					break;  //break out of the if statement and back into the loop
				}
				else
				{
					continue;
				}

				isTrue = false;  //loop ends
			}

			newBadge.Doors = newBadgeDoors;   //add new doors to badge

			_badgeRepo.AddBadgeToRepo(newBadge.BadgeID, newBadge.Doors);  //add new badge id with new doors to dictionary

		}


		//view current list of badges and doors
		private void DisplayAllBadges()
		{
			Console.Clear(); //clears menu before we see all content

			// we set listOfContent equal to the persistant repository _claimRepo,
			// which is equal to out list inside our repository, which has access to CRUD methods
			Dictionary<int, List<string>> listOfContent = _badgeRepo.GetBadgeList();


			Console.WriteLine("{0,-15} {1,-12}", "Badge ID", "Doors of Access");    //two column names
			foreach(KeyValuePair<int, List<string>> badge in listOfContent)     //for each key value pair of dictionary
			{
				Console.WriteLine("{0,-15} {1,-12}", badge.Key, badge.Value);
			}

			PressAnyKeyToContinue();


		}



		////view existing claim by ID
		//private void UpdateBadge()
		//{
		//	DisplayAllBadges();

		//	//prompt user to give me an ID
		//	Console.WriteLine("\n" +
		//	"Enter ID number of the claim you would like to take care of");

		//	int inputId = GetUserInputAsInt();


		//	//get the user's input
		//	int inputUserId = inputId;

		//	//find content by the id
		//	Claim content = _claimRepo.GetClaimByID(inputId);

		//	// display said content if it isnt null
		//	if (content != null)
		//	{
		//		Console.WriteLine($"Claim ID: {content.ClaimID}\n" +
		//		$"Claim Type: { content.TypeOfClaim}\n" +
		//		$"Description: {content.Description}\n" +
		//		$"Amount: {content.ClaimAmount}\n" +
		//		$"Date of Incident: {content.DateOfIncident}\n" +
		//		$"Date of Claim: {content.DateOfClaim}\n" +
		//		$"Is Valid: {content.IsValid}");
		//	}
		//	else
		//	{ //if not valid id number, then we return to main menu
		//		Console.WriteLine("No Claims with that ID, going back to main menu now");
		//		PressAnyKeyToContinue();
		//		Menu();
		//	}



		//	//next we ask the user if they would like to take care of the claim
		//	Console.WriteLine("\n" +
		//	"Do you want to take care of this claim now (y/n)?");

		//	string userResponse = Console.ReadLine().ToLower();     //we take in the user's input and converts it to lowercase
		//	if (userResponse == "y")  //if yes
		//	{
		//		_claimRepo.RemoveClaimFromList(content.ClaimID);   //we use our CRUD remove method to "take care of" and remove claim by ID number
		//		Console.Clear();
		//		Console.WriteLine("This claim has now been taken care of.\n" +      //output confirmation
		//		"The claim has now been removed from the system.");
		//		PressAnyKeyToContinue();
		//		Menu();   //returns to main menu
		//	}
		//	else
		//	{ //if user input was not y, then we return to the main menu
		//		Console.WriteLine("Ok going back to main menu now");
		//		PressAnyKeyToContinue();
		//		Menu();
		//	}


		//}

		////}

		//update existing content

		private void UpdateExistingContent()
		{
			//display all content
			DisplayAllBadges();

			//ask for the title of the content to update
			Console.WriteLine("Enter the Badge ID for the badge you'd like to update");

			//get that title
			string oldID = Console.ReadLine();

			//we will build a new object
			Badges newBadgeCreation = new Badges(); //we declare it first so that we can then use the property of object for user input





			////title
			//Console.WriteLine("Enter the title for the content");
			//newBadgeCreation.BadgeID = Console.ReadLine();

			////description
			//Console.WriteLine("Enter the description for the content");
			//newBadgeCreation.Description = Console.ReadLine();

			////maturity rating
			//Console.WriteLine("Enter the maturity rating for the content: (G, PG, PG-13, etc");
			//newBadgeCreation.ClaimAmount = Console.ReadLine();

			////star rating
			//Console.WriteLine("Enter the star rating for the content: (5.8, 10, 1.5, etc)");
			//string starsAsString = Console.ReadLine();
			//newBadgeCreation.DateOfIncident = double.Parse(starsAsString);

			////is familly friendly\
			//Console.WriteLine("Is this content family friendly?  (y/n)");
			//string familyFriendlyString = Console.ReadLine().ToLower();

			//if (familyFriendlyString == "y")
			//{
			//	newBadgeCreation.IsValid = true;
			//}
			//else
			//{
			//	newBadgeCreation.IsValid = false;
			//}

			////genretype
			//Console.WriteLine("Enter the genre number: \n" +
			//"1. Horror\n " +
			//"2. RomCom\n " +
			//"3. SciFi\n " +
			//"4. Documentary\n " +
			//"5. Drama\n " +
			//"6. Action");

			//string genreAsString = Console.ReadLine();
			//int genreAsInt = int.Parse(genreAsString);
			//newBadgeCreation.TypeOfClaim = (ClaimType)genreAsInt;    //casting integer into enum by the enum's numerical value

			//verify the update worked
			//repo update method returns a bool if it was updated, if old title was not found (null) then returns false
			bool wasUpdated = _badgeRepo.UpdateDoorsOnExistingBadge(oldID, newBadgeCreation);

			if (wasUpdated)
			{
				Console.WriteLine("Content successfully updated!");
			}
			else
			{
				Console.WriteLine("Could not update content/content to be replaced could not be found.");
			}

		}

		//delete existing content
		private void DeleteExistingClaim()
		{
			DisplayAllBadges();

			//get the id we want to delete
			Console.WriteLine("\nEnter the ID of the Badge you would like to remove.");

			string input = Console.ReadLine();
			int idInput = int.Parse(input);

			//call the delete method
			//calls repository method of content repo and deletes, if it was deleted it returns true, if not then false, so we make it a boolean
			bool wasDeleted = _badgeRepo.RemoveBadgeFromList(idInput);

			//if the content was deleted, say so
			if (wasDeleted)
			{
				Console.WriteLine("The badge was successfully deleted");
			}
			else
			{
				Console.WriteLine("Badge could not be deleted");
			}

			//otherwise state it could not be deleted
		}


		//Seed Method  --> will seed the content list so that we can have some stuff on the list, not an empty one
		private void SeedContentList()
		{
			//three new badge objects
			Badges seed1 = new Badges(1548, "Claims Agent");
			Badges seed2 = new Badges(1738, "Developer");
			Badges seed3 = new Badges(1832, "Supervisor");

			//three new door lists
			List<string> seed1doors = new List<string>() { "B2", "B4" };
			List<string> seed2doors = new List<string>() {"A2", "A14"};
			List<string> seed3doors = new List<string>() { "A2", "B2", "B4", "A14" };

			//we use our repo "create" method to add the key value pair to the existing dictionary repo
			_badgeRepo.AddBadgeToRepo(seed1.BadgeID, seed1doors);
			_badgeRepo.AddBadgeToRepo(seed2.BadgeID, seed2doors);
			_badgeRepo.AddBadgeToRepo(seed3.BadgeID, seed3doors);
		}


		//helper methods

		public int NumberOfDaysBetweeenIncidentAndClaim(DateTime incident, DateTime claim) //returns the int number of days between the incident and claim
		{
			DateTime incidentDate = incident; //incident datetime
			DateTime claimDate = claim;  //claim datetime
			int totalDays = (claimDate.Date - incidentDate.Date).Days;  //the difference between the two dates expressed as an int
			return totalDays;   //return the int
		}

		public bool IsValid(int numDays)  //receives the number of days after incident that claim was made
		{
			if (numDays <= 30)    //if it was 30 days or less
			{
				return true;
			}
			else   //if it was over 30 days
			{
				return false;
			}
		}


		public void DisplayClaims(List<Claim> _allClaims)
		{
			Console.WriteLine("{0,-13} {1,-14} {2,-20} {3,-16} {4,-20} {5,-17} {6, -15}", "Claim ID", "Claim Type", "Claim Description", "Claim Amount", "Date of Incident", "Date of Claim", "Is Valid");
			foreach (Claim claims in _allClaims)
			{
				Console.WriteLine("{0,-13} {1,-14} {2,-20} {3,-16} {4,-20} {5,-17} {6, -15}", claims.ClaimID, claims.TypeOfClaim, claims.Description, claims.ClaimAmount, claims.DateOfIncident, claims.DateOfClaim, claims.IsValid);
			}
		}



		//private void DevelopmentTeamMenu()
		//{
		// bool continueDevTeamMenu = true;

		// while (continueDevTeamMenu)
		// {
		// Console.Clear();
		// Console.WriteLine("DEVELOPMENT TEAM MENU\n" +
		// "1. Add a development team\n" +
		// "2. View all development teams\n" +
		// "3. View a specific development team and it's developers\n" +
		// "4. Update a development team name\n" +
		// "5. Add multiple developers to a development team\n" +
		// "6. Remove developers from a development team\n" +
		// "7. Go back to main menu.\n");

		// string userChoice = Console.ReadLine();
		// Console.Clear();
		// switch (userChoice)
		// {
		// //Add a dev team
		// case "1":
		// DevelopmentTeam devTeamToAdd = new DevelopmentTeam();
		// DevTeamRepo.AddObjectToRepository(devTeamToAdd);
		// devTeamToAdd.AddDevelopers(new List<Developer>());


		// Console.WriteLine("Please provide an ID for the development team:");
		// devTeamToAdd.ID = GetUserInputAsInt();

		// Console.WriteLine("What would you like to name this development team?");
		// devTeamToAdd.Name = Console.ReadLine();

		// Console.WriteLine("Would you like to add any developers to the dev team? Y/N");
		// string userReply = Console.ReadLine().ToUpper();
		// if (userReply == "Y")
		// {
		// AddMultipleDevelopersToTeam(devTeamToAdd.ID);
		// }
		// Console.WriteLine("Your Dev team has been added.");

		// PressAnyKeyToContinue();
		// break;
		// case "2":
		// PrintDevelopmentTeamsInRepo();

		// PressAnyKeyToContinue();
		// break;
		// case "3":
		// Console.WriteLine("Please select a development team of which you would like to see the developers.");
		// PrintDevelopmentTeamsInRepo();

		// int userSelection = GetUserInputAsInt();

		// if (userSelection == 0 || !DevRepo.RepositoryContainsObject(userSelection))
		// {
		// Console.WriteLine("Please try again. Entry does not contain a valid dev team number.");
		// }
		// else
		// {
		// Console.Clear();
		// DevelopmentTeam userSelectedDevTeam = DevTeamRepo.GetDevelopmentTeamById(userSelection);
		// List<Developer> devTeamDevList = userSelectedDevTeam.DevTeam;
		// if (devTeamDevList.Count > 0)
		// {
		// Console.WriteLine($"ID: {userSelectedDevTeam.ID}, Name: {userSelectedDevTeam.Name}\n" +
		// $"Dev Team Members:");
		// foreach (Developer dev in devTeamDevList)
		// {
		// Console.WriteLine($"ID: {dev.ID}, Name: {dev.Name}, Has Pluralsight Access: {dev.HasPluralsightAccess}");
		// }
		// }
		// else
		// {
		// Console.WriteLine($"Sorry, but {userSelectedDevTeam.Name} has no developers assigned.");
		// }
		// }

		// PressAnyKeyToContinue();
		// break;
		// case "4":
		// Console.WriteLine("Please select a development team of which you would like to update the name.");
		// PrintDevelopmentTeamsInRepo();

		// userSelection = GetUserInputAsInt();
		// DevelopmentTeam devTeamToUpdateName = DevTeamRepo.GetDevelopmentTeamById(userSelection);
		// if (userSelection == 0 || !DevRepo.RepositoryContainsObject(userSelection))
		// {
		// Console.WriteLine("Please try again. Entry does not contain a valid dev team number.");
		// }
		// else
		// {
		// Console.WriteLine("What would you like the new name of the team to be?");
		// string devTeamsNewName = Console.ReadLine();
		// devTeamToUpdateName.Name = devTeamsNewName;
		// }

		// break;
		// case "5":
		// Console.WriteLine("Please select a development team of which you would like to add developers");
		// PrintDevelopmentTeamsInRepo();

		// userSelection = GetUserInputAsInt();
		// DevelopmentTeam devTeamToUpdateDevs = DevTeamRepo.GetDevelopmentTeamById(userSelection);
		// AddMultipleDevelopersToTeam(devTeamToUpdateDevs.ID);

		// Console.WriteLine("All selected developers have been added.");
		// PressAnyKeyToContinue();

		// break;
		// case "6":
		// Console.WriteLine("Please select a development team of which you would like to remove developers");
		// PrintDevelopmentTeamsInRepo();

		// userSelection = GetUserInputAsInt();
		// DevelopmentTeam devTeamToRemoveDevs = DevTeamRepo.GetDevelopmentTeamById(userSelection);
		// List<Developer> devsOnDevTeam = devTeamToRemoveDevs.DevTeam;

		// Console.WriteLine("Please select the ID of the developer that you would like to remove.");
		// foreach (Developer dev in devsOnDevTeam)
		// {
		// Console.WriteLine($"ID: {dev.ID}, Name: {dev.Name}");
		// }
		// userSelection = GetUserInputAsInt();
		// Developer userChosenDeveloper = (Developer)DevRepo.GetBusinessObjectsById(userSelection);
		// if (devsOnDevTeam.Contains(userChosenDeveloper))
		// {
		// devTeamToRemoveDevs.RemoveDeveloperById(userSelection);
		// DevsOnTeam.Remove(userSelection);
		// Console.WriteLine("Developer has been removed.");
		// }
		// else
		// {
		// Console.WriteLine("Your developer ID selection did not match a developer in that dev team.");
		// }

		// PressAnyKeyToContinue();
		// break;
		// case "7":
		// continueDevTeamMenu = false;
		// break;
		// default:
		// Console.WriteLine("Option invalid. Returning to the development team menu.");
		// PressAnyKeyToContinue();
		// break;
		// }
		// }
		//}

		//Helper Methods
		private void PressAnyKeyToContinue()
		{
			Console.WriteLine("\n" +
			"Press any key to continue ...");
			Console.ReadKey();
		}

		public int GetUserInputAsInt()
		{
			int returnValue = 0;
			bool keepGoing = true;
			while (keepGoing)
			{
				string userInput = Console.ReadLine();
				try
				{
					returnValue = int.Parse(userInput);   //try if the user input can be parsed into an integer
				}
				catch
				{
					returnValue = 0;   //if it cannot, then we catch it by keeping returnValue at 0
				}

				if (returnValue == 0)  //if it stayed at 0 then we need to remind the user to input a valid integer

				{
					Console.Clear();
					Console.WriteLine("Please provide a valid integer for the response.");
				}
				else
				//else stop
				{
					keepGoing = false;
				}
			}
			return returnValue;  //returns the int value
		}

		//class
	}
}//namespace