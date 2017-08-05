using Symbioz.World.Models.Fights.Fighters;

namespace Symbioz.Providers.ActorIA.Actions
{
    [IAAction(IAActionsEnum.ANIMATED_BAG)]
    class AnimatedBagAction : AbstractIAAction
    {
        public override void Execute(MonsterFighter fighter)
        {
            var martyrSpell = fighter.Template.Spells[0];
            Fighter lower = fighter.CloserAlly(fighter);
            fighter.CastSpellOnTarget(martyrSpell, lower.ContextualId);
        }
    }
}
