namespace RaidCalculator;

public static class OutputHelper
{
    public static void OutputStepResults(Champion[] champions)
    {
        Console.WriteLine(new string('-', 40));

        var orderedChampions = champions.OrderByDescending(champion => champion.TurnMeter).ToList();

        foreach (Champion champion in orderedChampions)
        {
            WriteColour($"champion:{champion.Name}, TM:{champion.TurnMeter}", champion.OutputColour);
        }

        Console.WriteLine(new string('-', 40));
    }

    private static void WriteColour(string text, ConsoleColor colour)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = colour;
        Console.WriteLine(text);
        Console.ForegroundColor = previous;
    }
}