using RaidCalculator.Helpers;

namespace RaidCalculator;

public class Battle
{
    public List<Champion> Champions { get; }
    public List<Champion> DeadChampions { get; } = [];

    public Battle(IEnumerable<Champion> champions)
    {
        Champions = champions.ToList();
    }

    public void RunTurns(int turnCount)
    {
        for (var i = 0; i < turnCount; i++)
        {
            if (Champions.Count == 0)
                break;

            TakeTurn();
        }
    }

    public void TakeTurn()
    {
        var actor = TurnMeterHelper.CalculateNextTurn(Champions.ToArray());
        var context = new ActionContext { Caster = actor };

        OnTurnStart(actor);

        var skill = SkillHelper.GetNextSkill(actor);
        context.Skill = skill;
        if (skill is null)
            return;

        UseSkill(context, actor, skill);
        OnTurnEnd();
        RemoveDead();
    }

    private static void OnTurnStart(Champion actor)
    {
        BuffHelper.TickBuffs(actor);
        SkillHelper.TickCooldowns(actor);
    }

    private void UseSkill(ActionContext context, Champion actor, Skill skill)
    {
        var champions = Champions.ToArray();
        foreach (var action in skill.Actions)
            action.Execute(context, champions, actor);
    }

    private static void OnTurnEnd()
    {
        // Hook for Relentless, end-of-turn sets, and similar later.
    }

    private void RemoveDead()
    {
        var dead = Champions.Where(c => c.Health <= 0).ToList();
        foreach (var champion in dead)
        {
            Champions.Remove(champion);
            DeadChampions.Add(champion);
        }
    }
}
