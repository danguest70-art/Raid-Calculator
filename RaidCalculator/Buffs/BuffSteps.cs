using RaidCalculator.Effects;

namespace RaidCalculator.Buffs;

public static class BuffSteps
{
    public static void FilterToAllies(BuffPipeline pipeline)
    {
        pipeline.Champions = pipeline.Champions.Where(c => c.IsChampion).ToArray();
    }

    public static void FilterToEnemies(BuffPipeline pipeline)
    {
        pipeline.Champions = pipeline.Champions.Where(c => !c.IsChampion).ToArray();
    }

    public static void FilterToCaster(BuffPipeline pipeline)
    {
        pipeline.Champions = [pipeline.Caster];
    }

    public static void ApplySpeedMultiplierBuffToChampions(BuffPipeline pipeline, double value, int duration)
    {
        foreach (var champion in pipeline.Champions)
        {
            champion.ActiveBuffs.Add(new AppliedBuff(duration, ChampionStat.Speed, value, null));
        }
    }
}
