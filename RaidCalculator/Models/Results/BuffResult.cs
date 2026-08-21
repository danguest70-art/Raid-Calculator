using RaidCalculator.Buffs;

namespace RaidCalculator.Results;

public class BuffResult
{
    public Buff Buff { get; init; } = null!;
    public Champion Caster { get; init; } = null!;

    public bool Applied { get; init; }
    public bool Replaced { get; init; }
    public bool Extended { get; init; }
}