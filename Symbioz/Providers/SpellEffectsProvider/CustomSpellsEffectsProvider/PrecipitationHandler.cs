using Symbioz.World.Models.Fights.Fighters;
using Symbioz.World.Records.Spells;
using System.Collections.Generic;

namespace Symbioz.Providers.SpellEffectsProvider.CustomSpellsEffectsProvider
{
    // [CustomSpell(SpellIdEnum.Precipitation)]
    class PrecipitationHandler : ISpellHandler
    {
        void ISpellHandler.Cast(Fighter fighter, List<ExtendedSpellEffect> effects)
        {
            fighter.Fight.Reply("SpellHandle...");
        }
    }
}
