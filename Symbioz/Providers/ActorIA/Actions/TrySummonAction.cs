﻿using Symbioz.World.Models.Fights.Fighters;
using Symbioz.World.PathProvider;
using Symbioz.World.Records;

namespace Symbioz.Providers.ActorIA.Actions
{
    [IAAction(IAActionsEnum.TrySummon)]
    class TrySummonAction : AbstractIAAction
    {
        public override void Execute(MonsterFighter fighter)
        {
            Logger.Log("IA invoque");
            var summonSpell = fighter.Template.Spells.ConvertAll<SpellRecord>(x => SpellRecord.GetSpell(x)).Find(x => x.Category == SpellCategoryEnum.Summon);
            if (summonSpell != null && fighter.SummonCount <= 1)
            {
                var cells = ShapesProvider.GetSquare(fighter.CellId, false);
                var cell = cells.Find(x => !fighter.Fight.IsObstacle(x));
                Logger.Log(cell);
                if (cell != 0)
                {
                    fighter.CastSpellOnCell(summonSpell.Id, cell);
                }
                else
                    fighter.Fight.Reply("Unable to summon");
            }
        }
    }
}
