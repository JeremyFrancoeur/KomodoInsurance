using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repo
{
    public class DevTeamRepo
    {
        protected readonly DeveloperRepo _devRoster = new DeveloperRepo();
        protected readonly List<DevTeamInfo> _goldTeam = new List<DevTeamInfo>();
        protected readonly List<DevTeamInfo> _blueTeam = new List<DevTeamInfo>();

        public bool AddToGoldTeam(DevTeamInfo teamMember)
        {
            int startingCount = _goldTeam.Count;
            _goldTeam.Add(teamMember);
            bool wasAdded = _goldTeam.Count > startingCount ? true : false;
            return wasAdded;
        }

        public bool AddToBlueTeam(DevTeamInfo teamMember)
        {
            int startingCount = _blueTeam.Count;
            _blueTeam.Add(teamMember);
            bool wasAdded = _blueTeam.Count > startingCount ? true : false;
            return wasAdded;
        }
        public List<DevTeamInfo> GetGoldTeam()
        {
            return _goldTeam;
        }

        public List<DevTeamInfo> GetBlueTeam()
        {
            return _blueTeam;
        }

    }
}
