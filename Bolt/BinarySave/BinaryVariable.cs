using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// A single variable that is the data type for BinarySaves to store in its internal dictionary.
    /// </summary>
    [Inspectable]
    [RenamedFrom("Lasm.BoltExtensions.IO.BinaryVariable")]
    public sealed class BinaryVariable
    {
        /// <summary>
        /// Assign a name and value upon creating a new variable.
        /// </summary>
        public BinaryVariable(string name, object value)
        {
            this.name = name;
            this.value = value;
        }

        /// <summary>
        /// The name of the variable.
        /// </summary>
        [Inspectable]
        public string name;

        /// <summary>
        /// The variables value.
        /// </summary>
        [Inspectable]
        public object value;
    }
}