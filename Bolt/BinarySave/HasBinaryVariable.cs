using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

namespace Lasm.BoltExtensions.IO
{
    [UnitCategory("IO")]
    public class HasBinaryVariable : BinarySaveUnit
    {
        [DoNotSerialize]
        public ValueInput binary;
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueInput variableName;
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueOutput result;
        protected override void Definition()
        {
            binary = ValueInput<BinarySave>(nameof(binary));
            variableName = ValueInput<string>(nameof(variableName), string.Empty);
            result = ValueOutput<bool>(nameof(result), HasVariable);

            Requirement(binary, result);
            Requirement(variableName, result);
        }

        private bool HasVariable(Flow flow)
        {
            return flow.GetValue<BinarySave>(binary).Has(flow.GetValue<string>(variableName));
        }
    }
}