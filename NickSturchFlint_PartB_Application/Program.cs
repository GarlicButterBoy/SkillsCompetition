using System;

namespace NickSturchFlint_PartB_Application
{
    class Program
    {
        //Declare a Global List to store Teams

        static void Main(string[] args)
        {
            bool showMenu = true; 
            while (showMenu)
            {
                Console.WriteLine("Welcome to our Monster Hunter Time Trial Tournament! Please Select an Option Below:");
                showMenu = MainMenu();
            }


            Console.WriteLine("Thank you for using Monster Hunter Time Trials, See You Again!!");
        }
        /// <summary>
        /// Displays the Main Menu
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool MainMenu()
        {
            Console.Clear();

            //Add an if statement to check that the global list has any values
            //if (teamList.Count > 1)
            //{
            //    ReadFile();
            //}

            //Display Main Menu
            Console.Write("\n--------------------------------------------------------\n");
            Console.WriteLine("1) Teams\n");
            Console.WriteLine("2) Team Members and Positions\n");
            Console.WriteLine("3) Tournaments\n");
            Console.WriteLine("0) Exit Application\n");

            //Allow for user choice
            switch (Console.ReadLine())
            {
                case "1":
                    TeamsMenu();
                    return true;
                case "2":
                    TeamMembersMenu();
                    return true;
                case "3":
                    TournamentMenu();
                    return true;
                case "0":
                    QuitMenu();
                    return false;
                default:
                    Console.WriteLine("Please select a valid option of 1, 2, 3, or 0 to leave.");
                    return true;
            }
        }

        public static bool TeamsMenu()
        {
            Console.Clear();

            //Display Team Menu
            Console.Write("\n--------------------------------------------------------\n");
            Console.WriteLine("1) Add a Team\n");
            Console.WriteLine("2) Display All Teams\n");
            Console.WriteLine("3) Delete Team\n");
            Console.WriteLine("0) Go Back\n");

            //Allow for user choice
            switch (Console.ReadLine())
            {
                case "1":
                    //AddTeam();
                    return true;
                case "2":
                    //DisplayAllTeams();
                    return true;
                case "3":
                    //DeleteTeam();
                    return true;
                case "0":
                    MainMenu();
                    return false;
                default:
                    Console.WriteLine("Please select a valid option of 1, 2, 3, or 0 to leave.");
                    return true;
            }
        }

        public static bool TeamMembersMenu()
        {
            Console.Clear();

            //Display Team Menu
            Console.Write("\n--------------------------------------------------------\n");
            Console.WriteLine("1) Add a Team Member and their Position\n");
            Console.WriteLine("2) Display All Team Members\n");
            Console.WriteLine("3) Delete Team Member\n");
            Console.WriteLine("0) Go Back\n");

            //Allow for user choice
            switch (Console.ReadLine())
            {
                case "1":
                    //AddTeamMember();
                    return true;
                case "2":
                    //DisplayAllMembers();
                    return true;
                case "3":
                    //DeleteTeamMember();
                    return true;
                case "0":
                    MainMenu();
                    return false;
                default:
                    Console.WriteLine("Please select a valid option of 1, 2, 3, or 0 to go back.");
                    return true;
            }
        }

        public static bool TournamentMenu()
        {
            Console.Clear();

            //Display Team Menu
            Console.Write("\n--------------------------------------------------------\n");
            Console.WriteLine("1) Add new Tournament and Teams\n");
            Console.WriteLine("2) Generate First Round\n");
            Console.WriteLine("0) Go Back\n");

            //Allow for user choice
            switch (Console.ReadLine())
            {
                case "1":
                    //CreateTournament();
                    return true;
                case "2":
                    //GenerateTournamentFirstRound();
                    return true;
                case "0":
                    MainMenu();
                    return false;
                default:
                    Console.WriteLine("Please select a valid option of 1, 2, or 0 to go back.");
                    return true;
            }
        }

        public static void QuitMenu()
        {
            Console.WriteLine("Thank you for using Monster Hunter Time Trials, See You Again!!");
            Console.ReadKey();
            Environment.Exit(0); //Close the program with a return code of 0
        }
    }
}
