namespace RaidCalculator.Results;

public class AttackResult
{
    public Champion Attacker { get; set;  }
    public bool Hit { get; set; }
    public bool Critical { get; set; }
    public bool Weak { get; set; }
    public List<DamageResult> DamageResults { get; } = [];
}