using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public enum TeamColor
    {
        Red = 1,
        Orange,
        Yellow,
        Green,
        Blue,
        Purple
    }

    public class DevTeam
    {
        List<Developer> _developer = new List<Developer>();
        public int TeamIDNum { get; set; }
        public string TeamName { get; set; }
        



        public DevTeam() { }
        

        public DevTeam(int TeamID, string teamName)
        {
            TeamIDNum = TeamID ;
            TeamName = teamName;
        }
    }

   
}
