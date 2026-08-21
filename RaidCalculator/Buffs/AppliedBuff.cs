namespace RaidCalculator.Buffs;

public class AppliedBuff
{
    public int TurnsRemaining;
    public double? Multiplier;
    public double? FlatRate;
    public ChampionStat AffectedStat;
    public int BuffOrder;

    public AppliedBuff(int turnsRemaining, ChampionStat affectedStat, double? multiplier, double? flatRate)
    {
        TurnsRemaining = turnsRemaining;
        AffectedStat = affectedStat;
        Multiplier = multiplier; 
        FlatRate = flatRate;
    }
}
