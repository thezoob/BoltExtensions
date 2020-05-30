using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions.IO
{
    [UnitCategory("IO")]
    public class GetBinaryVariable : BinarySaveUnit
    {
        [DoNotSerialize]
        public ValueInput binary;
        [DoNotSerialize][PortLabelHidden]
        public ValueInput variableName;
        [DoNotSerialize][PortLabelHidden]
        public ValueOutput value;
        protected override void Definition()
        {
            binary = ValueInput<BinarySave>(nameof(binary));
            variableName = ValueInput<string>(nameof(variableName), string.Empty);
            value = ValueOutput<object>(nameof(value), GetVariable);

            Requirement(binary, value);
            Requirement(variableName, value);
        }

        private object GetVariable(Flow flow)
        {
            return flow.GetValue<BinarySave>(binary).Get(flow.GetValue<string>(variableName));
        }
    }
}