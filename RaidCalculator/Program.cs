using System.ComponentModel.DataAnnotations;
using RaidCalculator;

Champion[] champions =
{
     new Champion("A", 160,0, ConsoleColor.Green),
     new Champion("B", 90,0, ConsoleColor.Red),
     new Champion("C", 70,0, ConsoleColor.Blue),
};

for (int i = 0; i < 4; i++)
{
    var anyAbove100 = false;

    foreach (Champion champion in champions)
    {
        double turnMeterPerTic = champion.GetTurnMeterPerTic();

        if (champion.TurnMeter > 100)
        {
            anyAbove100 = true;
            break;
        }
    }

    if (anyAbove100)
    {
        TurnMeterHelper.AddOneTicTurnMeter(champions);
    }
    else
    {
        foreach (Champion champion in champions)
        {
            champion.TicsTo100 = Math.Ceiling((100 - champion.TurnMeter) / champion.GetTurnMeterPerTic());
        }

        var championClosestTo100 = champions.OrderBy(champion => champion.TicsTo100).FirstOrDefault();

        foreach (Champion champion in champions)
        {
            champion.TurnMeter = champion.TurnMeter + (championClosestTo100.TicsTo100 * champion.GetTurnMeterPerTic());
        }

        var nextChampion = champions.MaxBy(champion => champion.TurnMeter);
        OutputHelper.OutputStepResults(champions);
        nextChampion.TurnMeter = 0;
    }
}


