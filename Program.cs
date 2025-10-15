namespace JobApplicationTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationManager applicationManager = new ApplicationManager();

            bool runProgram = true;

            while (runProgram)
            {
                runProgram = MenuHelper.ShowMenu(applicationManager);
            }
            
        }
    }
}
