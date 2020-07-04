using System;
using System.Collections.Generic;

namespace Lasm.BoltExtensions.Humility
{
    /// <summary>
    /// A generator that retains data for creating an attribute as a string.
    /// </summary>
    public sealed class AttributeGenerator : ConstructGenerator
    {
        private Type type;
        private List<object> parameterValues = new List<object>();
        private List<(string, object)> parameterValuesWithLabel = new List<(string, object)>();

        /// <summary>
        /// Generate the attribute as a string.
        /// </summary>
        public override string Generate(int indent)
        {
            var parameters = string.Empty;

            for (int i = 0; i < parameterValues.Count; i++)
            {
                parameters += parameterValues[i].As().Code(false);
                if (i < parameterValues.Count - 1) parameters += ", ";
            }

            for (int i = 0; i < parameterValuesWithLabel.Count; i++)
            {
                parameters += parameterValuesWithLabel[i].Item1 + " = " + parameterValuesWithLabel[i].Item2.As().Code(false);
                if (i < parameterValuesWithLabel.Count - 1) parameters += ", ";
            }

            return CodeBuilder.Indent(indent) + "[" + type.Name + "(" + parameters + ")]";
        }

        private AttributeGenerator()
        {

        }
        
        /// <summary>
        /// Create the attribute generator based on an existing type.
        /// </summary>
        public static AttributeGenerator Attribute<T>() where T : Attribute
        {
            return new AttributeGenerator() { type = typeof(T) } ;
        }

        /// <summary>
        /// Add a parameter to this attribute, to be a part of the final string generated between the parenthesis. Generates without a label. ("MyAttribute(10f)")
        /// </summary>
        public AttributeGenerator AddParameter(object value)
        {
            parameterValues.Add(value);
            return this;
        }

        /// <summary>
        /// Add a parameter to this attribute, to be a part of the final string generated between the parenthesis. Generates with a label ("MyAttribute(SomeLabel:10f)")
        /// </summary>
        public AttributeGenerator AddParameter(string name, object value)
        {
            parameterValuesWithLabel.Add((name, value));
            return this;
        }
    }
}