using RaidCalculator.Buffs;

namespace RaidCalculator;

public class Champion
{
    public bool IsChampion;
    public string Name;
    public ConsoleColor OutputColour;

    public double Speed => GetValueWithBuffsApplied(ChampionStat.Speed, BaseSpeed);
    public double BaseSpeed;
    public double TurnMeter;
    public int TurnCounter;
    public int ExtraTurns;
    public Skill[] Skills;

    public double MaxHp;
    public double Health;
    public double Defence => GetValueWithBuffsApplied(ChampionStat.Defence, BaseDefence);
    public double BaseDefence;
    public double Attack => GetValueWithBuffsApplied(ChampionStat.Attack, BaseAttack);
    public double BaseAttack;
    public double Multiplier;
    public DamageType DamageType;
    public double CritRate => GetValueWithBuffsApplied(ChampionStat.CritRate, BaseCritRate);
    public double BaseCritRate;
    public double CritDamage => GetValueWithBuffsApplied(ChampionStat.CritDamage, BaseCritDamage);
    public double BaseCritDamage;

    public List<AppliedBuff> ActiveBuffs = [];

    public Champion(
        string name,
        double speed,
        double turnMeter,
        ConsoleColor outputColour,
        Skill[] skills,
        double health,
        double defence,
        double attack,
        double multiplier,
        DamageType damageType,
        double critRate,
        double critDamage,
        bool isChampion = true)
    {
        Name = name;
        TurnMeter = turnMeter;
        OutputColour = outputColour;
        IsChampion = isChampion;
        Skills = skills.Select(s => s.Clone()).ToArray();
        Health = health;
        BaseDefence = defence;
        BaseAttack = attack;
        Multiplier = multiplier;
        DamageType = damageType;
        BaseCritDamage = critDamage;
        BaseCritRate = critRate;
        BaseSpeed = speed;
        MaxHp = health;
    }

    public double PerTickTurnMeter() => Speed * 0.07;

    public void IncrementTurns()
    {
        TurnCounter += 1;
    }

    public double GetValueWithBuffsApplied(ChampionStat affectedStat, double baseValue)
    {
        var valueWithBuffsApplied = baseValue;

        foreach (var buff in ActiveBuffs.Where(b => b.AffectedStat == affectedStat))
        {
            if (buff.Multiplier is not null)
                valueWithBuffsApplied *= buff.Multiplier.Value;

            if (buff.FlatRate is not null)
                valueWithBuffsApplied += buff.FlatRate.Value;
        }

        return valueWithBuffsApplied;
    }
}
