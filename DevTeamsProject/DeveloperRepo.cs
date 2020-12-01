using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create
        public void AddDeveloperToDirectory(Developer dev)
        {
            _developerDirectory.Add(dev);
        }
        //Developer Read
        public List<Developer> GetDevelopers()
        {
            return _developerDirectory;
        }
        //Developer Update
        public bool UpdateExistingDeveloper(int originalID, Developer newDeveloper)
        {
            //find the developer
            Developer oldDeveloper = GetDeveloperByIDNumber(originalID);

            //Update the developer
            if (oldDeveloper != null)
            {
                oldDeveloper.FirstName = newDeveloper.FirstName;
                oldDeveloper.LastName = newDeveloper.LastName;
                oldDeveloper.IDNumber = newDeveloper.IDNumber;
                oldDeveloper.CanAccessPluralsight = newDeveloper.CanAccessPluralsight;
                oldDeveloper.TeamName = newDeveloper.TeamName;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Developer Delete
        public bool RemoveDeveloperFromDirectory(int idnumber)
        {
            Developer dev = GetDeveloperByIDNumber(idnumber);

            if(dev == null)
            {
                return false;
            }

            int initialCount = _developerDirectory.Count;
            _developerDirectory.Remove(dev);

            if(initialCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Helper (Get Developer by ID)

        public Developer GetDeveloperByIDNumber(int idnumber)
        {
            foreach (Developer dev in _developerDirectory)
            {
                if (dev.IDNumber == idnumber)
                {
                    return dev;
                }
            }

            return null;
        }
    }
}
