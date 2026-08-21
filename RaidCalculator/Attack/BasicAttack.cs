namespace RaidCalculator.Attack;

public class BasicAttack : Attack
{
    public BasicAttack()
    {
        Name = "Basic Attack";
    }

    public override void ConfigureAttackPipeline(AttackPipeline pipeline)
    {
        pipeline
            .Then(AttackSteps.GetBasicTargets)
            .Then(AttackSteps.DealDamage);
    }
}
