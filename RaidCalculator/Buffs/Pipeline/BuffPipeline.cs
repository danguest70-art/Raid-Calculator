namespace RaidCalculator.Buffs;

public class BuffPipeline
{
    public Champion[] Champions { get; set; } = [];
    public Champion? Caster { get; set; }

    private readonly List<Action<BuffPipeline>> _steps = [];

    public BuffPipeline Then(Action<BuffPipeline> step)
    {
        _steps.Add(step);
        return this;
    }

    /// <summary>
    /// Forks the pipeline into two branches with their own champion sets and steps.
    /// Example: .Split(left => left.Then(TestOutput1), right => right.Then(TestOutput3))
    /// </summary>
    public BuffPipeline Split(
        Action<BuffPipeline> configureLeft,
        Action<BuffPipeline> configureRight,
        Func<Champion, bool>? leftPredicate = null)
    {
        leftPredicate ??= c => c.IsChampion;

        _steps.Add(parent =>
        {
            var left = new BuffPipeline
            {
                Champions = parent.Champions.Where(leftPredicate).ToArray(),
                Caster = parent.Caster
            };
            configureLeft(left);
            left.Run();

            var right = new BuffPipeline
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

