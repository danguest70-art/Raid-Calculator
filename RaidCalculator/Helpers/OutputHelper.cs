namespace RaidCalculator.Helpers;

public static class OutputHelper
{
    public static void OutputStepResults(Champion[] champions)
    {
        Console.WriteLine(new string('-', 40));

        var boss = champions.FirstOrDefault(c => !c.IsChampion);
        if (boss is not null)
            Console.WriteLine($"Boss Turn: {boss.TurnCounter}");

        foreach (var champion in champions.OrderByDescending(c => c.TurnMeter))
            WriteColour($"champion:{champion.Name}, TM:{champion.TurnMeter}", champion.OutputColour);
    }

    private static void WriteColour(string text, ConsoleColor colour)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = colour;
        Console.WriteLine(text);
        Console.ForegroundColor = previous;
    }
}
