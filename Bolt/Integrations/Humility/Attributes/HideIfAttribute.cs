using System;
using UnityEngine;

namespace Lasm.BoltExtensions.Humility
{
    /// <summary>
    /// Marks a field or property to hide if a condition is true.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class HideIfAttribute : PropertyAttribute
    {
        public string memberName;
        
        public HideIfAttribute(string memberName)
        {
            this.memberName = memberName;
        }
    }
}