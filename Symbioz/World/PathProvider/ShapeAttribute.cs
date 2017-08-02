using System;

namespace Symbioz.World.PathProvider
{
    public class Shape : Attribute
    {
        public char ShapeIdentifier { get; set; }
        public Shape(char identifier)
        {
            this.ShapeIdentifier = identifier;
        }
    }
}
