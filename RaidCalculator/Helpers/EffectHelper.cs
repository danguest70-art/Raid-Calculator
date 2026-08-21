namespace RaidCalculator;

public static class EffectHelper
{
    public static void ApplyEffect(ActionContext context, Champion[] champions, Champion nextChampion, Skill skill)
    {
        skill.Effect?.ApplyEffect(context, champions, nextChampion);
    }
}