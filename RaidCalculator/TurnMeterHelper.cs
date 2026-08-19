namespace RaidCalculator;

public static class TurnMeterHelper
{
    public static void CalculateNextTurn(Champion[] champions)
    {
        var anyAbove100TurnMeter = CheckForAnyChampionsAbove100TurnMeter(champions);

        if (anyAbove100TurnMeter)
        {
            TurnMeterHelper.AddOneTicTurnMeter(champions);
        }
        else
        {
            var minTicksTo100TurnMeter = GetMinTicsTo100(champions);

            UpdateChampionsTurnMeter(champions, minTicksTo100TurnMeter);
        }

        var nextChampion = champions.MaxBy(champion => champion.TurnMeter);
        OutputHelper.OutputStepResults(champions);
        nextChampion.TurnMeter = 0;
    }

    public static void AddOneTicTurnMeter(Champion[] champions)
    {
        foreach (Champion champion in champions)
        {
            champion.TurnMeter = champion.TurnMeter + champion.GetTurnMeterPerTic();
        }
    }

    private static bool CheckForAnyChampionsAbove100TurnMeter(Champion[] champions)
    {
        return champions.Any(c => c.TurnMeter > 100);
    }

    private static double GetMinTicsTo100(Champion[] champions)
    {
        return champions.Min(c => Math.Ceiling((100 - c.TurnMeter) / c.GetTurnMeterPerTic()));
    }

    private static void UpdateChampionsTurnMeter(Champion[] champions, double ticsTo100)
    {
        foreach (Champion champion in champions)
        {
            champion.TurnMeter = champion.TurnMeter + (ticsTo100 * champion.GetTurnMeterPerTic());
        }
    }
}