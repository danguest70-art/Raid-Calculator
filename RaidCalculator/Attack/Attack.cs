namespace RaidCalculator.Attack;

public abstract class Attack
{
    public string Name;

    public void ApplyAttack(ActionContext context, Champion[] champions, Champion? attacker = null)
    {
        var pipeline = new AttackPipeline()
        {
            Context = context,
            Champions = champions,
            Attacker = attacker
        };

        ConfigureAttackPipeline(pipeline);

        pipeline.Run();
    }

    public abstract void ConfigureAttackPipeline(AttackPipeline pipeline);
}