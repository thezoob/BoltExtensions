using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// A Unit for creating a new Binary Save.
    /// </summary>
    [UnitTitle("Create Binary")]
    [UnitCategory("IO")]
    [RenamedFrom("Lasm.BoltExtensions.IO.CreateBinarySave")]
    public sealed class CreateBinarySave : BinarySaveUnit
    {
        [Serialize]
        private int _count;

        /// <summary>
        /// The amount of variables to initialize with.
        /// </summary>
        [Inspectable]
        [UnitHeaderInspectable("Count")]
        public int count { get { return _count; } set { _count = Mathf.Clamp(value, 0, 100); } }

        /// <summary>
        /// The newly created BinarySave.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput binarySave;

        /// <summary>
        /// Value Input ports for the names of the initialized variables.
        /// </summary>
        [DoNotSerialize]
        public List<ValueInput> names = new List<ValueInput>();

        /// <summary>
        /// Value Input ports for the values of the initialized variables.
        /// </summary>
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
                binary.variables.Add(flow.GetValue<string>(names[i]), flow.GetValue<object>(values[i]));
            }

            return binary;
        }
    }
}