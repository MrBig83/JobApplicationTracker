using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker
{
    public class JobManager
    {
        List<JobApplication> Applications = new List<JobApplication>();

        public void AddJob()
        {
            //Skapa ovjekt och lägg in det i listan
        }

        public void UpdateStatus()
        {
            //Uppdatera ResponsDate och status
        }

        public void ShowAll()
        {
            //CW för att printa ut alla job i listan
        }

        public void ShowByStatus()
        {
            //Gruppera enligt status och printa ut alla
        }

        public void ShowStatistics()
        {
            //Gruppera enligt status och printa ut statistik. (Antal i gruppen, dagar sedan svar, snitt antal dagar sedan svar)
        }

        public void AddDummyData()
        {
            //AddJob med en lista på 10 applikationer som dummydata
        }
    }
}
