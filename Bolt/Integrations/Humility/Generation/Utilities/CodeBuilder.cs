using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;

namespace Lasm.BoltExtensions.Humility
{
    /// <summary>
    /// Gives you access to utilities methods to more easily build custom code.
    /// </summary>
    public static class CodeBuilder
    {
        /// <summary>
        /// Creates the opening of a new body as a string.
        /// </summary>
        public static string OpenBody(int indent)
        {
            var output = string.Empty;

            output += Indent(indent) + "{";

            return output;
        }

        /// <summary>
        /// Creates the opening of a new body as a string with custom indent spacing.
        /// </summary>
        public static string OpenBody(int indent, int spaces)
        {
            var output = string.Empty;

            output += Indent(indent) + "{";

            for (int i = 0; i < spaces; i++)
            {
                output += "\n";
            }

            return output;
        }

        /// <summary>
        /// Creates the closing of a body as a string.
        /// </summary>
        public static string CloseBody(int indent)
        {
            var output = string.Empty;

            output += Indent(indent) + "}";

            return output;
        }

        /// <summary>
        /// Creates the closing of a body as a string with custom indent spacing.
        /// </summary>
        public static string CloseBody(int indent, int spaces)
        {
            var output = string.Empty;

            output += Indent(indent) + "}";

            for (int i = 0; i < spaces; i++)
            {
                output += "\n";
            }

            return output;
        }

        /// <summary>
        /// Creates an indentation. The spacing is equal to 4 whitespaces.
        /// </summary>
        public static string Indent(int amount)
        {
            var output = string.Empty;

            for (int i = 0; i < amount; i++)
            {
                output += "    ";
            }

            return output;
        }

        /// <summary>
        /// Creates an indentation with a custom amount of whitespaces per indent.
        /// </summary>
        public static string Indent(int amount, int spacing)
        {
            var output = string.Empty;
            var space = string.Empty;

            for (int i = 0; i < spacing; i++)
            {
                space += " ";
            }

            for (int i = 0; i < amount; i++)
            {
                output += space;
            }

            return output;
        }

        /// <summary>
        /// Creates a series of using statements for namespace access.
        /// </summary>
        public static string Using(string[] namespaces)
        {
            var output = string.Empty;

            for (int i = 0; i < namespaces.Length; i++)
            {
                output += "using " + namespaces[i] + ";\n";
            }

            return output;
        }
    }
}