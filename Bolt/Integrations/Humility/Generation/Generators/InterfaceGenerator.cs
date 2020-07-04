using System;
using System.Collections.Generic;

namespace Lasm.BoltExtensions.Humility
{
    public sealed class InterfaceGenerator : BodyGenerator
    {
#pragma warning disable 0649
        private RootAccessModifier scope;
        private Type[] interfaces;
#pragma warning restore 0649
        private string typeName;
        private List<AttributeGenerator> attributes = new List<AttributeGenerator>();
        private List<InterfacePropertyGenerator> properties = new List<InterfacePropertyGenerator>();
        private List<InterfaceMethodGenerator> methods = new List<InterfaceMethodGenerator>();

        protected override string GenerateBefore(int indent)
        {
            var output = string.Empty;

            for (int i = 0; i < attributes.Count; i++)
            {
                output += attributes[i].Generate(indent) + "\n";
            }

            var hasInterfaces = interfaces.Length > 0;
            output += CodeBuilder.Indent(indent) + scope.AsString() + " interface " + typeName + (hasInterfaces ? " : " : string.Empty);
            
            for (int i = 0; i < interfaces.Length; i++)
            {
                output += interfaces[i].Name;
                if (i < interfaces.Length - 1) output += ", ";
            }

            return output;
        }

        protected override string GenerateBody(int indent)
        {
            var output = string.Empty;
            
            for (int i = 0; i < properties.Count; i++)
            {
                output += CodeBuilder.Indent(indent) + properties[i].Generate(indent);
                if (i < properties.Count - 1) output += "\n";
            }

            if (properties.Count > 0 && methods.Count > 0) output += "\n";
            for (int i = 0; i < methods.Count; i++)
            {
                output += CodeBuilder.Indent(indent) + methods[i].Generate(indent);
                if (i < methods.Count - 1) output += "\n";
            }

            return output;
        }

        protected override string GenerateAfter(int indent)
        {
            return string.Empty;
        }

        private InterfaceGenerator(string name, params Type[] interfaces) { this.typeName = name; this.interfaces = interfaces; }

        public static InterfaceGenerator Interface(string name, params Type[] interfaces)
        {
            return new InterfaceGenerator(name, interfaces);
        }

        public InterfaceGenerator AddMethod(InterfaceMethodGenerator generator)
        {
            methods.Add(generator);
            return this;
        }

        public InterfaceGenerator AddProperty(InterfacePropertyGenerator generator)
        {
            properties.Add(generator);
            return this;
        }

        public InterfaceGenerator AddAttribute(AttributeGenerator generator)
        {
            attributes.Add(generator);
            return this;
        }
    }
}