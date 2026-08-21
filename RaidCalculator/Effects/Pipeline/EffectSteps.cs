namespace RaidCalculator.Effects;

public static class EffectSteps
{
    public static void FilterToAllies(EffectPipeline pipeline)
    {
        pipeline.Champions = pipeline.Champions.Where(c => c.IsChampion).ToArray();
    }

    public static void FilterToLowestHealthChampion(EffectPipeline pipeline)
    {
        var champion = pipeline.Champions.MinBy(c => c.Health);
        pipeline.Champions = champion is null ? [] : [champion];
    }

    public static void FilterOutCaster(EffectPipeline pipeline)
    {
        pipeline.Champions = pipeline.Champions.Where(c => c != pipeline.Caster).ToArray();
    }

    public static void FilterToEnemies(EffectPipeline pipeline)
    {
        pipeline.Champions = pipeline.Champions.Where(c => !c.IsChampion).ToArray();
    }

    public static void FilterToCaster(EffectPipeline pipeline)
    {
        pipeline.Champions = pipeline.Caster is null ? [] : [pipeline.Caster];
    }

    public static void AddTurnToChampions(EffectPipeline pipeline)
    {
        foreach (var champion in pipeline.Champions)
            champion.ExtraTurns++;
    }

    public static void IncreaseTurnMeterForChampions(EffectPipeline pipeline, double value)
    {
        foreach (var champion in pipeline.Champions)
            champion.TurnMeter += value;
    }

    public static void HealChampions(EffectPipeline pipeline, double value)
    {
        foreach (var champion in pipeline.Champions)
        {
            champion.Health = Math.Min(champion.MaxHp, champion.Health + champion.MaxHp * value);
        }
    }
}
