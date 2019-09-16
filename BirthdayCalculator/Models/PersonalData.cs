using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;

namespace BirthdayCalculator.Models
{
    public class PersonalData
    {
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public DateTime Birthdate { get; set; }

        public String Fullname
        {
            get => Firstname + " " + Lastname;
        }

        public int CalculateDaysLeft()
        {
            int days = 0;
            DateTime currentYearBirthdate = new DateTime(DateTime.Now.Year, Birthdate.Month, Birthdate.Day);
            DateTime nextyearBirthdate = currentYearBirthdate.AddYears(1);
            if (DateTime.Now.Month == Birthdate.Month && DateTime.Now.Day == Birthdate.Day)
            {
                return days;
            }
            // This years birthday already happened, it's now next month or same month but days after
            if (DateTime.Now.Month > Birthdate.Month || 
                DateTime.Now.Month == Birthdate.Month && DateTime.Now.Day > Birthdate.Day)
            {
                TimeSpan difference = nextyearBirthdate - DateTime.Now.Date;
                days = difference.Days;
            }

            // This years birthday has yet to take place, it's a month before or same month but days before
            if (DateTime.Now.Month < Birthdate.Month ||
                DateTime.Now.Month == Birthdate.Month && DateTime.Now.Day < Birthdate.Day)
            {
                TimeSpan difference = currentYearBirthdate - DateTime.Now;
                days = difference.Days;
                if (days == 0 && difference.Seconds > 0)
                {
                    days = 1;
                }
            }
            return days;
        }

        public int CalculateNextBirthdayAge()
        {
            int age = 0;
            int currentYear = DateTime.Now.Year;
            int nextYear = currentYear + 1;

            // This years birthday already happened, it's now next month or same month but days after
            if (DateTime.Now.Month > Birthdate.Month ||
                DateTime.Now.Month == Birthdate.Month && DateTime.Now.Day > Birthdate.Day)
            {
                age = nextYear - Birthdate.Year;
            }

            // This years birthday has yet to take place, it's a month before or same month but days before or it's today
            if (DateTime.Now.Month < Birthdate.Month ||
                DateTime.Now.Month == Birthdate.Month && DateTime.Now.Day < Birthdate.Day ||
                DateTime.Now.Month == Birthdate.Month && DateTime.Now.Day == Birthdate.Day)
            {
                age = currentYear - Birthdate.Year;
            }

            return age;
        }
    }
}
