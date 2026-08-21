using RaidCalculator;

var battle = new Battle(
[
    new Champion("A", 90, 0, ConsoleColor.Green, [Skills.EmptySkill()], 100000, 294, 100, 0, DamageType.Health, 0.15, 1.5, false),
    new Champion("B", 150, 0, ConsoleColor.Yellow, [Skills.BoonOfSpeed(), Skills.SoothingChant()], 10000, 100, 100, 0, DamageType.Health, 2, 1.5),
    new Champion("C", 100, 0, ConsoleColor.Red, [Skills.EmptySkill()], 22800, 100, 100, 0, DamageType.Health, 2, 1.5),
]);

battle.RunTurns(10);
