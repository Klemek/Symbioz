using System;

namespace Symbioz.Providers.SpellEffectsProvider.TargetsMasksProvider
{
    public class TMValidator : Attribute
    {
        public string Identifier { get; set; }
        public TMValidator(string identifier)
        {
            this.Identifier = identifier;
        }
    }
}
