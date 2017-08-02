using System;

namespace Symbioz.Providers.SpellEffectsProvider.FightLooksProvider
{
    public class FightLook : Attribute
    {
        public ushort SpellId { get; set; }
        public FightLook(ushort spellid)
        {
            this.SpellId = spellid;
        }
    }
}
