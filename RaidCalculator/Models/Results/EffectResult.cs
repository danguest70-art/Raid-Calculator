using RaidCalculator.Effects;

namespace RaidCalculator.Results;

public class EffectResult
{
    public Effect Effect { get; init; } = null!;
    public Champion Caster { get; init; } = null!;
    
    public bool Success { get; init; }
    public bool Resisted { get; init; }
}