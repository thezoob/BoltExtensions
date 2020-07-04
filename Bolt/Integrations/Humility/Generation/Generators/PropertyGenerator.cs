using System;

namespace Lasm.BoltExtensions.Humility
{
    public sealed class PropertyGenerator : ConstructGenerator
    {
#pragma warning disable 0649
        private AccessModifier scope;
        private PropertyModifier modifier;
        private AccessModifier getterScope;
        private AccessModifier setterScope;
        private bool hasGetter;
        private bool hasSetter;
        private string getterBody;
        private string setterBody;
        private bool multiStatementGetter;
        private bool multiStatementSetter;
        private string name;
        private object defaultValue;
        private bool hasDefault;
        private Type returnType;
        private string returnTypeString;
        private bool returnTypeIsString;
        private bool stringIsValueType;
        private bool stringIsPrimitive;
        private bool hasBackingField;
#pragma warning restore 0649

        private PropertyGenerator() { }

        public static PropertyGenerator Property(AccessModifier scope, PropertyModifier modifier, Type returnType, string name, bool hasDefault)
        {
            var prop = new PropertyGenerator();
            prop.scope = scope;
            prop.modifier = modifier;
            prop.name = name;
            prop.returnType = returnType;
            return prop;
        }

        public static PropertyGenerator Property(AccessModifier scope, PropertyModifier modifier, string returnType, string name, bool hasDefault, bool isPrimitive, bool isValueType)
        {
            var prop = new PropertyGenerator();
            prop.scope = scope;
            prop.modifier = modifier;
            prop.name = name;
            prop.returnTypeString = returnType;
            prop.returnTypeIsString = true;
            prop.stringIsPrimitive = isPrimitive;
            prop.stringIsValueType = isValueType;
            return prop;
        }

        public PropertyGenerator Default(object value)
        {
            defaultValue = value;
            return this;
        }

        public PropertyGenerator SingleStatementGetter(AccessModifier scope, string body)
        {
            this.getterScope = scope;
            multiStatementGetter = false;
            getterBody = body;
            hasGetter = true;
            return this;
        }


        public PropertyGenerator MultiStatementGetter(AccessModifier scope, string body)
        {
            this.getterScope = scope;
            multiStatementGetter = true;
            getterBody = body;
            hasGetter = true;
            return this;
        }

        public PropertyGenerator SingleStatementSetter(AccessModifier scope, string body)
        {
            this.setterScope = scope;
            multiStatementGetter = false;
            setterBody = body;
            hasSetter = true;
            return this;
        }


        public PropertyGenerator MultiStatementSetter(AccessModifier scope, string body)
        {
            this.setterScope = scope;
            multiStatementSetter = true;
            setterBody = body;
            hasSetter = true;
            return this;
        }

        public override string Generate(int indent)
        {
            if (returnTypeIsString)
            {
                var modSpace = (modifier == PropertyModifier.None) ? string.Empty : " ";
                var definition = CodeBuilder.Indent(indent) + scope.AsString() + " " + modifier.AsString() + modSpace + returnTypeString + " " + name + " " + GetterSetter();
                var output = defaultValue == null && returnType.IsValueType && returnType.IsPrimitive ? (hasGetter || hasSetter ? string.Empty : ";") : hasDefault ? " = " + defaultValue.As().Code(true) + ";" : string.Empty;
                return definition + output;
            }
            else
            {
                var modSpace = (modifier == PropertyModifier.None) ? string.Empty : " ";
                var definition = CodeBuilder.Indent(indent) + scope.AsString() + " " + modifier.AsString() + modSpace + returnType.As().CSharpName() + " " + name + " " + GetterSetter();
                var output = defaultValue == null && stringIsValueType && stringIsPrimitive ? (hasGetter || hasSetter ? string.Empty : ";") : hasDefault ? " = " + defaultValue.As().Code(true) + ";" : string.Empty;
                return definition + output;
            }

            string GetterSetter()
            {
                var result = string.Empty;

                if (multiStatementGetter || multiStatementSetter)
                {
                    return  (getterBody == null ? string.Empty : "{\n" + Getter()) + (setterBody == null ? string.Empty : "\n" + Setter() + "\n") + "}";
                }
                else
                {
                    return "{ " + (getterBody == null ? string.Empty : Getter() + " ") + (setterBody == null ? string.Empty : (getterBody == null ? " " : string.Empty) + Setter() + " ") + "}";
                }
            }

            string Getter()
            {
                if (multiStatementGetter)
                {
                    return CodeBuilder.Indent(indent + 1) + "get\n" + "{\n" + getterBody.Replace("\n", "\n" + CodeBuilder.Indent(indent + 1)) + "/n}";
                }
                else
                {
                    return "get => " + getterBody.Replace("\n", "\n" + CodeBuilder.Indent(indent + 1)) + ";";
                }
            }

            string Setter()
            {
                if (multiStatementSetter)
                {
                    return CodeBuilder.Indent(indent + 1) + "set \n" + "{\n" + setterBody.Replace("\n", "\n" + CodeBuilder.Indent(indent + 1)) + "/n}";
                }
                else
                {
                    return "set => " + setterBody.Replace("\n", "\n" + CodeBuilder.Indent(indent + 1)) + ";";
                }
            }
        }
    }
}