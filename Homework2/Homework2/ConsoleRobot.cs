namespace Homework2;

public class ConsoleRobot
{
    public void WriteMassage(string massage)
    {
        Console.WriteLine(massage);
    }

    public string? ReadInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
}