using Symbioz.DofusProtocol.Types;
using Symbioz.World.Records.Spells;
using System;

namespace Symbioz.World.Models.Fights.Fighters
{
    public class ControlableFighter : Fighter
    {
        public MonsterFighter Template { get; set; }

        public Fighter Master { get; set; }

        public ControlableFighter(FightTeam team, MonsterFighter template, Fighter master) : base(team)
        {
            this.Template = template;
            this.Master = master;
        }
        public override FightTeamMemberInformations GetFightMemberInformations()
        {
            throw new NotImplementedException();
        }

        public override SpellLevelRecord GetSpellLevel(ushort spellid)
        {
            throw new NotImplementedException();
        }

        public override int GetInitiative()
        {
            throw new NotImplementedException();
        }

        public override void RefreshStats()
        {
            throw new NotImplementedException();
        }

        public override string GetName()
        {
            throw new NotImplementedException();

        }
    }
}
