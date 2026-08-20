namespace RaidCalculator.Buffs;

public class AppliedBuff
{
    public int TurnsRemaining = 0;
    public Buff Buff;

    public AppliedBuff(int turnsRemaining, Buff buff)
    {
        TurnsRemaining = turnsRemaining;
        Buff = buff;
    }
}