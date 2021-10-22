using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repo
{
    public class DeveloperRepo : DevTeamInfo
    {
       
        protected readonly List<DeveloperInfo> _developerRoster = new List<DeveloperInfo>();
        public bool AddDeveloperToRoster(DeveloperInfo developer)
        {
            int startingCount = _developerRoster.Count;
            _developerRoster.Add(developer);

            bool developerAdded = _developerRoster.Count > startingCount ? true : false;
            return developerAdded;
        }

        public List<DeveloperInfo> AllDevelopers()
        {
            return _developerRoster;
        }

        public DeveloperInfo GetDeveloperRosterByIdentification(string firstName)
        {
            foreach (DeveloperInfo developer in _developerRoster)
            {
                if (developer.FirstName.ToUpper() == firstName.ToUpper())
                {
                    return developer;
                }
            }
            return null;
        }
        public DevTeamInfo GetDeveloperByName(string firstName)
        {
            foreach (DevTeamInfo developer in _developerRoster)
            {
                if (developer.FirstName.ToUpper() == firstName.ToUpper())
                {
                    return developer;
                }
            }
            return null;
        }
        public bool UpdateDeveloperInformation(string developerName, DevTeamInfo updatedDeveloper)
        {
            DevTeamInfo originalInfo = GetDeveloperByName(developerName);

            if (originalInfo != null)
            {
                originalInfo.FirstName = updatedDeveloper.FirstName;
                originalInfo.LastName = updatedDeveloper.LastName;
                originalInfo.Identification = updatedDeveloper.Identification;
                originalInfo.PluaralSightAcess = updatedDeveloper.PluaralSightAcess;
                originalInfo.Manager = updatedDeveloper.Manager;
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<DeveloperInfo> DevWithoutAccess()
        {
            List<DeveloperInfo> needsAccess = new List<DeveloperInfo>();
            foreach (DeveloperInfo developer in _developerRoster)
            {
                if (developer.PluaralSightAcess == false)
                {
                    needsAccess.Add(developer);
                }
            }
            return needsAccess;
        }
        public bool DeleteDeveloper(DeveloperInfo developer)
        {
            bool deleteResult = _developerRoster.Remove(developer);
            return deleteResult;
        }

    }
}
