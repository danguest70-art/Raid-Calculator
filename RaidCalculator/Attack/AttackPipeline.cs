using RaidCalculator.Results;

namespace RaidCalculator.Attack;

public class AttackPipeline
{
    public ActionContext Context;
    public Champion[] Champions { get; set; }
    public Champion? Attacker { get; set; }

    private readonly List<Action<AttackPipeline>> _steps = [];

    public AttackPipeline Then(Action<AttackPipeline> step)
    {
        _steps.Add(step);
        return this;
    }

    /// <summary>
    /// Forks the pipeline into two branches with their own champion sets and steps.
    /// Example: .Split(left => left.Then(TestOutput1), right => right.Then(TestOutput3))
    /// </summary>
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
                Champions = parent.Champions.Where(leftPredicate).ToArray(),
                Attacker = parent.Attacker
            };
            configureLeft(left);
            left.Run();

            var right = new AttackPipeline
            {
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
        Context.AttackResult = new AttackResult
        {
            Attacker = Attacker!
        };
        
        foreach (var step in _steps)
        {
            step(this);
        }
    }
}
