namespace RaidCalculator;

public static class EffectHelper
{
    public static void ApplyEffect(Champion[] champions, Champion nextChampion, Skill skill)
    {
        skill.Effect?.ApplyEffect(champions, nextChampion);
    }
}