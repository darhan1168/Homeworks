namespace Homework2;

public class ConsoleRobot
{
    public string? ReadInput()
    {
        Console.Write("Answer:");
        return Console.ReadLine();
    }

    public string? GetNewValue()
    {
        Console.WriteLine("Enter new value");
        return ReadInput();
    }

    public int GetSequenceNumber()
    {
        Console.WriteLine("Enter sequence number");
        return int.Parse(ReadInput() ?? string.Empty);
    }
}