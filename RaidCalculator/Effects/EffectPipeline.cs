namespace RaidCalculator.Effects;

public class EffectPipeline
{
    public Champion[] Champions { get; set; } = [];
    public Champion? Caster { get; set; }

    private readonly List<Action<EffectPipeline>> _steps = [];

    public EffectPipeline Then(Action<EffectPipeline> step)
    {
        _steps.Add(step);
        return this;
    }

    /// <summary>
    /// Forks the pipeline into two branches with their own champion sets and steps.
    /// Example: .Split(left => left.Then(TestOutput1), right => right.Then(TestOutput3))
    /// </summary>
    public EffectPipeline Split(
        Action<EffectPipeline> configureLeft,
        Action<EffectPipeline> configureRight,
        Func<Champion, bool>? leftPredicate = null)
    {
        leftPredicate ??= c => c.IsChampion;

        _steps.Add(parent =>
        {
            var left = new EffectPipeline
            {
                Champions = parent.Champions.Where(leftPredicate).ToArray(),
                Caster = parent.Caster
            };
            configureLeft(left);
            left.Run();

            var right = new EffectPipeline
            {
                Champions = parent.Champions.Where(c => !leftPredicate(c)).ToArray(),
                Caster = parent.Caster
            };
            configureRight(right);
            right.Run();
        });

        return this;
    }

    public void Run()
    {
        foreach (var step in _steps)
        {
            step(this);
        }
    }
}
