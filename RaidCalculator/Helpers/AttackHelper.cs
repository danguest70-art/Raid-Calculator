namespace RaidCalculator.Helpers;

public static class AttackHelper
{
    public static void ApplyAttack(ActionContext context, Champion[] champions, Champion nextChampion, Skill skill)
    {
        skill.Attack.ApplyAttack(context, champions, nextChampion);
    }
}

