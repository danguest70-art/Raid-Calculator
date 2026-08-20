namespace RaidCalculator;

public class Champion
{
    public bool IsChampion;
    public string Name;
    public double Speed;
    public double TurnMeter;
    public ConsoleColor OutputColour;
    public Effect[] Effects;
    public int TurnCounter = 0;

    public Champion(string name, double speed, double turnMeter, ConsoleColor outputColour, Effect[] effects, bool isChampion = true)
    {
        Name = name;
        Speed = speed;
        TurnMeter = turnMeter;
        OutputColour = outputColour;
        IsChampion = isChampion;
        Effects = effects;
    }

    public double PerTicTurnMeter() => Speed * 0.07;

    public void IncrementTurns()
    {
        TurnCounter += 1;
    }
}