using RaidCalculator.Buffs;

namespace RaidCalculator;

public class Champion
{
    // misc
    public bool IsChampion;
    public string Name;
    public ConsoleColor OutputColour;
    
    // Turn Meter
    public double Speed;
    public double BaseSpeed;
    public double TurnMeter;
    public int TurnCounter = 0;
    public int ExtraTurns = 0;
    public Effect[] Effects;
    
    // Damage Calculation
    public double Health;
    public double Defence;
    public double Attack;
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
        Speed = speed;
        TurnMeter = turnMeter;
        OutputColour = outputColour;
        IsChampion = isChampion;
        Effects = effects;
        Health = health;
        Defence = defence;
        Attack = attack;
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
}