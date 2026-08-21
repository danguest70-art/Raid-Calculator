namespace RaidCalculator.Buffs;

public class BuffPipeline
{
    public Buff Buff { get; set; } = null!;
    public ActionContext Context { get; set; } = null!;
    public Champion[] Champions { get; set; } = [];
    public Champion? Caster { get; set; }

    private readonly List<Action<BuffPipeline>> _steps = [];

    public BuffPipeline Then(Action<BuffPipeline> step)
    {
        _steps.Add(step);
        return this;
    }

    public BuffPipeline ThenIf(Func<BuffPipeline, bool> condition, Action<BuffPipeline> step)
    {
        _steps.Add(pipeline =>
        {
            if (condition(pipeline))
                step(pipeline);
        });
        return this;
    }

    public BuffPipeline Split(
        Action<BuffPipeline> configureLeft,
        Action<BuffPipeline> configureRight)
    {
        _steps.Add(parent =>
        {
            var left = new BuffPipeline
            {
                Buff = parent.Buff,
                Context = parent.Context,
                Champions = parent.Champions,
                Caster = parent.Caster
            };
            configureLeft(left);
            left.Run();

            var right = new BuffPipeline
            {
                Buff = parent.Buff,
                Context = parent.Context,
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
            step(this);
    }
}
