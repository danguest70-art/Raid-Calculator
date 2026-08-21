using RaidCalculator.Buffs;

namespace RaidCalculator;

public class Champion
{
    // misc
    public bool IsChampion;
    public string Name;
    public ConsoleColor OutputColour;
    
    // Turn Meter
    public double Speed => GetValueWithBuffsApplied(ChampionStat.Speed, BaseSpeed);
    public double BaseSpeed;
    public double TurnMeter;
    public int TurnCounter = 0;
    public int ExtraTurns = 0;
    public Effect[] Effects;

    // Damage Calculation
    public double Health;
    public double Defence => GetValueWithBuffsApplied(ChampionStat.Defence, BaseDefence);
    public double BaseDefence;
    public double Attack => GetValueWithBuffsApplied(ChampionStat.Attack, BaseAttack);
    public double BaseAttack;
    public double Multiplier;
    public DamageType DamageType;
    public double CritRate;
    public double CritDamage;

    public Buff[] Buffs;
    public List<AppliedBuff> ActiveBuffs = [];
    
    public Champion(
        string name, 
        double speed, 
        double turnMeter, 
        ConsoleColor outputColour, 
        Effect[] effects,
        Buff[] buffs,
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
        Effects = effects;
        Health = health;
        BaseDefence = defence;
        BaseAttack = attack;
        Multiplier = multiplier;
        DamageType = damageType;
        CritDamage = critDamage;
        CritRate = critRate;
        BaseSpeed = speed;
        Buffs = buffs;
    }

    public double PerTicTurnMeter() => Speed * 0.07;

    public void IncrementTurns()
    {
        TurnCounter += 1;
    }

    public double GetValueWithBuffsApplied(ChampionStat affectedStat, double baseValue)
    {
        var buffs = ActiveBuffs.Where(b => b.AffectedStat == affectedStat).ToArray();

        var valueWithBuffsApplied = baseValue;

        foreach (var buff in buffs) 
        {
            if (buff.Multiplier != null)
                valueWithBuffsApplied *= buff.Multiplier.Value;

            if (buff.FlatRate != null)
                valueWithBuffsApplied += buff.FlatRate.Value;
        }

        return valueWithBuffsApplied;
    }

}