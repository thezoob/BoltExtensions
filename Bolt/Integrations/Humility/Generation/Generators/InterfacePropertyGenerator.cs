using System;

namespace Lasm.BoltExtensions.Humility
{
    public sealed class InterfacePropertyGenerator : ConstructGenerator
    {
        private string name;
        private Type type;
        private string get;
        private string set;

        public override string Generate(int indent)
        {
            return type.Name + " " + name + " " + "{ " + set + " " + set + "}";
        }

        private InterfacePropertyGenerator() { }

        public static InterfacePropertyGenerator Property(string name, Type type, bool get, bool set)
        {
            var interfaceProp = new InterfacePropertyGenerator();
            interfaceProp.name = name;
            interfaceProp.type = type;
            interfaceProp.get = (get ? "get; " : string.Empty);
            interfaceProp.set = (set ? "set; " : string.Empty);
            return interfaceProp;
        }
    }
}