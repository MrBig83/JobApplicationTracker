using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker
{
    public class ApplicationManager
    {
        List<JobApplication> applications = new List<JobApplication>();

        public void AddJob()
        {
            //Skapa objekt och lägg in det i listan
            Console.WriteLine("- Lägga till jobb -\n" +
                "Ange vilket företag du har ansökt till:");
            string companyName = Console.ReadLine();
            Console.WriteLine("Ange vilken roll du har sökt:");
            string positionTitle = Console.ReadLine();
            Console.WriteLine("Ange vilket löneanspråk du har angett:");
            int salaryExpectation = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(); 
            Console.WriteLine("Fyller i resternade värden..."); //Progressbar på 1.5 sec

            applications.Add(new JobApplication(companyName, positionTitle, JobApplication.Status.Applied, DateTime.Now, null, salaryExpectation));
            //Done! i 1.5 sekunder. 

        }

        public void UpdateStatus()
        {
            //Uppdatera ResponsDate och status 
            Console.WriteLine("- Uppdatera ansökning -");
            //=======  DRY - VARNING ========
            int counter = 1;
            applications.ForEach(a => Console.WriteLine($"{counter++}. {a.PositionTitle} på {a.CompanyName} med löneanspråk {a.SalaryExpectation}. Du sökte tjänsten {a.ApplicationDate}. Nuvarande status: {a.CurrentState}"));
            Console.WriteLine();
            Console.WriteLine("Vilken ansökning vill du uppdatera?");
            int userInput = Convert.ToInt32(Console.ReadLine())-1;
            Console.WriteLine($"Tjänsten som {applications[userInput].PositionTitle} på {applications[userInput].CompanyName} söktes den {applications[userInput].ApplicationDate} och har status: {applications[userInput].CurrentState}");
            Console.WriteLine("Välj ett av följande alternativ:");
            bool printUpdateMenu = true;
            while (printUpdateMenu)
            {
                printUpdateMenu = MenuHelper.ShowUpdateMenu(applications[userInput]);
            }

        }

        public void ShowAll()
        {
            //CW för att printa ut alla job i listan
            Console.WriteLine("- Samtliga ansökningar -");
            //======= DRY - VARNING ========
            int counter = 1;
            applications.ForEach(a => Console.WriteLine($"{counter++}. {a.PositionTitle} på { a.CompanyName} med löneanspråk {a.SalaryExpectation}. Du sökte tjänsten {a.ApplicationDate.ToShortDateString()}. Nuvarande status: {a.CurrentState}"));
            Console.WriteLine();
            Console.WriteLine("Vill du visa detaljerad information om en ansökan (ange nummer) eller gå tillbaka till huvudmenyn (x)?");
            string userInput = Console.ReadLine();
            //Lägg till möjlighet att "öppna" en ansökan och läsa mer. application[userInput -1]
            //Kanske visa i en "Show detaild information"-variant. 
        }

        public void ShowByStatus()
        {
            Console.WriteLine("- Grupperade enligt status -");
            Console.WriteLine();
            var applicationsSortedByStatus = applications.GroupBy(a => a.CurrentState);
            Console.WriteLine(applicationsSortedByStatus.Count());

            foreach (var group in applicationsSortedByStatus)
            {
                Console.WriteLine($"Status: {group.Key}, Antal ansökningar: {group.Count()}");
                foreach (var application in group)
                {
                    Console.WriteLine($"     - {application.PositionTitle} på {application.CompanyName}");
                }
                Console.WriteLine();

            }
            //Gruppera enligt status och printa ut alla
        }

        public void ShowByDate()
        {
            Console.WriteLine("- Sorterade efter ansökningsdatum -");
            //Gruppera enligt status och printa ut alla
        }

        public void ShowStatistics()
        //Gruppera enligt status och printa ut statistik. (Antal i gruppen, dagar sedan svar, snitt antal dagar sedan svar)
        {
            Console.WriteLine("- Statistik för samtliga jobbapplikationer -");
            Console.WriteLine();

            int total = applications.Count();
            int responded = applications.Count(a => a.ResponseDate != null);
            double responseRate = (double)responded / total * 100;
            Console.WriteLine($"Totalt antal ansökningar: {total}");
            Console.WriteLine($"Svarsfrekvens: {responseRate}");

            var averageResponseTIme = applications
                .Where(a => a.ResponseDate.HasValue)
                .Average(a => (a.ResponseDate.Value - a.ApplicationDate).TotalDays);
            Console.WriteLine($"Genomsnittlig svarstid: {averageResponseTIme:F1} dagar");

            var topCompanies = applications.OrderByDescending(a => a.SalaryExpectation).Take(3);
            Console.WriteLine("Topp 3 högsta löneförväntningarna:");
            foreach (var a in topCompanies)
            {
                Console.WriteLine($"{a.CompanyName} - {a.SalaryExpectation}kr ({a.PositionTitle})");
            }

            var fastestCompany = applications
                .Where(a => a.ResponseDate.HasValue)
                .OrderBy(a => (a.ResponseDate.Value - a.ApplicationDate).TotalDays)
                .FirstOrDefault();
            if (fastestCompany != null)
            {
                double svarstid = (fastestCompany.ResponseDate.Value - fastestCompany.ApplicationDate).TotalDays;
                Console.WriteLine($"Snabbaste svaret: {fastestCompany.CompanyName} ({svarstid:F1} dagar)");
            }
            else
            {
                Console.WriteLine("Inget företag har svarat ännu...");
            }

            var applicationsSortedByStatus = applications.GroupBy(a => a.CurrentState);
            Console.WriteLine();

            foreach (var group in applicationsSortedByStatus)
            {
                Console.WriteLine($"Status: {group.Key}, Antal ansökningar: {group.Count()}");
                double averageSalary = group.Average(a => a.SalaryExpectation);
                Console.WriteLine($"Genomsnittlig löneförväntning per status: {averageSalary}");
                var earliest = group.OrderBy(a => a.ApplicationDate).First();
                var latest = group.OrderByDescending(a => a.ApplicationDate).First();
                Console.WriteLine($"Första ansökan gjordes till: {earliest.CompanyName} ({earliest.ApplicationDate:d})");
                Console.WriteLine($"Senaste ansökan gjordes till: {latest.CompanyName} ({latest.ApplicationDate:d})");
                Console.WriteLine();
            }
        }

        public void DeleteApplication()
        {
            //Gruppera enligt status och printa ut alla
        }

        public void AddDummyData()
        {
            applications.Add(new JobApplication("Volvo", "Truckförare", JobApplication.Status.Interview, DateTime.Today.AddDays(-7), DateTime.Today.AddDays(-2), 37000));
            applications.Add(new JobApplication("Meta", "Developer", JobApplication.Status.Applied, DateTime.Today.AddDays(-17), DateTime.Today.AddDays(-12), 57000));
            applications.Add(new JobApplication("SKF", "Tekniker", JobApplication.Status.Offer, DateTime.Today.AddDays(-14), DateTime.Today.AddDays(-4), 37000));
            applications.Add(new JobApplication("HiQ", "IT-Konsult", JobApplication.Status.Interview, DateTime.Today.AddDays(-12), DateTime.Today.AddDays(-2), 47000));
            applications.Add(new JobApplication("Nexxer", "IT-Konsult", JobApplication.Status.Offer, DateTime.Today.AddDays(-22), DateTime.Today.AddDays(-2), 55000));
            applications.Add(new JobApplication("Ica", "Orderplockare", JobApplication.Status.Applied, DateTime.Today.AddDays(-7), DateTime.Today.AddDays(-5), 37000));
            applications.Add(new JobApplication("Swedish Match", "Snustestare", JobApplication.Status.Interview, DateTime.Today.AddDays(-21), DateTime.Today.AddDays(-15), 37000));
            applications.Add(new JobApplication("SF Bio", "Projektoroperatör", JobApplication.Status.Applied, DateTime.Today.AddDays(-27), DateTime.Today.AddDays(-20), 37000));
            applications.Add(new JobApplication("McDonalds", "Kock", JobApplication.Status.Rejected, DateTime.Today.AddDays(-18), DateTime.Today.AddDays(-17), 37000));
            applications.Add(new JobApplication("Spotify", "BE Developer", JobApplication.Status.Offer, DateTime.Today.AddDays(-5), DateTime.Today.AddDays(-2), 55000));
            //AddJob med en lista på 10 applikationer som dummydata
        }
    }
}
