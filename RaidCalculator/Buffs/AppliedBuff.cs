namespace RaidCalculator.Buffs;

public class AppliedBuff
{
    public int TurnsRemaining;
    public Buff Buff;

    public AppliedBuff(int turnsRemaining, Buff buff)
    {
        TurnsRemaining = turnsRemaining;
        Buff = buff;
    }
}
