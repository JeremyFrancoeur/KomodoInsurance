using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repo
{
    public class DeveloperInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Identification { get; set; }
        public bool PluaralSightAcess { get; set; }

        public string Fullname
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public DeveloperInfo()
        {

        }

        public DeveloperInfo(string firstName, string lastName, double identification, bool pluralSightAcess)
        {
            FirstName = firstName;
            LastName = lastName;
            Identification = identification;
            PluaralSightAcess = pluralSightAcess;
        }

    }
}
