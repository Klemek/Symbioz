using Symbioz.Enums;
using System;

namespace Symbioz.Providers.SpellEffectsProvider.CustomSpellsEffectsProvider
{
    public class CustomSpell : Attribute
    {
        public SpellIdEnum SpellId { get; set; }
        public CustomSpell(SpellIdEnum spellid)
        {
            this.SpellId = spellid;
        }
    }
}
