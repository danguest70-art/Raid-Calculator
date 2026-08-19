namespace RaidCalculator;

public static class TurnMeterHelper
{
    public static void AddOneTicTurnMeter(Champion[] champions)
    {
        foreach (Champion champion in champions)
        {
            champion.TurnMeter = champion.TurnMeter + champion.GetTurnMeterPerTic();
        }
    }

    public static void CalculateNextTurn(Champion[] champions)
    {
        var anyAbove100 = CheckForAnyChampionsAbove100TurnMeter(champions);

        if (anyAbove100)
        {
            TurnMeterHelper.AddOneTicTurnMeter(champions);
        }
        else
        {
            var championClosestTo100 = GetChampionClosestTo100(champions);

            UpdateChampionsTurnMeter(champions, championClosestTo100.TicsTo100);
        }

        var nextChampion = champions.MaxBy(champion => champion.TurnMeter);
        OutputHelper.OutputStepResults(champions);
        nextChampion.TurnMeter = 0;
    }

    private static bool CheckForAnyChampionsAbove100TurnMeter(Champion[] champions)
    {
        var anyAbove100 = false;

        foreach (Champion champion in champions)
        {
            if (champion.TurnMeter > 100)
            {
                anyAbove100 = true;
                break;
            }
        }

        return anyAbove100;
    }

    private static Champion GetChampionClosestTo100(Champion[] champions)
    {
        foreach (Champion champion in champions)
        {
            champion.TicsTo100 = Math.Ceiling((100 - champion.TurnMeter) / champion.GetTurnMeterPerTic());
        }

        return champions.OrderBy(champion => champion.TicsTo100).FirstOrDefault()!;
    }

    private static void UpdateChampionsTurnMeter(Champion[] champions, double ticsTo100)
    {
        foreach (Champion champion in champions)
        {
            champion.TurnMeter = champion.TurnMeter + (ticsTo100 * champion.GetTurnMeterPerTic());
        }
    }
}