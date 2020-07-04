using System;
using System.Collections.Generic;

namespace Lasm.BoltExtensions.Humility
{
    public sealed class StructGenerator : BodyGenerator
    {
        private RootAccessModifier scope;
#pragma warning disable 0414
        private bool isNested;
#pragma warning restore 0414
        private AccessModifier nestedScope;
        private StructModifier modifier;
        private string name;
        private List<AttributeGenerator> attributes = new List<AttributeGenerator>();
        private List<FieldGenerator> fields = new List<FieldGenerator>();
        private List<PropertyGenerator> properties = new List<PropertyGenerator>();
        private List<MethodGenerator> methods = new List<MethodGenerator>();
        private List<ClassGenerator> classes = new List<ClassGenerator>();
        private List<StructGenerator> structs = new List<StructGenerator>();
        private List<EnumGenerator> enums = new List<EnumGenerator>();
        private List<Type> interfaces = new List<Type>();

        private StructGenerator() { }

        public static StructGenerator Struct(RootAccessModifier scope, StructModifier modifier, string name)
        {
            var @struct = new StructGenerator();
            @struct.scope = scope;
            @struct.modifier = modifier;
            @struct.name = name;
            @struct.isNested = false;
            return @struct;
        }

        public static StructGenerator Struct(AccessModifier nestedScope, StructModifier modifier, string name)
        {
            var @struct = new StructGenerator();
            @struct.nestedScope = nestedScope;
            @struct.modifier = modifier;
            @struct.name = name;
            @struct.isNested = true;
            return @struct;
        }

        protected override string GenerateBefore(int indent)
        {
            var output = string.Empty;

            for (int i = 0; i < attributes.Count; i++)
            {
                output += attributes[i].Generate(indent) + "\n";
            }

            output += CodeBuilder.Indent(indent) + scope.AsString() + modifier.AsString() + " struct " + name;
            output += interfaces.Count == 0 ? string.Empty : " : ";

            for (int i = 0; i < interfaces.Count; i++)
            {
                output += interfaces[i].As().CSharpName();
                output += i < interfaces.Count - 1 ? ", " : string.Empty;
            }

            return output;
        }

        protected override string GenerateBody(int indent)
        {
            var output = string.Empty;

            for (int i = 0; i < fields.Count; i++)
            {
                output += fields[i].Generate(indent) + (i < fields.Count - 1 ? "\n" : string.Empty);
            }

            output += properties.Count > 0 || methods.Count > 0 ? "\n" : string.Empty;

            for (int i = 0; i < properties.Count; i++)
            {
                output += properties[i].Generate(indent) + (i < properties.Count - 1 ? "\n" : string.Empty);
            }

            output += methods.Count > 0 ? "\n" : string.Empty;

            output += (properties.Count > 0 || fields.Count > 0) && methods.Count > 0 ? "\n" : string.Empty;

            for (int i = 0; i < methods.Count; i++)
            {
                output += methods[i].Generate(indent) + (i < methods.Count - 1 ? "\n" : string.Empty);
            }

            output += (properties.Count > 0 || fields.Count > 0 || methods.Count > 0) && classes.Count > 0 ? "\n" : string.Empty;

            for (int i = 0; i < classes.Count; i++)
            {
                output += classes[i].Generate(indent);
                output += i < classes.Count - 1 ? "\n" : string.Empty;
            }

            output += (properties.Count > 0 || fields.Count > 0 || methods.Count > 0 || classes.Count > 0) && structs.Count > 0 ? "\n" : string.Empty;

            for (int i = 0; i < structs.Count; i++)
            {
                output += structs[i].Generate(indent);
                output += i < structs.Count - 1 ? "\n" : string.Empty;
            }

            output += (properties.Count > 0 || fields.Count > 0 || methods.Count > 0 || classes.Count > 0 || structs.Count > 0) && enums.Count > 0 ? "\n" : string.Empty;

            for (int i = 0; i < enums.Count; i++)
            {
                output += enums[i].Generate(indent);
                output += i < enums.Count - 1 ? "\n" : string.Empty;
            }

            return output;
        }

        protected override string GenerateAfter(int indent)
        {
            return string.Empty;
        }

        public StructGenerator AddInterface(Type type)
        {
            interfaces.Add(type);
            return this;
        }

        public StructGenerator AddAttribute(AttributeGenerator generator)
        {
            attributes.Add(generator);
            return this;
        }

        public StructGenerator AddMethod(MethodGenerator generator)
        {
            methods.Add(generator);
            return this;
        }

        public StructGenerator AddField(FieldGenerator generator)
        {
            fields.Add(generator);
            return this;
        }

        public StructGenerator AddProperty(PropertyGenerator generator)
        {
            properties.Add(generator);
            return this;
        }

        public StructGenerator AddClass(ClassGenerator generator)
        {
            classes.Add(generator);
            return this;
        }

        public StructGenerator AddStruct(StructGenerator generator)
        {
            structs.Add(generator);
            return this;
        }

        public StructGenerator AddEnum(EnumGenerator generator)
        {
            enums.Add(generator);
            return this;
        }
    }
}
