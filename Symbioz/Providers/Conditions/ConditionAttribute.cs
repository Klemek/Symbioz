using System;

namespace Symbioz.Providers.Conditions
{
    public class ConditionAttribute : Attribute
    {
        public string Identifier { get; set; }
        public ConditionAttribute(string indentifier)
        {
            this.Identifier = indentifier;
        }
    }
}
