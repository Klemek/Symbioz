using Symbioz.Network.Clients;

namespace Symbioz.Providers.Conditions
{
    [ConditionAttribute("PL")]
    public class LevelCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            return Condition.BasicEval(ConditionValue, ComparaisonSymbol, client.Character.Record.Level);
        }
    }
}
