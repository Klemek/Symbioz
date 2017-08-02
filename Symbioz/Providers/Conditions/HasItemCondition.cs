using Symbioz.Network.Clients;

namespace Symbioz.Providers.Conditions
{
    [ConditionAttribute("PO")]
    public class HasItemCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            ushort gid = ushort.Parse(ConditionFull.Remove(0, 3));
            if (client.Character.Inventory.HasItem(gid))
                return true;
            else
                return false;
        }
    }
}
