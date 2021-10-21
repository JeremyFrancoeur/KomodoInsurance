using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repo
{
    public class DevTeamInfo : DeveloperInfo
    {
        public string Manager { get; set; }
        public string DevTeam { get; set; }

        public DevTeamInfo()
        {

        }

        public DevTeamInfo(string firstName, string lastName, double identification, bool pluralSightAccess, string devTeam, string manager)
            : base(firstName, lastName, identification, pluralSightAccess)
        {
            DevTeam = devTeam;
            Manager = manager;
        }
        //Needs PluralSight List
    }
}
