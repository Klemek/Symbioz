using Symbioz.DofusProtocol.Types;
using System.Collections.Generic;
using YAXLib;

namespace Symbioz.World.Models.Items
{
    public class EffectSerializer
    {
        public static void Serialize(List<ObjectEffect> effects)
        {
            foreach (var effect in effects)
            {
                YAXSerializer serializer = new YAXSerializer(effect.GetType());
                string contents = serializer.Serialize(effect);
            }
        }
    }
}
