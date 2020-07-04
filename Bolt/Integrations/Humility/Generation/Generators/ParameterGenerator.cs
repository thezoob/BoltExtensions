using System;

namespace Lasm.BoltExtensions.Humility
{
    public sealed class ParameterGenerator : ConstructGenerator
    {
        private string name;
        private Type type;
        private ParameterModifier modifier;
        
        public override string Generate(int indent)
        {
            return type.As().CSharpName() + " " + name;
        }

        private ParameterGenerator()
        {

        }

        public static ParameterGenerator Parameter(string name, Type type, ParameterModifier modifier)
        {
            var parameter = new ParameterGenerator();
            parameter.name = name;
            parameter.type = type;
            parameter.modifier = modifier;
            return parameter;
        }
    }
}