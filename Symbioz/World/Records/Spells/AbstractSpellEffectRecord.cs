﻿using Symbioz.Enums;

namespace Symbioz.World.Records.Spells
{
    public abstract class AbstractSpellEffectRecord
    {
        public int EffectUID;
        public int SpellLevelId;
        public EffectsEnum EffectType { get { return (EffectsEnum)EffectId; } }
        public short EffectId;
        public string RawZone;
        public string TargetMask;
        public short DiceNum;
        public short DiceSide;
        public short Duration;
        public int Value;
        public int Delay;
        public int Random;
    }
}
