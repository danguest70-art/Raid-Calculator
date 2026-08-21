using RaidCalculator;
using RaidCalculator.Buffs;

// The effects added for champion B match: https://hellhades.com/raid/champions/vagabond/
Champion[] champions =
{
     new Champion("A", 90,0, ConsoleColor.Green, [], [], 100000, 294, 100, 0.25, DamageType.Health, 0.15, 1.5, false),
     new Champion("B", 180,0, ConsoleColor.Yellow, [new BasicTurnMeterEffect()], [new SpeedIncrease()], 22800, 100, 100, 1.8, DamageType.Health, 2, 1.5),
     new Champion("C", 100,0, ConsoleColor.Red, [], [], 22800, 100, 100, 1.8, DamageType.Health, 2, 1.5),
     
};

var boss = champions.Where(c => !c.IsChampion).ToArray();
var allies = champions.Where(c => c.IsChampion).ToArray();

for (int i = 0; i < 10; i++)
{
    var nextChampion = TurnMeterHelper.CalculateNextTurn(champions);
    
    EffectHelper.ApplyEffect(champions, nextChampion);
    
    BuffHelper.UpdateBuff(champions, nextChampion);
    
    if (nextChampion.IsChampion)
    {
        CalculateDamage(boss, nextChampion);
    }
    else
    {
        CalculateDamage(allies, nextChampion);
    }
}



void CalculateDamage(Champion[] targets, Champion attacker)
{

    Random random = new Random();
    var variance = random.NextDouble() * (1.1 - 0.9) + 0.9;

    var isCrit = random.NextDouble() <= attacker.CritRate;
    
    var boss = champions.FirstOrDefault(c => !c.IsChampion);
    double trueDamage = 0;

    if (attacker.DamageType == DamageType.Health)
    {
        trueDamage = attacker.Health * attacker.Multiplier;
    }
    
    var defenceMitigation = 1 - 0.85 * (1 - Math.Pow(Math.E, -boss.Defence() / 1500));

    var realDamage = trueDamage * defenceMitigation * variance;

    if (isCrit)
    {
        realDamage *= attacker.CritDamage;
    }
    
    foreach (var target in targets)
    {
        target.Health -= realDamage;
    }
}
