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
        pipeline.Champions = pipeline.Caster is null ? [] : [pipeline.Caster];
    }

    public static void ApplySpeedMultiplierBuffToChampions(BuffPipeline pipeline, double value, int duration)
    {
        ApplyStatMultiplier(pipeline, ChampionStat.Speed, value, duration);
    }

    public static void ApplyDefenceMultiplierBuffToChampions(BuffPipeline pipeline, double value, int duration)
    {
        ApplyStatMultiplier(pipeline, ChampionStat.Defence, value, duration);
    }

    public static void ApplyStatMultiplier(
        BuffPipeline pipeline,
        ChampionStat stat,
        double multiplier,
        int duration)
    {
        var buffName = pipeline.Buff.Name;

        foreach (var champion in pipeline.Champions)
        {
            var existing = champion.ActiveBuffs.FirstOrDefault(b =>
                b.Name == buffName && b.AffectedStat == stat);

            if (existing is null)
            {
                champion.ActiveBuffs.Add(new AppliedBuff(buffName, duration, stat, multiplier, null));
                continue;
            }

            existing.TurnsRemaining = Math.Max(existing.TurnsRemaining, duration);
            if (existing.Multiplier is null || multiplier > existing.Multiplier.Value)
                existing.Multiplier = multiplier;
        }
    }
}
