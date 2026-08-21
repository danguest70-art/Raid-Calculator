using RaidCalculator.Results;

namespace RaidCalculator;

public class ActionContext
{
    public Champion Caster { get; set; } = null!;
    public Champion[] Targets { get; set; } = [];
    public Skill? Skill { get; set; }

    public List<EffectResult> EffectResults = [];
    public List<BuffResult> BuffResults = [];
    public AttackResult AttackResult;
}