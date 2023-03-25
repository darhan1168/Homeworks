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
        WriteMassage("Enter new value");
        return ReadInput();
    }

    public int GetSequenceNumber()
    {
        WriteMassage("Enter sequence number");
        return int.Parse(ReadInput() ?? string.Empty);
    }
}