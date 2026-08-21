using RaidCalculator;
using RaidCalculator.Buffs;
using RaidCalculator.Effects;
using RaidCalculator.Helpers;

List<Champion> champions =
[
     new Champion("A", 90,0, ConsoleColor.Green, [Skills.EmptySkill], 100000, 294, 100, 0, DamageType.Health, 0.15, 1.5, false),
     new Champion("B", 150,0, ConsoleColor.Yellow, [Skills.BoonOfSpeed, Skills.EmptySkill], 22800, 100, 100, 0, DamageType.Health, 2, 1.5),
     new Champion("C", 100,0, ConsoleColor.Red, [Skills.EmptySkill], 22800, 100, 100, 0, DamageType.Health, 2, 1.5),
     
];


List<Champion> deadChampions = [];

var boss = champions.Where(c => !c.IsChampion).ToArray();
var allies = champions.Where(c => c.IsChampion).ToArray();

for (int i = 0; i < 10; i++)
{
    var nextChampion = TurnMeterHelper.CalculateNextTurn(champions.ToArray());

    var skill = SkillHelper.GetNextSkill(nextChampion);

    if (skill == null)
        break;
    
    EffectHelper.ApplyEffect(champions.ToArray(), nextChampion, skill);
    
    BuffHelper.UpdateBuff(champions.ToArray(), nextChampion, skill);

    SkillHelper.DecrementSkillCoolDown(skill);

    if (nextChampion.IsChampion)
    {
        DamageHelper.CalculateDamage(boss, nextChampion);
    }
    else
    {
        DamageHelper.CalculateDamage(allies, nextChampion);
    }

    var championsWithZeroHealth = champions
        .Where(c => c.Health <= 0)
        .ToList();

    foreach (var deadChampion in championsWithZeroHealth)
    {
        champions.Remove(deadChampion);
        deadChampions.Add(deadChampion);
    }
}