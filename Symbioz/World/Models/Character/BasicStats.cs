namespace Symbioz.World.Models
{
    public class BasicStats
    {
        public BasicStats(ushort energy, uint lifepoints)
        {
            this.Energy = energy;
            this.LifePoints = lifepoints;
        }
        public ushort Energy { get; set; }
        public uint LifePoints { get; set; }
    }
}
