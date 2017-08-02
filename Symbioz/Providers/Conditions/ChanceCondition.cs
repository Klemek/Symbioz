using Symbioz.Network.Clients;

namespace Symbioz.Providers.Conditions
{
    [Condition("cc")]
    public class ChanceCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            return Condition.BasicEval(ConditionValue, ComparaisonSymbol, client.Character.StatsRecord.PermanentChance);
        }
    }
    [Condition("CC")]
    public class TotalChanceCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            return Condition.BasicEval(ConditionValue, ComparaisonSymbol, client.Character.StatsRecord.Chance);
        }
    }
}
