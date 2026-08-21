using RaidCalculator.Results;

namespace RaidCalculator.Attack;

public static class AttackSteps
{
    public static void DealDamage(AttackPipeline pipeline)
    {
        var attacker = pipeline.Attacker;
        if (attacker is null)
            return;

        var attackResult = pipeline.Context.AttackResult;
        if (attackResult is null)
            return;

        foreach (var target in pipeline.Champions)
        {
            var result = Calculate(attacker, target);
            target.Health -= result.Damage;
            attackResult.DamageResults.Add(result);

            if (result.IsCritical)
                attackResult.Critical = true;

            attackResult.Hit = true;
        }
    }

    public static void GetBasicTargets(AttackPipeline pipeline)
    {
        if (pipeline.Attacker is null)
        {
            pipeline.Champions = [];
            return;
        }

        pipeline.Champions = pipeline.Attacker.IsChampion
            ? pipeline.Champions.Where(c => !c.IsChampion).ToArray()
            : pipeline.Champions.Where(c => c.IsChampion).ToArray();
    }

    private static DamageResult Calculate(Champion attacker, Champion target)
    {
        var variance = GetVariance();
        var isCrit = GetIsCriticalHit(attacker.CritRate);
        var baseDamage = GetTrueDamage(attacker, target);
        var defenceMitigation = 1 - 0.85 * (1 - Math.Exp(-target.Defence / 1500));
        var damage = baseDamage * defenceMitigation * variance;

        if (isCrit)
            damage *= attacker.CritDamage;

        return new DamageResult
        {
            Attacker = attacker,
            Target = target,
            Damage = damage,
            BaseDamage = baseDamage,
            Mitigation = defenceMitigation,
            Variance = variance,
            IsCritical = isCrit
        };
    }

    private static double GetVariance()
    {
        return Random.Shared.NextDouble() * (1.1 - 0.9) + 0.9;
    }

    private static bool GetIsCriticalHit(double critRate)
    {
        return Random.Shared.NextDouble() <= critRate;
    }

    private static double GetTrueDamage(Champion attacker, Champion target)
    {
        return attacker.DamageType switch
        {
            DamageType.Health => attacker.MaxHp * attacker.Multiplier,
            DamageType.Attack => attacker.Attack * attacker.Multiplier,
            DamageType.Defence => attacker.Defence * attacker.Multiplier,
            DamageType.EnemyMaxHp => target.MaxHp * attacker.Multiplier,
            _ => throw new NotImplementedException()
        };
    }
}
