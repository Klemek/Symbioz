using Symbioz.Network.Clients;

namespace Symbioz.Providers.Conditions
{
    [Condition("ca")]
    public class AgilityCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            return Condition.BasicEval(ConditionValue, ComparaisonSymbol, client.Character.StatsRecord.PermanentAgility);
        }
    }
    [Condition("CA")]
    public class TotalAgilityCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            return Condition.BasicEval(ConditionValue, ComparaisonSymbol, client.Character.StatsRecord.Agility);
        }
    }
}
