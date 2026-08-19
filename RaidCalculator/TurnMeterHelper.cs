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
}