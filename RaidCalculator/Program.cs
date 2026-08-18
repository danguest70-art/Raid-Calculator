using System.ComponentModel.DataAnnotations;
using RaidCalculator;

Champion[] champions =
{
     new Champion("A", 160,0),
     new Champion("B", 90,0),
     new Champion("C", 70,0),
     new Champion("D", 120,0),
     new Champion("E", 150,0),
     new Champion("F", 25,0)
};

foreach (Champion champion in champions)
{
     double turnMeterPerTic = champion.speed * 0.07;


     for (int i = 0; i < 4; i++)
     {


          if (champion.turnMeter > 100)
          {
               champion.turnMeter = champion.turnMeter + (champion.speed * 0.07);
          }
          else
          {
               var turnMeterNew = 100 - champion.turnMeter;

               var turnMeterPercent = Math.Ceiling(turnMeterNew / turnMeterPerTic);
               var ticsTo100 =
               


          }


     }
}




