using RaidCalculator;
using RaidCalculator.Buffs;
using RaidCalculator.Helpers;

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
        DamageHelper.CalculateDamage(boss, nextChampion);
    }
    else
    {
        DamageHelper.CalculateDamage(allies, nextChampion);
    }
}
