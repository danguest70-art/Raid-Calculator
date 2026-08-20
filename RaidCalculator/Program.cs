using RaidCalculator;

// The effects added for champion B match: https://hellhades.com/raid/champions/vagabond/
Champion[] champions =
{
     new Champion("A", 90,0, ConsoleColor.Green, [], false),
     new Champion("B", 150,0, ConsoleColor.Red, [new AdvancedTurnMeterEffect()]),
     new Champion("C", 100,0, ConsoleColor.Yellow, []),
};

for (int i = 0; i < 10; i++)
{
    TurnMeterHelper.CalculateNextTurn(champions);
}