using System.ComponentModel.DataAnnotations;
using RaidCalculator;

Champion[] champions =
{
     new Champion("A", 160,0, ConsoleColor.Green),
     new Champion("B", 90,0, ConsoleColor.Red),
     new Champion("C", 70,0, ConsoleColor.Blue),
     new Champion("D", 200,0, ConsoleColor.Yellow),
};

for (int i = 0; i < 10; i++)
{
    TurnMeterHelper.CalculateNextTurn(champions);
}


