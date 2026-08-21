namespace RaidCalculator.Effects;

public static class EffectSteps
{
    public static void FilterToAllies(EffectPipeline pipeline)
    {
        pipeline.Champions = pipeline.Champions.Where(c => c.IsChampion).ToArray();
    }

    public static void FilterToEnemies(EffectPipeline pipeline)
    {
        pipeline.Champions = pipeline.Champions.Where(c => !c.IsChampion).ToArray();
    }

    public static void FilterToCaster(EffectPipeline pipeline)
    {
        pipeline.Champions = [pipeline.Caster]; 
    }

    public static void AddTurnToChampions(EffectPipeline pipeline)
    {
        foreach (var chapion in pipeline.Champions)
        {
            chapion.ExtraTurns++;
        }
    }

    public static void IncreaseTurnMeterForChampions(EffectPipeline pipeline, double value)
    {
        foreach (var champion in pipeline.Champions)
        {
            champion.TurnMeter += value;
        }
    }

    public static void HealChampions(EffectPipeline pipeline, int value)
    {
        foreach (var champion in pipeline.Champions)
        {
            champion.Health = champion.MaxHp * value;
        }
    }
}
