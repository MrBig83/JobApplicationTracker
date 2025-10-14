using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker
{
    internal class MenuHelper
    {
        public static bool ShowMenu(JobManager applicationManager)
        {
            Console.WriteLine("1. Lägg till ny ansökan");
            Console.WriteLine("2. Visa alla ansäkningar");
            Console.WriteLine("3. Filtrera ansökningar efter status");
            Console.WriteLine("4. Sortera ansökningar efter datum");
            Console.WriteLine("5. Visa statistik"); //Visa undermeny av denna (gråa ut allt annat) eller presentera en ny meny
            Console.WriteLine("6. Uppdatera status på en ansökan");
            Console.WriteLine("7. Ta bort en ansökan");
            Console.WriteLine("8. Avsluta");
            string menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "1":
                    applicationManager.AddJob();
                    break;
                case "2":
                    applicationManager.ShowAll();
                    break;
                case "3":
                    applicationManager.ShowByStatus();
                    break;
                case "4":
                    applicationManager.ShowByDate();
                    break;
                case "5":
                    applicationManager.ShowStatistics();
                    break;
                case "6":
                    applicationManager.UpdateStatus();
                    break;
                case "7":
                    applicationManager.DeleteApplication();
                    break;
                case "8":
                    return false;
                default:
                    Console.WriteLine("Vänligen ange ett korrekt menyalternativ");
                    break;

            }
            return true;
        }
    }
}
