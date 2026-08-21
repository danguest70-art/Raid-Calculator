namespace RaidCalculator.Results;

public class AttackResult
{
    public bool Hit { get; init; }
    public bool Critical { get; init; }
    public bool Weak { get; init; }
    public int Damage { get; init; }
    public Champion Target { get; init; } = null!;
}