namespace Symbioz.Providers.SpellEffectsProvider
{
    public class SpellBoost
    {
        public SpellBoost(ushort spellId, short delta)
        {
            this.SpellId = spellId;
            this.Delta = delta;
        }
        public ushort SpellId { get; set; }
        public short Delta { get; set; }
    }
}
