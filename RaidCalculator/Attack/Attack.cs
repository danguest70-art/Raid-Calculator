namespace RaidCalculator.Attack;

public abstract class Attack
{
    public string Name;

    public void ApplyEffect(Champion[] champions, Champion? caster = null)
    {
        var pipeline = new AttackPipeline()
        {
            Champions = champions,
            Caster = caster
        };

        ConfigureEffectPipeline(pipeline);

        pipeline.Run();
    }

    public abstract void ConfigureEffectPipeline(AttackPipeline pipeline);
}