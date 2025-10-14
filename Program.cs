namespace JobApplicationTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JobManager applicationManager = new JobManager();

            bool runProgram = true;

            while (runProgram)
            {
                runProgram = MenuHelper.ShowMenu(applicationManager);
            }
            
        }
    }
}
