namespace RaidCalculator.Buffs;

public class BuffPipeline
{
    public Buff Buff { get; set; }
    public ActionContext Context { get; set; }
    public Champion[] Champions { get; set; }
    public Champion? Caster { get; set; }

    private readonly List<Action<BuffPipeline>> _steps = [];

    public BuffPipeline Then(Action<BuffPipeline> step)
    {
        _steps.Add(step);
        return this;
    }

    public BuffPipeline ThenIf(bool condition, Action<BuffPipeline> step)
    {
        if (condition)
        {
            _steps.Add(step);
        }

        return this;
    }

    /// <summary>
    /// Forks the pipeline into two branches with their own champion sets and steps.
    /// Example: .Split(left => left.Then(TestOutput1), right => right.Then(TestOutput3))
    /// </summary>
    public BuffPipeline Split(
        Action<BuffPipeline> configureLeft,
        Action<BuffPipeline> configureRight)
    {
        _steps.Add(parent =>
        {
            var left = new BuffPipeline
            {
                Champions = parent.Champions,
                Caster = parent.Caster
            };
            configureLeft(left);
            left.Run();

            var right = new BuffPipeline
            {
                Champions = parent.Champions,
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

