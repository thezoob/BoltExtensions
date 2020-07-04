using System;

namespace Lasm.BoltExtensions.Humility
{
    public sealed class EventGenerator : ConstructGenerator
    {
        private AccessModifier scope;
        private Type returnType;
        private string name;

        private EventGenerator() { }

        public static EventGenerator Event(AccessModifier scope, Type returnType, string name)
        {
            return new EventGenerator()
            {
                scope = scope,
                returnType = returnType,
                name = name
            };
        }

        public override string Generate(int indent)
        {
            return CodeBuilder.Indent(indent) + scope.AsString() + " event " + returnType.Name + " " + name + ";";
        }
    }
}
