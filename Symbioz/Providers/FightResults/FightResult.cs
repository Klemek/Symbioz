using Symbioz.DofusProtocol.Types;
using Symbioz.Enums;
using Symbioz.World.Models.Fights;
using Symbioz.World.Models.Fights.Fighters;

namespace Symbioz.Providers.FightResults
{
    public abstract class FightResult
    {
        public Fighter Fighter { get; set; }
        public FightOutcomeEnum OutCome { get; set; }
        public FightResult(Fighter fighter, TeamColorEnum winner)
        {
            this.Fighter = fighter;
            if (fighter.Team.TeamColor == winner)
                OutCome = FightOutcomeEnum.RESULT_VICTORY;
            else
                OutCome = FightOutcomeEnum.RESULT_LOST;

        }
        public abstract FightResultListEntry GetEntry();

    }
}
