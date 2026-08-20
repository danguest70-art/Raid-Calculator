namespace RaidCalculator.Buffs;

public class SpeedIncrease : Buff
{
    public double SpeedMultiplier;

    public SpeedIncrease(
        int duration = 2,
        int cooldown = 5,
        int priority = 4,
        double speedMultiplier = 0.3)
        : base("Speed Increase", duration, cooldown, priority)
    {
        SpeedMultiplier = speedMultiplier;
    }

    public override void ApplyBuffInternal(Champion[] champions, Champion? caster = null)
    {
        foreach (var champion in champions)
        {
            champion.ActiveBuffs.Add(new AppliedBuff(BuffDuration, this));
            champion.Speed += champion.BaseSpeed * SpeedMultiplier;
        }
    }

    public override void RemoveBuff(Champion champion)
    {
        champion.Speed -= champion.BaseSpeed * SpeedMultiplier;
    }

    public override Champion[] AppliesTo(Champion[] champions)
    {
        return champions.Where(c => c.IsChampion).ToArray();
    }
}
