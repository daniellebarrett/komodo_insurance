using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevConsole
{
    class DevUI
    {
        private DeveloperRepo _devRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();

        //Method runs UI 
        public void Run()
        {
            SeedDeveloperList();
            Menu();

        }

        // Menu
        private void Menu()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                //display our options to the user
                Console.WriteLine("Please select a menu option:\n" +
                    "1. Create New Developer\n" +
                    "2. Create New Devleoper Team\n" +
                    "3. View All Developers\n" +
                    "4. View All Developer Teams\n" +
                    "5. View Developer By ID Number\n" +
                    "6. View Developer Team By ID Number\n" +
                    "7. Update Existing Developer\n" +
                    "8. Update Existing Developer Team\n" +
                    "9. Delete Existing Developer\n" +
                    "10. Delete Existing Developer Team\n" +
                    "11. Exit");

                //get user input
                string userInput = Console.ReadLine();
                // evaluate user input and act accordingly
                switch (userInput)
                {
                    case "1":
                        //create new developer
                        CreateNewDeveloper();
                        break;
                    case "2":
                        //create new devteam
                        CreateNewDevTeam();
                        break;
                    case "3":
                        //view all developers
                        DisplayAllDevelopers();
                        break;
                    case "4":
                        DisplayAllDevTeams();
                        break;
                    case "5":
                        //view developer by ID number
                        DisplayDeveloperByIDNum();
                        break;
                    case "6":
                        //view dev team by ID number
                        DisplayDevTeamsByIDNum();
                        break;
                    case "7":
                        //update existing developer
                        UpdateExistingDeveloper();
                        break;
                    case "8":
                        //update existing dev team
                        UpdateExistingDevTeam();
                        break;
                    case "9":
                        //delete existing developer
                        DeleteExistingDeveloper();
                        break;
                    case "10":
                        //delete existing dev team
                        DeleteExistingDevTeam();
                        break;
                    case "11":
                        //exit
                        Console.WriteLine("Goodbye!!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }


        }
        //create new developer
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newDev = new Developer();

            Console.WriteLine("Enter the first name of the developer:");
            newDev.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the last name of the developer:");
            newDev.LastName = Console.ReadLine();

            Console.WriteLine("Enter the ID number of the developer:");
            string idAsString = Console.ReadLine();
            newDev.IDNumber = int.Parse(idAsString);

            Console.WriteLine("Enter the name of the team:");
            string teamName = Console.ReadLine();

            Console.WriteLine("Enter if developer has Pluralsight access (y/n):");
            string accessString = Console.ReadLine().ToLower();

            if (accessString == "y")
            {
                newDev.CanAccessPluralsight = true;
            }
            else
            {
                newDev.CanAccessPluralsight = false;
            }
            _devRepo.AddDeveloperToDirectory(newDev);
        }

        //create new dev team
        private void CreateNewDevTeam()
        {
            Console.Clear();

            DevTeam newDevTeam = new DevTeam();

            Console.WriteLine("Enter the name of the team");
            string teamName = Console.ReadLine();

            //team id number
            Console.WriteLine("Enter the team ID number:");
            string idAsString = Console.ReadLine();
            newDevTeam.TeamIDNum = int.Parse(idAsString);
        }

        //display all developers
        private void DisplayAllDevelopers()
        {
            Console.Clear();
            List<Developer> listofDevelopers = _devRepo.GetDevelopers();

            foreach (Developer dev in listofDevelopers)
            {
                Console.WriteLine($"First Name: {dev.FirstName})\n" +
                    $"Last Name: {dev.LastName})\n" +
                    $"ID Number: {dev.IDNumber}");
            }
        }

        private void DisplayAllDevTeams()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeamList();
            foreach (DevTeam devteam in listOfDevTeams)
            {
                Console.WriteLine($"Team Name: {devteam.TeamName}\n" +
                    $"Team ID Number: {devteam.TeamIDNum}\n\n");
            }
        }

        private void DisplayDeveloperByIDNum()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID Number of the developer you would like to see:");
            string input = Console.ReadLine();
            int num = int.Parse(input);
            Developer dev = _devRepo.GetDeveloperByIDNumber(num);

            if (dev != null)
            {
                Console.WriteLine($"First Name: {dev.FirstName}\n" +
                    $"Last Name: {dev.LastName}\n" +
                    $"ID Number: {dev.IDNumber}\n" +
                    $"PluralSight Access: {dev.CanAccessPluralsight}\n" +
                    $"Team Name: {dev.TeamName}");
            }
            else
            {
                Console.WriteLine("Sorry could not find a developer related to that ID Number");
            }

        }
        private void DisplayDevTeamsByIDNum()
        {
            Console.Clear();
            Console.WriteLine("Enter the Team ID number of the team you would like to see:");
            string input = Console.ReadLine();
            int num = int.Parse(input);
            DevTeam devteam = _devTeamRepo.GetDevTeamByID(num);

            if (devteam != null)
            {
                Console.WriteLine($"Team Name: {devteam.TeamName}\n" +
                    $"Team ID Number: {devteam.TeamIDNum}");
            }
            else
            {
                Console.WriteLine("Sorry could not find a developer team related to that ID number");
            }
        }
        private void UpdateExistingDeveloper()
        {
            DisplayAllDevelopers();
            Console.WriteLine("Enter the ID Number of the developer you would like to update:");

            int oldDev = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new ID number for this developer");
            string idAsString = Console.ReadLine();
            Developer newdev = new Developer();
            newdev.IDNumber = int.Parse(idAsString);

            Console.WriteLine("Enter the first name of the developer:");
            newdev.FirstName = Console.ReadLine();
            Console.WriteLine("Enter the last name of the developer:");
            newdev.LastName = Console.ReadLine();
         
            Console.WriteLine("Can this developer access PluralSight?(y/n):");
            string access = Console.ReadLine().ToLower();
            if (access == "y")
            {
                newdev.CanAccessPluralsight = true;
            }
            else
            {
                newdev.CanAccessPluralsight = false;
            }

            Console.WriteLine("Enter the name of the team:");
            string teamName = Console.ReadLine();

            bool wasUpdated = _devRepo.UpdateExistingDeveloper(oldDev, newdev);

            if (wasUpdated)
            {
                Console.WriteLine("Developer was successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update developer!");
            }



        }
        private void AddDevToDevTeam(string teamName)
        {

            teamName = Console.ReadLine().ToLower();
            _devTeamRepo.GetDevTeamByName(teamName);

        }
        private void UpdateExistingDevTeam()
        {
            DisplayAllDevTeams();
            Console.WriteLine("Enter the ID Number of the developer team you would like to update:");

            int oldDevTeam = int.Parse(Console.ReadLine());

            string idAsString = Console.ReadLine();
            DevTeam newDevTeam = new DevTeam();
            newDevTeam.TeamIDNum = int.Parse(idAsString);

            Console.WriteLine("Enter the team name:");
            newDevTeam.TeamName = Console.ReadLine();
            Console.WriteLine("Enter the Team ID Number:");
            string idAsStringAgain = Console.ReadLine();
            newDevTeam.TeamIDNum = int.Parse(idAsStringAgain);

            bool wasUpdated = _devTeamRepo.UpdateExistingDevTeam(oldDevTeam, newDevTeam);

            if (wasUpdated)
            {
                Console.WriteLine("Dev Team was successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update dev team!");
            }
        }
        private void DeleteExistingDeveloper()
        {
            DisplayAllDevelopers();
            Console.WriteLine("Enter the ID number of the developer you would like to remove:");
            int input = int.Parse(Console.ReadLine());

            bool wasDeleted = _devRepo.RemoveDeveloperFromDirectory(input);

            if (wasDeleted)
            {
                Console.WriteLine("The developer was successfully deleted");
            }
            else
            {
                Console.WriteLine("The developer could not be deleted!");
            }
        }
        private void DeleteExistingDevTeam()
        {
            DisplayAllDevTeams();
            Console.WriteLine("Enter the Team ID number of the team you would like to remove:");
            int input = int.Parse(Console.ReadLine());

            bool wasDeleted = _devTeamRepo.RemoveDevTeamFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("The Dev Team was successfully deleted!");
            }
            else
            {
                Console.WriteLine("The Dev Team could not be deleted!");
            }
        }
        private void SeedDeveloperList()
        {
            Developer developer1 = new Developer("Johnny", "Bravo", 1, true, "Team A");
            Developer developer2 = new Developer("Sally", "Scaredo", 2, true, "Team B");
            Developer developer3 = new Developer("Teeny", "Tino", 3, false, "Team C");
            Developer developer4 = new Developer("Wally", "Waldo", 4, false, "Team D");
            Developer developer5 = new Developer("Dirty", "Diane", 5, true, "Team E");
            Developer developer6 = new Developer("Candy", "Cain", 6, false, "Team A");

            DevTeam devteam1 = new DevTeam(1, "Team A");
            DevTeam devteam2 = new DevTeam(2, "Team B");
            DevTeam devteam3 = new DevTeam(3, "Team C");
            DevTeam devteam4 = new DevTeam(4, "Team D");
            DevTeam devteam5 = new DevTeam(5, "Team E");



            _devRepo.AddDeveloperToDirectory(developer1);
            _devRepo.AddDeveloperToDirectory(developer2);
            _devRepo.AddDeveloperToDirectory(developer3);
            _devRepo.AddDeveloperToDirectory(developer4);
            _devRepo.AddDeveloperToDirectory(developer5);

            _devTeamRepo.AddDevTeamToDirectory(devteam1);
            _devTeamRepo.AddDevTeamToDirectory(devteam2);
            _devTeamRepo.AddDevTeamToDirectory(devteam3);
            _devTeamRepo.AddDevTeamToDirectory(devteam4);
            _devTeamRepo.AddDevTeamToDirectory(devteam5);



        }


        //------------------------CHALLENGE - MONTHLY ACCESS CHECK-------------------------------
       /* private bool MonthlyAccessCheck(bool canAccessPluralSight)
        {
            if (canAccessPluralSight == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
    }
}

