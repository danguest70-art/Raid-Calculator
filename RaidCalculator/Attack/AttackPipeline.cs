using RaidCalculator.Results;

namespace RaidCalculator.Attack;

public class AttackPipeline
{
    public ActionContext Context { get; set; } = null!;
    public Champion[] Champions { get; set; } = [];
    public Champion? Attacker { get; set; }

    private readonly List<Action<AttackPipeline>> _steps = [];

    public AttackPipeline Then(Action<AttackPipeline> step)
    {
        _steps.Add(step);
        return this;
    }

    public AttackPipeline ThenIf(Func<AttackPipeline, bool> condition, Action<AttackPipeline> step)
    {
        _steps.Add(pipeline =>
        {
            if (condition(pipeline))
                step(pipeline);
        });
        return this;
    }

    public AttackPipeline Split(
        Action<AttackPipeline> configureLeft,
        Action<AttackPipeline> configureRight,
        Func<Champion, bool>? leftPredicate = null)
    {
        leftPredicate ??= c => c.IsChampion;

        _steps.Add(parent =>
        {
            var left = new AttackPipeline
            {
                Context = parent.Context,
                Champions = parent.Champions.Where(leftPredicate).ToArray(),
                Attacker = parent.Attacker
            };
            configureLeft(left);
            left.Run();

            var right = new AttackPipeline
            {
                Context = parent.Context,
                Champions = parent.Champions.Where(c => !leftPredicate(c)).ToArray(),
                Attacker = parent.Attacker
            };
            configureRight(right);
            right.Run();
        });

        return this;
    }

    public void Run()
    {
        Context.AttackResult ??= new AttackResult
        {
            Attacker = Attacker!
        };

        foreach (var step in _steps)
            step(this);
    }
}
