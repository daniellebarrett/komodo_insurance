using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
       
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        //DevTeam Create
        public void AddDevTeamToDirectory(DevTeam devteam)
        {
            _devTeams.Add(devteam);
        }
        //DevTeam Read
        public List<DevTeam> GetDevTeamList()
        {
            return _devTeams;
        }
        //DevTeam Update
        public bool UpdateExistingDevTeam(int teamID, DevTeam newDevTeam)
        {
            //find the dev team
            DevTeam oldDevTeam = GetDevTeamByID(teamID);

            //Update the dev team
            if(oldDevTeam != null)
            {
                oldDevTeam.TeamIDNum = newDevTeam.TeamIDNum;
                return true;
            }
            else
            {
                return false;
            }
        }
        //DevTeam Delete
        public bool RemoveDevTeamFromList(int teamID)
        {
            DevTeam devteam = GetDevTeamByID(teamID);

            if(devteam == null)
            {
                return false;
            }

            int initialCount = _devTeams.Count;
            _devTeams.Remove(devteam);

            if(initialCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetDevTeamByName(string teamName)
        {
            foreach(DevTeam devteam in _devTeams)
            {
                if(devteam.TeamName == teamName)
                {
                    return devteam;
                }
            }
            return null;
        }

        public DevTeam GetDevTeamByID( int teamID)
        {
            foreach (DevTeam devteam in _devTeams)
            {
                if (devteam.TeamIDNum == teamID)
                {
                    return devteam;
                }
            }
            return null;
        }
    }
}
