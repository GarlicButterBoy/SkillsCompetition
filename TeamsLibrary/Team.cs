using System;
using System.Collections.Generic;
using System.Text;

namespace TeamsLibrary
{
    public class Team
    {

        private int teamID;
        private string teamName;
        private int teamRegion;
        private List<TeamMember> teamMembers;

        //Constructors
        //Default Constructor
        public Team()
        {

        }

        //Parameterized Constructors
        public Team(int ID, string name, int region, List<TeamMember> members)
        {
            SetID(ID);
            SetTeamName(name);
            SetRegion(region);
            SetMembers(members);
        }

        //Getters And Setters
        public int GetID()
        {
            return teamID;
        }

        public void SetID(int ID)
        {
            this.teamID = ID;
        }

        public string GetTeamName()
        {
            return teamName;
        }

        public void SetTeamName(string name)
        {
            this.teamName = name;
        }

        public string GetRegion()
        {
            string region = "";

            switch (teamRegion)
            {
                case 1:
                    region = "North America";
                    break;
                case 2:
                    region = "South America";
                    break;
                case 3:
                    region = "Europe";
                    break;
                case 4:
                    region = "Asia";
                    break;
                case 5:
                    region = "Africa";
                    break;
                case 6:
                    region = "Oceania";
                    break;
            }
            return region;
        }

        public void SetRegion(int region)
        {
            this.teamRegion = region;
        }

        public List<TeamMember> GetMembers()
        {
            return teamMembers;
        }

        public void SetMembers(List<TeamMember> members)
        {
            this.teamMembers = members;
        }


        //Methods
        public override string ToString()
        {
            string tempString = "";

            tempString += "Team: " + GetTeamName() + " (" + GetID().ToString() + ")\n";
            tempString += "Region: " + GetRegion() + "\n";
            tempString += "Members:\n";

            foreach (TeamMember player in teamMembers)
            {
                tempString += player.GetName() + " Plays Weapon: " + player.GetPosition() + "\n";
            }

            return tempString;
        }

        public string FileString()
        {
            string tempString = GetID() + "," + GetTeamName() + "," + GetRegion() + ",";

            foreach (TeamMember member in teamMembers)
            {
                tempString += member.GetID() + ",";
            }

            return tempString;
        }
    }
}
