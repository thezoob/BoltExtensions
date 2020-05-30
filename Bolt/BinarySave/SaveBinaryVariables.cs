using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;
using Lasm.OdinSerializer;

namespace Lasm.BoltExtensions.IO
{
    [UnitTitle("Save Binary")]
    [UnitCategory("IO")]
    public class SaveBinaryVariables : BinarySaveUnit
    {
        [Serialize]
        [Inspectable]
        [InspectorToggleLeft]
        public bool usePersistantDataPath = true, append = false, promoteToInputPort = true;
        [Serialize]
        private int _count;
        [Inspectable]
        [UnitHeaderInspectable("Count")]
        public int count { get { return _count; } set { _count = Mathf.Clamp(value, 0, 100); } }
        [DoNotSerialize]
        public ValueInput path, fileName, binarySave;
        [DoNotSerialize]
        public ValueOutput binarySaveOut;
        public BinarySave lastSave;
        [DoNotSerialize]
        public List<ValueInput> names = new List<ValueInput>();
        [DoNotSerialize]
        public List<ValueInput> values = new List<ValueInput>();
        [DoNotSerialize]
        public ControlInput save;
        [DoNotSerialize]
        public ControlOutput complete;

        protected override void Definition()
        {
            values.Clear();

            if (promoteToInputPort) binarySave = ValueInput<BinarySave>("binary");

            if (!usePersistantDataPath) path = ValueInput<string>("path", string.Empty);
            fileName = ValueInput<string>("fileName", string.Empty);

            complete = ControlOutput("complete");
            DefineSaveControlPort();
            if (!promoteToInputPort) DefineVariablePorts();

            binarySaveOut = ValueOutput<BinarySave>("_binary", GetBinaryOutput);

            Requirement(fileName, save);
            Succession(save, complete);
        }

        private void DefineVariablePorts()
        {
            for (int i = 0; i < count; i++)
            {
                var namePort = ValueInput<string>("name_" + i.ToString(), string.Empty);
                var valuePort = ValueInput<object>("value_" + i.ToString());
                names.Add(namePort);
                values.Add(valuePort);
                Requirement(namePort, save);
                Requirement(valuePort, save);
            }
        }

        private void DefineSaveControlPort()
        {
            save = ControlInput("save", SaveBinary);
        }

        private void Save(Flow flow, BinarySave binary)
        {
            BinarySave.Save(GetPath(flow), binary);
        }

        private ControlOutput SaveBinary(Flow flow)
        {
            var binary = promoteToInputPort == true ? flow.GetValue<BinarySave>(binarySave) : new BinarySave();
            var loadedSave = append ? BinarySave.Load(GetPath(flow)) : null;

            if (!promoteToInputPort)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    if (!string.IsNullOrEmpty(values[i].key))
                    {
                        binary.Set(flow.GetValue<string>(names[i]), flow.GetValue<object>(values[i]));
                    }
                }
            }

            if (loadedSave != null)
            {
                if (!promoteToInputPort)
                {
                    for (int i = 0; i < binary.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(values[i].key))
                        {
                            loadedSave.Set(flow.GetValue<string>(names[i]), flow.GetValue<object>(values[i]));
                        }
                    }
                }
                else
                {
                    var saveKeys = binary.saves.Keys.ToArrayPooled();
                    var saveValues = binary.saves.Values.ToArrayPooled();

                    for (int i = 0; i < binary.Count; i++)
                    {
                        loadedSave.Set(saveKeys[i], saveValues[i]);
                    }

                }

                Save(flow, loadedSave);

                lastSave = loadedSave;
            }
            else
            {
                Save(flow, binary);
                lastSave = binary;
            }


            return complete;
        }

        private string GetPath(Flow flow)
        {
            return (usePersistantDataPath) ? Application.persistentDataPath + "/data/" + flow.GetValue<string>(fileName) : flow.GetValue<string>(path) + "/" + flow.GetValue<string>(fileName);
        }

        private BinarySave GetBinaryOutput(Flow flow)
        {
            return lastSave;
        }
    }

}