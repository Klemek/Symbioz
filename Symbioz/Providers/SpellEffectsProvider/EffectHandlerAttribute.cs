using Symbioz.Enums;
using System;

namespace Symbioz.Providers.SpellEffectsProvider
{
    public class EffectHandler : Attribute
    {
        public EffectsEnum Effect { get; set; }
        public EffectHandler(EffectsEnum effect)
        {
            this.Effect = effect;
        }
    }
}
