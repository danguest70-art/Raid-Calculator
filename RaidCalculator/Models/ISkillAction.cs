namespace RaidCalculator;

public interface ISkillAction
{
    void Execute(ActionContext context, Champion[] champions, Champion caster);
}
