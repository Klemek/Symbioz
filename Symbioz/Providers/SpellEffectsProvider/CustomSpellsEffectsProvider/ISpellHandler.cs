using Symbioz.World.Models.Fights.Fighters;
using Symbioz.World.Records.Spells;
using System.Collections.Generic;

namespace Symbioz.Providers.SpellEffectsProvider.CustomSpellsEffectsProvider
{
    public interface ISpellHandler
    {
        void Cast(Fighter fighter, List<ExtendedSpellEffect> effects);
    }
}
