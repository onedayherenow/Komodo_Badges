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


		//method that runs/starts the UI
		public void Run() //public so it can be called through class to method
		{
			SeedBadges();  //seed first to have content before menu appears
			Menu();
		}

		//menu  
		private void Menu()
		{
			Console.Clear();   //clears menu in case we came back from sub-menu
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
					case "3":
						//Delete existing content
						UpdateExistingBadge();
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
			Badge newBadge = new Badge(); //we declare it first so that we can then use the property of object for user input

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
			Console.WriteLine("Badge was added successfully");
			PressAnyKeyToContinue();  //user input to continue
			Menu();   //takes us back to the main menu
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
				Console.WriteLine("{0,-15} {1,-12}", badge.Key, string.Join(", ", badge.Value));
			}
		}

		//update existing content
		private void UpdateExistingBadge()
		{
			//display all badges
			DisplayAllBadges();

			//ask for Badge ID to update
			Console.WriteLine("Enter the Badge ID for the badge you'd like to update");

			//receive id and parse into int
			string oldID = Console.ReadLine();
			int intOldID = int.Parse(oldID);

			Badge newBadgeCreation = new Badge(); //we declare, so we can then use the property of object for user input

			//we build a new list for doors
			List<string> newBadgeDoorsList = new List<string>();

			bool isTrue = true;   //bool for while loop

			while (isTrue)
			{   //ask the user if they would like to add another door
				Console.WriteLine("Would you like to add a door to this badge? (y/n)");
				string doorsUserInput = Console.ReadLine().ToLower();

				if (doorsUserInput == "y")   //if yes
				{
					Console.WriteLine("Enter a door for the new badge");
					string doorToAdd = Console.ReadLine();  //save user input as string
					newBadgeDoorsList.Add(doorToAdd);  //add to the list of new doors
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

			bool wasUpdated = _badgeRepo.UpdateDoorsOnExistingBadge(intOldID, newBadgeDoorsList); //if was updated is valid/true

			if (wasUpdated)
			{
				Console.WriteLine("Badge successfully updated!");  //if updated print out this
			}
			else
			{
				Console.WriteLine("Could not update badge/badge to be replaced could not be found.");  //if not updated then print out
			}

			PressAnyKeyToContinue();
		}

		//delete existing content
		private void DeleteExistingClaim()
		{
			DisplayAllBadges();  

			Console.WriteLine("\nEnter the ID of the Badge you would like to remove.");
		
			string input = Console.ReadLine();  //receive id
			int idInput = int.Parse(input);  //parse to int

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
		}	//otherwise state it could not be deleted


		//Seed Method  --> will seed the badge dictionary
		private void SeedBadges()
		{	//three new badge objects
			Badge seed1 = new Badge(1548, "Claims Agent");
			Badge seed2 = new Badge(1738, "Developer");
			Badge seed3 = new Badge(1832, "Supervisor");

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
		private void PressAnyKeyToContinue()
		{
			Console.WriteLine("\n" +
			"Press any key to continue ...");    //re-engages the user forward
			Console.ReadKey();
		}

		//takes in user input and parses it to an int
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
	}
}