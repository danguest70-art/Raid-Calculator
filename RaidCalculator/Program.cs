using RaidCalculator;
using RaidCalculator.Helpers;

List<Champion> champions =
[
     new Champion("A", 90,0, ConsoleColor.Green, [Skills.EmptySkill], 100000, 294, 100, 0.1, DamageType.Health, 0.15, 1.5, false),
     new Champion("B", 150,0, ConsoleColor.Yellow, [Skills.BoonOfSpeed, Skills.SoothingChant], 10000, 100, 100, 0.1, DamageType.Health, 2, 1.5),
     new Champion("C", 100,0, ConsoleColor.Red, [Skills.EmptySkill], 22800, 100, 100, 0.1, DamageType.Health, 2, 1.5),
     
];


List<Champion> deadChampions = [];

var boss = champions.Where(c => !c.IsChampion).ToArray();
var allies = champions.Where(c => c.IsChampion).ToArray();

for (int i = 0; i < 10; i++)
{
    var context = new ActionContext();
    var nextChampion = TurnMeterHelper.CalculateNextTurn(champions.ToArray());
    context.Caster = nextChampion;
    
    var skill = SkillHelper.GetNextSkill(nextChampion);
    context.Skill = skill;
    
    if (skill == null)
        break;
    
    EffectHelper.ApplyEffect(context, champions.ToArray(), nextChampion, skill);
    
    BuffHelper.UpdateBuff(context, champions.ToArray(), nextChampion, skill);
    
    AttackHelper.ApplyAttack(context, champions.ToArray(), nextChampion, skill);
    

    SkillHelper.DecrementSkillCoolDown(skill);
    
    var championsWithZeroHealth = champions
        .Where(c => c.Health <= 0)
        .ToList();

    foreach (var deadChampion in championsWithZeroHealth)
    {
        champions.Remove(deadChampion);
        deadChampions.Add(deadChampion);
    }
}