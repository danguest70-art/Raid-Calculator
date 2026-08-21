namespace RaidCalculator.Helpers;

public static class DamageHelper
{
    public static void CalculateDamage(Champion[] targets, Champion attacker)
    {
        var variance = GetVariance();
        var isCrit = GetIsCriticalHit(attacker.CritRate);        

        foreach (var target in targets)
        {
            var trueDamage = GetTrueDamage(attacker, target);

            var defenceMitigation = 1 - 0.85 * (1 - Math.Pow(Math.E, -target.Defence / 1500));

            var realDamage = trueDamage * defenceMitigation * variance;

            if (isCrit)
                realDamage *= attacker.CritDamage;

            target.Health -= realDamage;
        }
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

