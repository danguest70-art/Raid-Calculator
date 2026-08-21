namespace RaidCalculator.Attack;

public class BasicAttack : Attack
{
    public override void ConfigureAttackPipeline(AttackPipeline pipeline)
    {
        pipeline
            .Then(AttackSteps.GetBasicTargets)
            .Then(AttackSteps.DealDamage);
    }
}