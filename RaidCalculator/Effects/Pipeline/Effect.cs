using RaidCalculator.Effects;

namespace RaidCalculator;

public abstract class Effect
{
    public int EffectCoolDown = 0;
    public int CurrentCoolDown = 0;
    public string Name;
    public int Priority = 0;

    public void ApplyEffect(Champion[] champions, Champion? caster = null)
    {
        if (CurrentCoolDown == 0)
        {
            var pipeline = new EffectPipeline
            {
                Champions = champions,
                Caster = caster
            };

            ConfigureEffectPipeline(pipeline);

            pipeline.Run();

            CurrentCoolDown = EffectCoolDown;
        }
    }
    
    public void ReduceCoolDown()
    {
        if (CurrentCoolDown >= 1)
        {
            CurrentCoolDown -= 1;
        }
    }

    public abstract void ConfigureEffectPipeline(EffectPipeline pipeline);
}