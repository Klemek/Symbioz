using Symbioz.World.Models.Fights.Fighters;
using Symbioz.World.PathProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbioz.Providers.ActorIA.Actions
{
    [IAAction(IAActionsEnum.MoveToLowerEnemy)]
    public class MoveToLowerEnemy : AbstractIAAction
    {
        public override void Execute(MonsterFighter fighter)
        {
            if (fighter.FighterStats.Stats.MovementPoints <= 0)
            {
                return;
            }

            List<Fighter> fighters = new List<Fighter>();
            int shorterPath = 9999;
            fighters = fighter.GetOposedTeam().GetFighters();
            var path = new Pathfinder(fighter.Fight.Map, fighter.CellId);
            path.PutEntities(fighter.Fight.GetAllFighters());
            var cells = path.FindPath(fighters[0].CellId);

            foreach (Fighter fighterTest in fighters)
            {
                path = new Pathfinder(fighter.Fight.Map, fighter.CellId);
                path.PutEntities(fighter.Fight.GetAllFighters());
                var cellsTemp = path.FindPath(fighterTest.CellId);

                if (cellsTemp == null || cellsTemp.Count() <= 1)
                {
                    return;
                }

                if (cellsTemp.Count() < shorterPath)
                {
                    cells = cellsTemp;
                    shorterPath = cells.Count();
                }
            }

            cells.Remove(cells.Last());
            cells.Insert(0, fighter.CellId);
            cells = cells.Take(fighter.FighterStats.Stats.MovementPoints + 1).ToList();
            sbyte direction = PathParser.GetDirection(cells.Last());
            fighter.Move(cells, cells.Last(), direction);
        }

    }
}
