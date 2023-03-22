namespace Homework2;

public class ConsoleRobot
{
    public void WriteMassage(string massage)
    {
        Console.WriteLine(massage);
    }

    public string? ReadInput()
    {
        Console.Write("Answer:");
        return Console.ReadLine();
    }
}