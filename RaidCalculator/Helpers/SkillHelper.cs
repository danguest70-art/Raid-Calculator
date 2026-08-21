namespace RaidCalculator.Helpers;

public static class SkillHelper
{
    public static Skill? GetNextSkill(Champion champion)
    {
        var skill = champion.Skills
            .Where(s => s.CurrentCoolDown == 0)
            .OrderByDescending(s => s.Priority)
            .FirstOrDefault();

        skill?.CurrentCoolDown = skill.SkillCoolDown;
        
        return skill;
    }

    public static void DecrementSkillCoolDown(Skill skill)
    {
        if (skill.CurrentCoolDown >= 1)
        {
            skill.CurrentCoolDown--;
        }
    }
}