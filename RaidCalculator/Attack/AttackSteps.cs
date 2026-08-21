using RaidCalculator.Results;

namespace RaidCalculator.Attack;

public static class AttackSteps
{
    public static void DealDamage(AttackPipeline pipeline)
    {
        foreach (var target in pipeline.Champions)
        {
            var result = Calculate(pipeline.Attacker, target);

            target.Health -= result.Damage;

            pipeline.Context.AttackResult.DamageResults.Add(result);
        }
    }

    public static void GetBasicTargets(AttackPipeline pipeline)
    {
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

        return new DamageResult()
        {
            Attacker = attacker,
            Target = target,
            Damage = damage,
        };
    }

    private static double GetVariance()
    {
        Random random = new Random();
        return random.NextDouble() * (1.1 - 0.9) + 0.9;
    }

    private static bool GetIsCriticalHit(double critRate)
    {
        Random random = new Random();
        return random.NextDouble() <= critRate;
    }

    private static double GetTrueDamage(Champion attacker, Champion target)
    {
        double trueDamage = attacker.DamageType switch
        {
            DamageType.Health => attacker.Health * attacker.Multiplier,
            DamageType.Attack => attacker.Attack * attacker.Multiplier,
            DamageType.Defence => attacker.Defence * attacker.Multiplier,
            DamageType.EnemyMaxHp => target.MaxHp * attacker.Multiplier,
            _ => throw new NotImplementedException()
        };

        return trueDamage;
    }
}