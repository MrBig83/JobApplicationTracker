namespace JobApplicationTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Job Application Tracker 💼";

            ApplicationManager applicationManager = new ApplicationManager();

            bool runProgram = true;

            while (runProgram)
            {
                runProgram = MenuHelper.ShowMenu(applicationManager);
            }
            
        }
    }
}
