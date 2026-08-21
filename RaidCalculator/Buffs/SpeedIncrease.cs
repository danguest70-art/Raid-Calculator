namespace RaidCalculator.Buffs;

public class SpeedIncrease : Buff
{
    public double SpeedMultiplier;

    public SpeedIncrease(
        int duration = 2,
        int cooldown = 5,
        int priority = 4,
        double speedMultiplier = 1.3)
        : base("Speed Increase", duration, cooldown, priority)
    {
        SpeedMultiplier = speedMultiplier;
    }

    public override void ApplyBuffInternal(Champion[] champions, Champion? caster = null)
    {
        foreach (var champion in champions)
        {
            champion.ActiveBuffs.Add(new AppliedBuff(BuffDuration, ChampionStat.Speed, SpeedMultiplier, null));
        }
    }

    public override Champion[] AppliesTo(Champion[] champions)
    {
        return champions.Where(c => c.IsChampion).ToArray();
    }
}
