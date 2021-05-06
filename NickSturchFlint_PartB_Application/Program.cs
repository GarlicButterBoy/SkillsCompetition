using System;
using System.Collections.Generic;
using System.IO;
using TeamsLibrary;

namespace NickSturchFlint_PartB_Application
{
    class Program
    {
        //Declare a Global List to store Teams and Team Members
        private static List<Team> teams = new List<Team>();
        private static List<TeamMember> players = new List<TeamMember>();

        static void Main(string[] args)
        {
            ReadMemberFile();
            ReadTeamFile();

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
                    AddTeam();
                    return true;
                case "2":
                    DisplayAllTeams();
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

        private static void DisplayAllTeams()
        {
            Console.WriteLine("All Teams Currently Registered: \n\n");

            
            foreach (Team team in teams)
            {
                Console.WriteLine("\n" + team.ToString());
            }

            Console.ReadKey();
            MainMenu();
        }

        private static void AddTeam()
        {
            Console.WriteLine("Add New Team Selected: \n");

            bool flag = true; //used for do/while
            string errors = "Something went wrong, please try again...";

            int id = 0;
            string name = "";
            int region = 1;
            List<TeamMember> teamPlayers = new List<TeamMember>();

            do
            {
                //if there are any errors
                if (!flag)
                {
                    Console.Clear();
                    Console.WriteLine(errors);
                    flag = true;
                }

                Console.WriteLine("Please Enter a 4 Digit Team ID Number: ");
                try
                {
                    id = int.Parse(Console.ReadLine());

                    if (id < 1000 || id > 9999)
                    {
                        flag = false;
                        errors += "\nPlayer ID must be between 1000 and 9999";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Clear();
                Console.WriteLine("Please Enter Your Name/Username: ");
                try
                {
                    name = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                foreach (TeamMember player in players)
                {
                    if (player.GetTeamID() == id)
                    {
                        teamPlayers.Add(player);
                    }
                }

                Console.Clear();
                region = DisplayRegionOptions();

                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();


            } while (!flag);

            if (flag)
            {
                //Success, create the new player
                teams.Add(new Team(id, name, region, teamPlayers));
            }

            WriteToTeamFile();
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
                    AddTeamMember();
                    return true;
                case "2":
                    DisplayAllMembers();
                    return true;
                case "3":
                    DeleteTeamMember();
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

        public static void ReadTeamFile()
        {
            //Read the File(s)
            StreamReader teamFile = new StreamReader(@"../../../Resources/teams.dat");
            string line;
            List<TeamMember> teamMembers = new List<TeamMember>();
            //reads each line of the file
            while ((line = teamFile.ReadLine()) != null)
            {
                //use a delimiter to split lines into relevant data
                string[] columns = line.Split(',');

                try
                {
                    int counter = 0;

                    int ID = int.Parse(columns[counter]);
                    counter++;

                    string name = columns[counter];
                    counter++;

                    int region = int.Parse(columns[counter]);
                    counter++;

                    //create the list of team members
                    foreach (TeamMember player in players)
                    {
                        if (player.GetID() == int.Parse(columns[counter]))
                        {
                            teamMembers.Add(player);
                        }
                        counter++;
                    }
                    teams.Add(new Team(ID, name, region, teamMembers));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public static void ReadMemberFile()
        {
            //Read the File(s)
            StreamReader memberFile = new StreamReader(@"../../../Resources/members.dat");
            string line;

            //reads each line of the file
            while ((line = memberFile.ReadLine()) != null)
            {
                //use a delimiter to split lines into relevant data
                string[] columns = line.Split(',');

                try
                {
                    int ID = int.Parse(columns[0]);
                    string name = columns[1];
                    int position = int.Parse(columns[2]);
                    int team = int.Parse(columns[3]);


                    players.Add(new TeamMember(ID, name, position, team));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            memberFile.Close();
        }

        public static void AddTeamMember()
        {
            Console.WriteLine("Add New Team Member Selected: \n");

            bool flag = true; //used for do/while
            string errors = "Something went wrong, please try again...";

            int id = 0;
            string name = "";
            int position = 1;
            int teamID = 0;

            do
            {
                //if there are any errors
                if (!flag)
                {
                    Console.Clear();
                    Console.WriteLine(errors);
                    flag = true;
                }

                Console.WriteLine("Please Enter a 4 Digit ID Number: ");
                try
                {
                    id = int.Parse(Console.ReadLine());

                    if (id < 1000 || id > 9999)
                    {
                        flag = false;
                        errors += "\nPlayer ID must be between 1000 and 9999";
                    }

                    foreach (TeamMember player in players)
                    {
                        if (player.GetID() == id)
                        {
                            flag = false;
                            errors += "\nPlayer ID already exists in our system";
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Clear();
                Console.WriteLine("Please Enter Your Name/Username: ");
                try
                {
                    name = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Clear();
                Console.WriteLine("Please Enter a 4 Digit Team ID: ");
                try
                {
                    teamID = int.Parse(Console.ReadLine());

                    if (teamID < 1000 || teamID > 9999)
                    {
                        flag = false;
                        errors += "\nTeam ID must be between 1000 and 9999";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                position = DisplayPositionOptions();

                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();


            } while (!flag);

            if (flag)
            {
                //Success, create the new player
                players.Add(new TeamMember(id, name, position, teamID));
            }

            WriteToPlayerFile(); //method will add the updated list to the members.dat

        }

        /// <summary>
        /// This method will display a menu from 1 to 14, each representing its own weapon type
        /// </summary>
        /// <returns>An int representing weapon type</returns>
        public static int DisplayPositionOptions()
        {
            Console.Clear();
            //Allow for user choice
            bool flag = true;
            int userChoice = 0;
            do
            {

                Console.Write("\n-------------  WEAPON TYPES / TEAM POSITIONS  -------------\n");
                Console.WriteLine("1) Greatsword\n");
                Console.WriteLine("2) Longsword\n");
                Console.WriteLine("3) Sword And Shield\n");
                Console.WriteLine("4) Dual Blades\n");
                Console.WriteLine("5) Charge Blade\n");
                Console.WriteLine("6) Hammer\n");
                Console.WriteLine("7) Hunting Horn\n");
                Console.WriteLine("8) Switch Axe\n");
                Console.WriteLine("9) Lance\n");
                Console.WriteLine("10) Gun Lance\n");
                Console.WriteLine("11) Insect Glaive\n");
                Console.WriteLine("12) Bow\n");
                Console.WriteLine("13) Light Bowgun\n");
                Console.WriteLine("14) Heavy Bowgun\n");

                try
                {
                    userChoice = int.Parse(Console.ReadLine());

                    if (userChoice < 1 || userChoice > 14)
                    {
                        flag = false;
                        Console.Clear();
                        Console.WriteLine("Choice must be between 1 and 14");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (!flag);

            return userChoice;
        }

        /// <summary>
        /// This method will display a menu from 1 to 6 each representing its own region
        /// </summary>
        /// /// <returns>An int representing region</returns>
        public static int DisplayRegionOptions()
        {
            Console.Clear();
            //Allow for user choice
            bool flag = true;
            int userChoice = 0;
            do
            {
                Console.Write("\n-------------  REGIONS  -------------\n");
                Console.WriteLine("1) North America\n");
                Console.WriteLine("2) South America\n");
                Console.WriteLine("3) Europe\n");
                Console.WriteLine("4) Asia\n");
                Console.WriteLine("5) Africa\n");
                Console.WriteLine("6) Oceania\n");

                try
                {
                    userChoice = int.Parse(Console.ReadLine());

                    if (userChoice < 1 || userChoice > 6)
                    {
                        flag = false;
                        Console.Clear();
                        Console.WriteLine("Choice must be between 1 and 6");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (!flag);

            return userChoice;
        }

        public static void DisplayAllMembers()
        {
            Console.Write("\nRow |  ID  | Player Name | Player Weapon  | Team ID |\n" +
                            "----|------|-------------|----------------|---------|\n");

            int counter = 0;
            foreach (TeamMember player in players)
            {
                counter++;
                Console.WriteLine(String.Format("{0, -4} ", counter) + player.TableString());
            }

            //Console.WriteLine("Press Any Key to Return to the Main Menu...");
            Console.ReadKey();
            MainMenu();
        }

        private static void DeleteTeamMember()
        {

            TeamMember player = new TeamMember();
            int tempID;
            string input = "";
            bool flag = true;

            do
            {


                //if there is any errors
                if (!flag)
                {
                    Console.Clear();
                    Console.WriteLine("Could not find that player, try again...");
                    flag = true;
                }

                Console.WriteLine("\nYou have chosen to delete a team member, please enter the player ID (1000-9999): ");
                tempID = int.Parse(Console.ReadLine());

                if (tempID < 1000 || tempID > 9999)
                {
                    flag = false;
                    Console.Write("\nPlease enter a valid ID");
                }


            } while (!flag);


            foreach (TeamMember member in players)
            {
                if (member.GetID() == tempID)
                {
                    player = member;
                }
            }

            //Player is found
            if (player != new TeamMember())
            {
                Console.Clear();
                Console.WriteLine("Player Found!");

                Console.WriteLine(player.ToString());

                while ((input != "y") && (input != "n"))
                {
                    Console.Write("\n\nAre you sure you want to delete this player? Press Y/N: ");
                    input = Console.ReadLine();
                }

                switch (input)
                {
                    case "y":
                        Console.WriteLine("Player with ID " + tempID + " has been deleted.");
                        players.Remove(player);
                        break;
                    case "n":
                        Console.WriteLine("No Player Deleted, returning to main menu");
                        break;
                }
            }
            WriteToPlayerFile();
        }

        public static void WriteToPlayerFile()
        {
            using (StreamWriter memberFile = new StreamWriter(@"../../../Resources/members.dat", false))
            {
                foreach (TeamMember player in players)
                {
                    memberFile.WriteLine(player.FileString());
                }
            }
        }

        public static void WriteToTeamFile()
        {
            using (StreamWriter memberFile = new StreamWriter(@"../../../Resources/teams.dat", false))
            {
                foreach (Team team in teams)
                {
                    memberFile.WriteLine(team.FileString());
                }
            }
        }
    }
}
