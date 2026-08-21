namespace RaidCalculator.Helpers;

public static class SkillHelper
{
    public static Skill? GetNextSkill(Champion champion)
    {
        var skill = champion.Skills
            .Where(s => s.CurrentCoolDown == 0)
            .OrderByDescending(s => s.Priority)
            .FirstOrDefault();

        if (skill is not null)
            skill.CurrentCoolDown = skill.SkillCoolDown;

        return skill;
    }

    public static void TickCooldowns(Champion champion)
    {
        foreach (var skill in champion.Skills)
        {
            if (skill.CurrentCoolDown > 0)
                skill.CurrentCoolDown--;
        }
    }
}
