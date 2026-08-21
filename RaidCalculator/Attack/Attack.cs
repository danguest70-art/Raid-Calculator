namespace RaidCalculator.Attack;

public abstract class Attack : ISkillAction
{
    public string Name { get; set; } = "";

    public void Execute(ActionContext context, Champion[] champions, Champion caster)
    {
        ApplyAttack(context, champions, caster);
    }

    public void ApplyAttack(ActionContext context, Champion[] champions, Champion? attacker = null)
    {
        var pipeline = new AttackPipeline
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
