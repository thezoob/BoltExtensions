using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions.IO
{
    [UnitTitle("Create Binary")]
    [UnitCategory("IO")]
    public class CreateBinarySave : BinarySaveUnit
    {
        [Serialize]
        private int _count;
        [Inspectable]
        [UnitHeaderInspectable("Count")]
        public int count { get { return _count; } set { _count = Mathf.Clamp(value, 0, 100); } }
        [DoNotSerialize]
        public ValueOutput binarySave;
        [DoNotSerialize]
        public List<ValueInput> names = new List<ValueInput>();
        [DoNotSerialize]
        public List<ValueInput> values = new List<ValueInput>();

        protected override void Definition()
        {
            values.Clear();

            DefineVariablePorts();

            binarySave = ValueOutput<BinarySave>("_binary", GetBinaryOutput);
        }

        private void DefineVariablePorts()
        {
            for (int i = 0; i < count; i++)
            {
                var namePort = ValueInput<string>("name_" + i.ToString(), string.Empty);
                var valuePort = ValueInput<object>("value_" + i.ToString());
                names.Add(namePort);
                values.Add(valuePort);
            }
        }
        
        private BinarySave GetBinaryOutput(Flow flow)
        {
            var binary = new BinarySave();

            for (int i = 0; i < count; i++)
            {
                binary.saves.Add(flow.GetValue<string>(names[i]), flow.GetValue<object>(values[i]));
            }

            return binary;
        }
    }

}