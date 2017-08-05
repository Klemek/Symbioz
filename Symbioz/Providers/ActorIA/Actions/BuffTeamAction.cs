using Symbioz.World.Records;

namespace Symbioz.Providers.ActorIA.Actions
{
    [IAAction(IAActionsEnum.BuffTeam)]
    class BuffTeamAction : AbstractIAAction
    {
        public override void Execute(World.Models.Fights.Fighters.MonsterFighter fighter)
        {
            var spells = fighter.Template.Spells.ConvertAll<SpellRecord>(x => SpellRecord.GetSpell(x));
            var target = fighter.CloserAlly(fighter);
            Logger.Log("Buff Team");
            /*if (fighter.GetOposedTeam().LowerFighter().FighterStats.LifePercentage <= 20 && spells.FindAll(x => x.Category == SpellCategoryEnum.Damages).Count > 0)
                return;*/



            foreach (var spell in spells.FindAll(x => x.Category == SpellCategoryEnum.Heal))
            {
                CastAction.TryCast(fighter, spell.Id, target);
            }
            foreach (var spell in spells.FindAll(x => x.Category == SpellCategoryEnum.Buff))
            {
                CastAction.TryCast(fighter, spell.Id, target);
            }
        }
    }
}
