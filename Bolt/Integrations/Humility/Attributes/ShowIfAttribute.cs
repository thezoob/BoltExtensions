using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lasm.BoltExtensions.Humility
{
    /// <summary>
    /// Marks a field or property to show if a condition is true.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ShowIfAttribute : PropertyAttribute
    {
        public string memberName;
       
        public ShowIfAttribute(string memberName)
        {
            this.memberName = memberName;
        }
    }
}