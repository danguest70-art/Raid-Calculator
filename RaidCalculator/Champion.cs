namespace RaidCalculator;

public class Champion
{
    public string Name;
    public double Speed;
    public double TurnMeter;
    public double TicsTo100;
    
    public Champion(string name, double speed, double turnMeter)
    {
        Name = name;
        Speed = speed;
        TurnMeter = turnMeter;
    }

    public double GetTurnMeterPerTic()
    { 
        return Speed * 0.07;
    }
}