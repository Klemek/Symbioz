using System;

namespace Symbioz.Providers.SpellEffectsProvider.TargetsMasksProvider
{
    public class TargetMask : Attribute
    {
        public string Identifier { get; set; }

        public TargetMask(string identifier)
        {
            this.Identifier = identifier;
        }
    }
}
