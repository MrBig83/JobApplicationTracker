using static JobApplicationTracker.JobApplication;

namespace JobApplicationTracker
{
    public class ColorHelper
    {

        public static void ColorizeStatus(Status status)
        {
            string symbol = string.Empty;
            switch (status)
            {
                case Status.Applied:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Status.Interview:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case Status.Offer:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Status.Rejected:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
            Console.Write(status);
            Console.ResetColor();
        }
    }
}