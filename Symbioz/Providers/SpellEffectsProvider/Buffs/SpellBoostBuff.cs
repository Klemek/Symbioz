using Symbioz.DofusProtocol.Messages;
using Symbioz.DofusProtocol.Types;
using Symbioz.Enums;

namespace Symbioz.Providers.SpellEffectsProvider.Buffs
{
    public class SpellBoostBuff : Buff
    {
        public short AddedDmg { get; set; }

        public SpellBoostBuff(uint uid, short spellId, short duration, int sourceid, short sourcespellid, int delay, short addedDmg)
            : base(uid, spellId, duration, sourceid, sourcespellid, delay)
        {
            this.AddedDmg = addedDmg;
        }

        public override void SetBuff()
        {
            Fighter.Fight.Send(new GameActionFightDispellableEffectMessage((ushort)EffectsEnum.Eff_SpellBoost, SourceId, new FightTemporarySpellBoostEffect((uint)Fighter.BuffIdProvider.Pop(), Fighter.ContextualId, Duration, 0, (ushort)SourceSpellId, UID, 0, AddedDmg, (ushort)Delta)));
            Fighter.AddSpellBoost((ushort)Delta, AddedDmg);
        }
        public override void OnBuffAdded()
        {
            Fighter.Fight.Send(new GameActionFightDispellableEffectMessage((ushort)EffectsEnum.Eff_SpellBoost,
             SourceId, new FightTriggeredEffect(UID, Fighter.ContextualId, Duration, 0, (ushort)SourceSpellId, 0, 0, Delta, 0, AddedDmg, (short)Delay)));
            base.OnBuffAdded();
        }
        public override void RemoveBuff()
        {
            Fighter.RemoveSpellBoost((ushort)Delta, AddedDmg);
        }
    }
}
