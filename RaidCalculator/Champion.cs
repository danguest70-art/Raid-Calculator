namespace RaidCalculator;

public class Champion
{
    public string Name;
    public double speed;
    public double turnMeter;
    
    public Champion(string name, double speed, double turnMeter)
    {
        Name = name;
        this.speed = speed;
        this.turnMeter = turnMeter;
    }
}