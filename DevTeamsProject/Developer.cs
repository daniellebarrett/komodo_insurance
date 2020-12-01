using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IDNumber { get; set; }
        public bool CanAccessPluralsight { get; set; }
        public string TeamName { get; set; }

        public Developer() { }


        public Developer(string firstName, string lastName, int idNumber, bool canAccessPluralsight, string teamName)
        {
            FirstName = firstName;
            LastName = lastName;
            IDNumber = idNumber;
            CanAccessPluralsight = canAccessPluralsight;
            TeamName = teamName;
        }
    }
}
