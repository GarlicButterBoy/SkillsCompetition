using System;

namespace TeamsLibrary
{
    public class TeamMember
    {


        //Private Variables
        private int memberID;
        private string memberName;
        private int memberPosition;
        private int teamID;

        //Constructors
        //Default Constructor
        public TeamMember()
        {

        }

        //Parameterized Constructors
        public TeamMember(int id, string name, int weapon, int teamID)
        {
            SetID(id);
            SetName(name);
            SetPosition(weapon);
            SetTeamID(teamID);
        }


        //Getters and Setters
        public int GetID()
        {
            return memberID;
        }

        public void SetID(int ID)
        {
            this.memberID = ID;
        }

        public string GetName()
        {
            return memberName;
        }

        public void SetName(string name)
        {
            this.memberName = name;
        }

        public string GetPosition()
        {
            string weaponName = "";

            switch (memberPosition)
            {
                case 1:
                    weaponName = "Greatsword";
                    break;
                case 2:
                    weaponName = "Longsword";
                    break;
                case 3:
                    weaponName = "Sword And Shield";
                    break;
                case 4:
                    weaponName = "Dual Blades";
                    break;
                case 5:
                    weaponName = "Charge Blade";
                    break;
                case 6:
                    weaponName = "Hammer";
                    break;
                case 7:
                    weaponName = "Hunting Horn";
                    break;
                case 8:
                    weaponName = "Switch Axe";
                    break;
                case 9:
                    weaponName = "Lance";
                    break;
                case 10:
                    weaponName = "Gun Lance";
                    break;
                case 11:
                    weaponName = "Insect Glaive";
                    break;
                case 12:
                    weaponName = "Bow";
                    break;
                case 13:
                    weaponName = "Light Bowgun";
                    break;
                case 14:
                    weaponName = "Heavy Bowgun";
                    break;
            }
            return weaponName;
        }

        public void SetPosition(int position)
        {
            this.memberPosition = position;
        }

        public int GetTeamID()
        {
             return teamID;
        }

        public void SetTeamID(int ID)
        {
            this.teamID = ID;
        }

        //Methods
        public override string ToString()
        {
            string tempString = "";

            tempString += "Member Name: " + GetName() + " (" + GetID().ToString() + ") \n";
            tempString += "is a member of " + GetTeamID() + " and plays the " + GetPosition(); 

            return tempString;
        }

        public string FileString()
        {
            string tempString = GetID().ToString() + "," + GetName() + "," + memberPosition + "," + GetTeamID().ToString();

            return tempString; 
            
        }

        public string TableString()
        {
            return String.Format("{0, -6} {1, -13} {2, -18} {3}", memberID, memberName, GetPosition(), teamID);
        }

    }
}
