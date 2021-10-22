
using KomodoInsurance_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Console
{
    public class ProgramUI
    {
        private readonly DeveloperRepo _devRoster = new DeveloperRepo();
        private readonly DevTeamRepo _gTeam = new DevTeamRepo();
        private readonly DevTeamRepo _bTeam = new DevTeamRepo();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome. In this menu you can view developers, teams, and get PluralSight status. \n" +
                "Managers can also add, remove, and updated devlopers/teams. \n" +
                "Please select the number of the option you would like to select and then press enter. \n" +
                    "\n" +
                "1. Current list of developers \n" +
                "2. Team Gold \n" +
                "3. Team Blue \n" +
                "4. Add developer, Assign team, and delete devlopers (Managers only) \n" +
                "5. Need PluralSight access \n" +
                "6. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ShowAllDevelopers();
                        break;
                    case "2":
                        TeamGold();
                        break;
                    case "3":
                        TeamBlue();
                        break;
                    case "4":
                        ManagerAccess();
                        break;
                    case "5":
                        PluralSight();
                        break;
                    case "6":
                        continueToRun = false;
                        break;
                }

            }
        }
        private void AddEmployee()
        {
            DevTeamInfo developer = new DevTeamInfo();

            Console.WriteLine("Enter the employees first namne:");
            developer.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the employees last name:");
            developer.LastName = Console.ReadLine();

            Console.WriteLine("Enter the employees ID number:");
            string idInput = Console.ReadLine();
            try
            {
                developer.Identification = double.Parse(idInput);
            }
            catch
            {
                Console.WriteLine("Sorry. You need to enter in a valid ID 1-500.");
            }

            Console.WriteLine("Does the employee have PluralSight access? Enter yes or no.");
            string psInput = Console.ReadLine();
            if (psInput == "yes")
            {
                developer.PluaralSightAcess = true;
            }
            else
            {
                if (psInput == "no")
                {
                    developer.PluaralSightAcess = false;
                }
                else
                {
                    Console.WriteLine("Please enter yes or no.");
                }

            }
            _devRoster.AddDeveloperToRoster(developer);
        }
        public void ShowAllDevelopers()
        {
            Console.Clear();
            List<DeveloperInfo> listOfDevelopers = _devRoster.AllDevelopers();
            foreach (DeveloperInfo developerVariable in listOfDevelopers)
            {

                Console.WriteLine($"{ developerVariable.FirstName} {developerVariable.LastName}   {"ID ="} { developerVariable.Identification}");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        private void ManagerAccess()
        {
            Console.WriteLine("What is your password?");
            if (Console.ReadLine() == "QAZwsx")
            {
                AddDevelopersToTeam();
            }
            RunMenu();
        }
        private void AddDevelopersToTeam()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome. In this menu you can view developers, teams, and get PluralSight status. \n" +
                "Managers can also add, remove, and updated devlopers/teams. \n" +
                "Please select the number of the option you would like to select and then press enter. \n" +
                    "\n" +
                "1. Add developer \n" +
                "2. Add developer to Gold team \n" +
                "3. Add developer to Blue team \n" +
                "4. Delete developer \n" +
                "5. Return to main menu ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        NewMemberGoldTeam();
                        break;
                    case "3":
                        NewMemberBlueTeam();
                        break;
                    case "4":
                        DeleteDevloper();
                        break;
                    case "5":
                        RunMenu();
                        break;
                }
            }
        }
        private void TeamGold()
        {
            Console.Clear();
            List<DevTeamInfo> listGoldTeam = _gTeam.GetGoldTeam();
            foreach (DevTeamInfo goldVariable in listGoldTeam)
            {
                Console.WriteLine($"{goldVariable.FirstName} { goldVariable.LastName}  {"ID ="} { goldVariable.Identification}");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void NewMemberGoldTeam()
        {
            DevTeamInfo developer = new DevTeamInfo();
            Console.WriteLine("Enter the developers last name");
            developer.LastName = Console.ReadLine();
            _gTeam.AddToGoldTeam(developer);
        }
        private void TeamBlue()
        {
            Console.Clear();
            List<DevTeamInfo> listBlueTeam = _bTeam.GetBlueTeam();
            foreach (DevTeamInfo blueVariable in listBlueTeam)
            {
                Console.WriteLine($"{blueVariable.FirstName} { blueVariable.LastName}  {"ID ="} { blueVariable.Identification}");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        private void NewMemberBlueTeam()
        {
            DevTeamInfo developer = new DevTeamInfo();
            Console.WriteLine("Enter the developers last name");
            developer.LastName = Console.ReadLine();
            _bTeam.AddToBlueTeam(developer);
        }
        private void PluralSight()
        {
            Console.Clear();
            List<DeveloperInfo> developers = _devRoster.DevWithoutAccess();

            foreach (DevTeamInfo member in developers)
            {
                Console.WriteLine($" {member.Fullname} {"Needs Access."}");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void DeleteDevloper()
        {
            Console.Clear();
            Console.WriteLine("Which developer would you like to remove?");
            List<DeveloperInfo> developers = _devRoster.AllDevelopers();
            int count = 0;
            foreach (DeveloperInfo developer in developers)
            {
                count++;
                Console.WriteLine($"{count} {developer.Fullname}");
            }

            int targetDeveloperId = int.Parse(Console.ReadLine());
            int targetIndex = targetDeveloperId - 1;
            if (targetIndex >= 0 && targetIndex < developers.Count)
            {
                DeveloperInfo devToRemove = developers[targetIndex];
                if (_devRoster.DeleteDeveloper(devToRemove))
                {
                    Console.WriteLine($" {devToRemove.FirstName} was removed");
                }
                else
                {
                    Console.WriteLine("Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Please ID a developer.");
            }
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }

        private void SeedContent()
        {
            DevTeamInfo developerOne = new DevTeamInfo("John", "Smith", 3, true, "Blue", "No");
            DevTeamInfo developerTwo = new DevTeamInfo("Jane", "Henry", 4, true, "Gold", "No");
            DevTeamInfo developerThree = new DevTeamInfo("Bob", "Ross", 5, false, "Gold", "No");
            DevTeamInfo developerFour = new DevTeamInfo("Billy", "Zane", 6, true, "Gold", "No");
            DevTeamInfo developerFive = new DevTeamInfo("Hulk", "Hogan", 7, false, "Blue", "No");
            _devRoster.AddDeveloperToRoster(developerOne);
            _devRoster.AddDeveloperToRoster(developerTwo);
            _devRoster.AddDeveloperToRoster(developerThree);
            _devRoster.AddDeveloperToRoster(developerFour);
            _devRoster.AddDeveloperToRoster(developerFive);
            DevTeamInfo bossOne = new DevTeamInfo("Morse", "Code", 1, true, "Blue", "yes");
            _devRoster.AddDeveloperToRoster(bossOne);
        }
    }
}
