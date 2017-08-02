using Symbioz.DofusProtocol.Types;

namespace Symbioz.World.Models
{
    class CharacterHelper
    {
        public static ActorRestrictionsInformations GetDefaultRestrictions()
        {
            return new ActorRestrictionsInformations(false, false, false, false, false, false, false, false, true, false, false, false, false, true, true, true, false, false, false, false, false);
        }
    }
}
