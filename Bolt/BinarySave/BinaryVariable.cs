using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;

namespace Lasm.BoltExtensions.IO
{
    [Inspectable]
    public class BinaryVariable
    {
        public BinaryVariable(string name, object value)
        {
            this.name = name;
            this.value = value;
        }

        [Inspectable]
        public string name;
        [Inspectable]
        public object value;
    }
}