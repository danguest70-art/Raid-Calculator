namespace RaidCalculator;

public class Champion
{
    public string Name;
    public double Speed;
    public double TurnMeter;
    public ConsoleColor OutputColour;

    public Champion(string name, double speed, double turnMeter, ConsoleColor outputColour)
    {
        Name = name;
        Speed = speed;
        TurnMeter = turnMeter;
        OutputColour = outputColour;
    }

    public double PerTicTurnMeter() => Speed * 0.07;
}