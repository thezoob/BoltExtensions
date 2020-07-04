using System;
using System.Collections.Generic;

namespace Lasm.BoltExtensions.Humility
{
    public sealed class InterfaceMethodGenerator : ConstructGenerator
    {
        private string name;
        private Type returnType;
        private List<ParameterGenerator> parameters = new List<ParameterGenerator>();

        public override string Generate(int indent)
        {
            var output = returnType.As().CSharpName() + " " + name + " " + "(";
            for (int i = 0; i < parameters.Count; i++)
            {
                output += parameters[i].Generate(indent);
            }
            output += ");";

            return output;
        }

        internal InterfaceMethodGenerator() { }

        public static InterfaceMethodGenerator Method(string name, Type returnType)
        {
            var method = new InterfaceMethodGenerator();
            method.name = name;
            method.returnType = returnType;
            return method;
        }

        public InterfaceMethodGenerator AddParameter(ParameterGenerator generator)
        {
            parameters.Add(generator);
            return this;
        }
    }
}