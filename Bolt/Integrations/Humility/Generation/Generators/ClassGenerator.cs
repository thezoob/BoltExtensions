using System;
using System.Collections.Generic;

namespace Lasm.BoltExtensions.Humility
{
    /// <summary>
    /// A generator that retains data for creating a new class as a string.
    /// </summary>
    public sealed class ClassGenerator : BodyGenerator
    {
        private RootAccessModifier scope;
        private AccessModifier nestedScope;
        private ClassModifier modifier;
#pragma warning disable 0414
        private bool isNested;
#pragma warning restore 0414
        private string name;
        private List<AttributeGenerator> attributes = new List<AttributeGenerator>();
        private List<FieldGenerator> fields = new List<FieldGenerator>();
        private List<PropertyGenerator> properties = new List<PropertyGenerator>();
        private List<MethodGenerator> methods = new List<MethodGenerator>();
        private List<ClassGenerator> classes = new List<ClassGenerator>();
        private List<StructGenerator> structs = new List<StructGenerator>();
        private List<EnumGenerator> enums = new List<EnumGenerator>();
        private List<Type> interfaces = new List<Type>();
        private Type inherits;

        private ClassGenerator() { }

        /// <summary>
        /// Create a root class generator based on required parameters.
        /// </summary>
        public static ClassGenerator Class(RootAccessModifier scope, ClassModifier modifier, string name, Type inherits)
        {
            var @class = new ClassGenerator();
            @class.scope = scope;
            @class.modifier = modifier;
            @class.name = name;
            @class.inherits = inherits;
            @class.isNested = false;
            return @class;
        }


        /// <summary>
        /// Create a nested class generator based on required parameters.
        /// </summary>
        public static ClassGenerator Class(AccessModifier nestedScope, ClassModifier modifier, string name, Type inherits)
        {
            var @class = new ClassGenerator();
            @class.nestedScope = nestedScope;
            @class.modifier = modifier;
            @class.name = name;
            @class.inherits = inherits;
            @class.isNested = true;
            return @class;
        }

        protected override string GenerateBefore(int indent)
        {
            var output = string.Empty;

            for (int i = 0; i < attributes.Count; i++)
            {
                output += attributes[i].Generate(indent) + "\n";
            }

            var canShowInherits = !(inherits == null || inherits == typeof(object) && inherits.BaseType == null);
            output += CodeBuilder.Indent(indent) + scope.AsString() + modifier.AsString() + " class " + name;
            output += !canShowInherits && interfaces.Count == 0 ? string.Empty : " : ";
            output += canShowInherits ? inherits.As().CSharpName() + (interfaces.Count > 0 ? ", " : string.Empty) : string.Empty;

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

            output += properties.Count > 0 && fields.Count != 0 ? "\n" : string.Empty;

            for (int i = 0; i < properties.Count; i++)
            {
                output += properties[i].Generate(indent) + (i < properties.Count - 1 ? "\n" : string.Empty);
            }

            output += methods.Count > 0 ? "\n" : string.Empty;

            output += (properties.Count > 0 || fields.Count > 0) ? "\n" : string.Empty;

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

        /// <summary>
        /// Add an interface to this class.
        /// </summary>
        public ClassGenerator AddInterface(Type type)
        {
            interfaces.Add(type);
            return this;
        }

        /// <summary>
        /// Add an attribute above this class.
        /// </summary>
        public ClassGenerator AddAttribute(AttributeGenerator generator)
        {
            attributes.Add(generator);
            return this;
        }

        /// <summary>
        /// Add a method to this class.
        /// </summary>
        public ClassGenerator AddMethod(MethodGenerator generator)
        {
            methods.Add(generator);
            return this;
        }

        /// <summary>
        /// Add a field to this class.
        /// </summary>
        public ClassGenerator AddField(FieldGenerator generator)
        {
            fields.Add(generator);
            return this;
        }

        /// <summary>
        /// Add a property to this class.
        /// </summary>
        /// <param name="generator"></param>
        /// <returns></returns>
        public ClassGenerator AddProperty(PropertyGenerator generator)
        {
            properties.Add(generator);
            return this;
        }

        /// <summary>
        /// Adds a nested class to this class.
        /// </summary>
        /// <param name="generator"></param>
        /// <returns></returns>
        public ClassGenerator AddClass(ClassGenerator generator)
        {
            classes.Add(generator);
            return this;
        }

        /// <summary>
        /// Add a nested struct to this class.
        /// </summary>
        public ClassGenerator AddStruct(StructGenerator generator)
        {
            structs.Add(generator);
            return this;
        }

        /// <summary>
        /// Add a nested enum to this class.
        /// </summary>
        public ClassGenerator AddEnum(EnumGenerator generator)
        {
            enums.Add(generator);
            return this;
        }
    }
}
