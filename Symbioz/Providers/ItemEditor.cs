using Symbioz.DofusProtocol.Types;
using Symbioz.World.Models;
using System.Collections.Generic;

namespace Symbioz.Providers
{
    public class ItemEditor
    {
        public static CharacterItemRecord AddEffectsAndClone(CharacterItemRecord baseItem, List<ObjectEffect> addedeffects, uint newQuantity)
        {
            var newItem = baseItem.CloneAndGetNewUID();
            newItem.AddEffects(addedeffects);
            newItem.Quantity = newQuantity;
            return newItem;
        }
    }
}
