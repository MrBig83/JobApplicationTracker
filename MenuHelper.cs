using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker
{
    internal class MenuHelper
    {
        public static bool ShowMenu(ApplicationManager applicationManager)
        {
            Console.Clear();
            Console.WriteLine("1. Lägg till ny ansökan");
            Console.WriteLine("2. Visa alla ansökningar");
            Console.WriteLine("3. Filtrera och gruppera ansökningar efter status");
            Console.WriteLine("4. Sortera ansökningar efter datum");
            Console.WriteLine("5. Visa statistik"); //Visa undermeny av denna (gråa ut allt annat) eller presentera en ny meny
            Console.WriteLine("6. Uppdatera status på en ansökan");
            Console.WriteLine("7. Ta bort en ansökan");
            Console.WriteLine("8. Avsluta");
            Console.WriteLine("99. Lägg till dummy-data");
            string menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "1":
                    applicationManager.AddJob();
                    break;
                case "2":
                    Console.Clear();
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
                case "99":
                    applicationManager.AddDummyData();
                    break;
                default:
                    Console.WriteLine("Vänligen ange ett korrekt menyalternativ");
                    break;

            }
            return true;
        }

        public static bool ShowUpdateMenu(JobApplication application)
        {
            
            Console.WriteLine("-- Ändra status -- ");
            Console.WriteLine("1. ...till Intervju");
            Console.WriteLine("2. ...till Erbjudande");
            Console.WriteLine("3. ...till Nekad");
            Console.WriteLine("4. Avbryt");
            Console.WriteLine("Datum för ändringen sparas automatiskt.");
            string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        application.CurrentState = JobApplication.Status.Interview;
                        application.ResponseDate = DateTime.Now;
                        Console.WriteLine("Statusen ändrad till Intervju");
                    //Lägg till en progressbar
                        Thread.Sleep(1500);
                        break;
                    case "2":
                        application.CurrentState = JobApplication.Status.Offer;
                        application.ResponseDate = DateTime.Now;
                        Console.WriteLine("Statusen ändrad till Erbjudande");
                    //Lägg till en progressbar
                    Thread.Sleep(1500);
                        break;
                    case "3":
                        application.CurrentState = JobApplication.Status.Rejected;
                        application.ResponseDate = DateTime.Now;
                        Console.WriteLine("Statusen ändrad till Nekad");
                    //Lägg till en progressbar
                    Thread.Sleep(1500);
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Vänligen ange ett korrekt alternativ");
                        return true;

                }            
            return false;
        }
    }
}
