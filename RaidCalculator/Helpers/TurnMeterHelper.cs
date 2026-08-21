namespace RaidCalculator.Helpers;

public static class TurnMeterHelper
{
    public static Champion CalculateNextTurn(Champion[] champions)
    {
        Champion nextChampion;
        var championWithExtraTurn = GetChampionWithExtraTurn(champions);

        if (championWithExtraTurn is not null)
        {
            championWithExtraTurn.ExtraTurns--;
            nextChampion = championWithExtraTurn;
        }
        else
        {
            if (!champions.Any(c => c.TurnMeter >= 100))
            {
                var minTicksTo100 = GetMinTicksTo100(champions);
                UpdateChampionsTurnMeter(champions, minTicksTo100);
            }

            nextChampion = champions.MaxBy(champion => champion.TurnMeter)!;
        }

        OutputHelper.OutputStepResults(champions);
        nextChampion.TurnMeter = 0;
        nextChampion.IncrementTurns();

        return nextChampion;
    }

    private static double GetMinTicksTo100(Champion[] champions)
    {
        return champions.Min(c =>
        {
            var perTick = c.PerTickTurnMeter();
            if (perTick <= 0)
                return double.MaxValue;

            var remaining = 100 - c.TurnMeter;
            return remaining <= 0 ? 0 : Math.Ceiling(remaining / perTick);
        });
    }

    private static void UpdateChampionsTurnMeter(Champion[] champions, double ticksTo100)
    {
        foreach (var champion in champions)
            champion.TurnMeter += ticksTo100 * champion.PerTickTurnMeter();
    }

    private static Champion? GetChampionWithExtraTurn(Champion[] champions)
    {
        return champions.FirstOrDefault(c => c.ExtraTurns > 0);
    }
}
