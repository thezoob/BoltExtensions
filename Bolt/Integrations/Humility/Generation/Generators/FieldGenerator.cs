using System;

namespace Lasm.BoltExtensions.Humility
{
    public sealed class FieldGenerator : ConstructGenerator
    {
        private AccessModifier scope;
        private FieldModifier modifier;
        private string name;
        private object defaultValue;
        private Type type;

        private FieldGenerator() { }

        public static FieldGenerator Field(AccessModifier scope, FieldModifier modifier, Type type, string name)
        {
            var field = new FieldGenerator();
            field.scope = scope;
            field.modifier = modifier;
            field.type = type;
            field.name = name;
            field.defaultValue = null;
            return field;
        }

        public FieldGenerator Default(object value)
        {
            defaultValue = value;
            return this;
        }

        public override string Generate(int indent)
        {
            var modSpace = (modifier == FieldModifier.None) ? string.Empty : " ";
            var definition = CodeBuilder.Indent(indent) + scope.AsString() + " " + modifier.AsString() + modSpace + type.As().CSharpName() + " " + name;
            var output = defaultValue == null && type.IsValueType ? ";" : " = " + defaultValue.As().Code(true) + ";";
            return definition + output;
        }
    }
}