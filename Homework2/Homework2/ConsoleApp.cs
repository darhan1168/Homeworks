namespace Homework2;

public class ConsoleApp
{
    public void App()
        {
            ConsoleRobot consoleRobot = new ConsoleRobot();

            while (true)
            {
                Console.WriteLine("Choose what you want (1 - Project status review, 2 - Addition of options, 3 - Deletion of options, 4 - Replacement of options, 5 - Stop console app)");
                string? answerUserMethod = consoleRobot.ReadInput();

                switch (answerUserMethod)
                {
                    case "1":
                        ConsoleAppForProjectReview consoleAppForProjectReview = new ConsoleAppForProjectReview();
                        
                        consoleAppForProjectReview.ConsoleForProjectReview();
                        break;
                    case "2":
                        ConsoleAppForAdding consoleAppForAdding = new ConsoleAppForAdding();
                        
                        consoleAppForAdding.ConsoleForAdding();
                        break;
                    case "3":
                        ConsoleAppForDeletion consoleAppForDeletion = new ConsoleAppForDeletion();
                        
                        consoleAppForDeletion.ConsoleForDeletion();
                        break;
                    case "4":
                        ConsoleAppForReplacing consoleAppForReplacing = new ConsoleAppForReplacing();
                        
                        consoleAppForReplacing.ConsoleForReplacing();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("- Your answer should be 1 to 6,  try again");
                        break;
                }
            }
        }
}