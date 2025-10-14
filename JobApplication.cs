using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker
{
    public class JobApplication
    {
        public string CompanyName { get; set; }
        public string PositionTitle { get; set; }
        public enum Status { Applied, Interview, Offer, Rejected }
        public Status CurrentState { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public int SalaryExpectation { get; set; }

        public JobApplication(string companyName, string positionTitle, Status currentState, DateTime applicationDate, DateTime? responseDate, int salaryExpectation)
        {
            CompanyName = companyName;
            PositionTitle = positionTitle;
            CurrentState = currentState;
            ApplicationDate = applicationDate;
            ResponseDate = responseDate;
            SalaryExpectation = salaryExpectation;
        }

        public int GetDaysSinceApplied()
        {
            TimeSpan diff = DateTime.Now - ApplicationDate;
            return diff.Days;
        }

        public void GetSummary()
        {
            Console.WriteLine($"{PositionTitle} på {CompanyName}. Ansökte: {ApplicationDate.ToShortDateString()} (för {GetDaysSinceApplied} dagar sedan). Status: {CurrentState}. ");
        }
    }
}
