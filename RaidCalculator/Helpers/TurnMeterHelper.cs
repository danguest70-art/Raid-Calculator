namespace RaidCalculator;

public static class TurnMeterHelper
{
    public static Champion CalculateNextTurn(Champion[] champions)
    {
        var championWithExtraTurn = GetChampionWithExtraTurn(champions);
        Champion nextChampion;

        if (championWithExtraTurn != null)
        {
            championWithExtraTurn.ExtraTurns --;
            nextChampion = championWithExtraTurn;
        }
        else
        {
            var anyAbove100TurnMeter = CheckForAnyChampionsAbove100TurnMeter(champions);

            if (anyAbove100TurnMeter)
            {
                AddOneTicTurnMeter(champions);
            }
            else
            {
                var minTicksTo100TurnMeter = GetMinTicsTo100(champions);

                UpdateChampionsTurnMeter(champions, minTicksTo100TurnMeter);
            }
            
            nextChampion = champions.MaxBy(champion => champion.TurnMeter);
        }
         
        OutputHelper.OutputStepResults(champions);
        nextChampion.TurnMeter = 0;
        
        nextChampion.IncrementTurns();

        return nextChampion;
    }

    public static void AddOneTicTurnMeter(Champion[] champions)
    {
        foreach (Champion champion in champions)
        {
            champion.TurnMeter += champion.PerTicTurnMeter();
        }
    }

    private static bool CheckForAnyChampionsAbove100TurnMeter(Champion[] champions)
    {
        return champions.Any(c => c.TurnMeter > 100);
    }

    private static double GetMinTicsTo100(Champion[] champions)
    {
        return champions.Min(c => Math.Ceiling((100 - c.TurnMeter) / c.PerTicTurnMeter()));
    }

    private static void UpdateChampionsTurnMeter(Champion[] champions, double ticsTo100)
    {
        foreach (Champion champion in champions)
        {
            champion.TurnMeter += (ticsTo100 * champion.PerTicTurnMeter());
        }
    }

    private static Champion? GetChampionWithExtraTurn(Champion[] champions)
    {
        var championWithExtraTurn = champions.FirstOrDefault(c => c.ExtraTurns > 0);

        return championWithExtraTurn;
    }
}