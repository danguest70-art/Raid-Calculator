namespace RaidCalculator.Buffs;

public class SpeedIncrease : Buff
{
    public SpeedIncrease()
    {
        Name = "Speed Increase";
        BuffDuration = 2;
        Priority = 4;
        BuffCoolDown = 5;
    }

    public override void SetBuffsInternal(Champion[] champions, Champion? caster = null)
    {
        foreach (var champion in champions)
        {
            champion.ActiveBuffs.Add(new AppliedBuff(BuffDuration, this));
            champion.Speed += champion.BaseSpeed * 0.3;
        }
    }

    public override void RemoveBuff(Champion champion)
    {
        champion.Speed -= champion.BaseSpeed * 0.3;
    }

    public override Champion[] AppliesTo(Champion[] champions)
    {
        return champions.Where(c => c.IsChampion).ToArray(); 
    }
}