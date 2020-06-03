using System.Collections;
using System.Collections.Generic;
using Ludiq;
using Bolt;
using UnityEngine;
using UnityEditor;

namespace Lasm.BoltExtensions.IO
{
    /// <summary>
    /// A descriptor for a Save Binary Variable Unit.
    /// </summary>
    [Descriptor(typeof(SaveBinaryVariables))]
    public sealed class SaveBinaryVariableDescriptor : BinarySaveUnitDescriptor
    {
        public SaveBinaryVariableDescriptor(BinarySaveUnit target) : base(target)
        {
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);

            for (int i = 0; i < ((SaveBinaryVariables)target).count; i++)
            {
                if (port.key == "name_" + i.ToString()) description.showLabel = false;
                if (port.key == "value_" + i.ToString()) description.label = "Value";
            }
        }
    }
}