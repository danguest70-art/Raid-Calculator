namespace RaidCalculator.Helpers;

public static class BuffHelper
{
    public static void TickBuffs(Champion champion)
    {
        foreach (var appliedBuff in champion.ActiveBuffs.ToList())
        {
            appliedBuff.TurnsRemaining--;

            if (appliedBuff.TurnsRemaining <= 0)
                champion.ActiveBuffs.Remove(appliedBuff);
        }
    }
}
