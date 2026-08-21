namespace RaidCalculator.Attack;

public class AttackPipeline
{
    public Champion[] Champions { get; set; } = [];
    public Champion? Caster { get; set; }

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
                Caster = parent.Caster
            };
            configureLeft(left);
            left.Run();

            var right = new AttackPipeline
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
