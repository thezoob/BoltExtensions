using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;
using Lasm.OdinSerializer;

namespace Lasm.BoltExtensions.IO
{
    [UnitCategory("IO")]
    [UnitTitle("Load Binary")]
    public class LoadBinaryVariables : BinarySaveUnit
    {
        [Serialize]
        [Inspectable]
        [InspectorToggleLeft]
        public bool usePersistantDataPath = true;
        [OdinSerialize]
        public bool isInit;
        [DoNotSerialize]
        public ValueInput path, fileName;
        [DoNotSerialize]
        public List<ValueInput> names = new List<ValueInput>(), values = new List<ValueInput>();
        [DoNotSerialize]
        public ValueOutput binary;
        [DoNotSerialize]
        public ControlInput load;
        [DoNotSerialize]
        public ControlOutput complete;

        public override void AfterAdd()
        {
            base.AfterAdd();

            if (!isInit)
            {
                usePersistantDataPath = true;
                Define();
                isInit = true;
            }
        }

        protected override void Definition()
        {
            names.Clear();
            values.Clear();

            if (!usePersistantDataPath) path = ValueInput<string>("path", string.Empty);
            fileName = ValueInput<string>(nameof(fileName), string.Empty);
            binary = ValueOutput<BinarySave>(nameof(binary));

            complete = ControlOutput("complete");
            load = ControlInput("load", (flow) => {
                flow.SetValue(binary, BinarySave.Load((usePersistantDataPath) ? Application.persistentDataPath + "/data/" + flow.GetValue<string>(fileName) : flow.GetValue<string>(path) + "/" + flow.GetValue<string>(fileName)));
                return complete;
            });

            Requirement(fileName, binary);
            Requirement(fileName, load);
            Succession(load, complete);
        }

    }
}