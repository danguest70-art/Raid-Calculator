namespace RaidCalculator.Results;

public class DamageResult
{
    public Champion Attacker { get; set; } = null!;
    public Champion Target { get; set; } = null!;

    public double Damage { get; set; }
    public double BaseDamage { get; set; }
    public double Mitigation { get; set; }
    public double Variance { get; set; }
    public bool IsCritical { get; set; }
}
