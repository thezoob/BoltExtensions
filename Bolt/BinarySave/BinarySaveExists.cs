using UnityEngine;
using Ludiq;
using Bolt;
using Lasm.OdinSerializer;
using System.IO;

namespace Lasm.BoltExtensions.IO
{
    [UnitCategory("IO")]
    [UnitTitle("Binary Exists")]
    public class BinarySaveExists : BinarySaveUnit
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
        public ControlInput check;
        [DoNotSerialize]
        public ControlOutput @true, @false;

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
            check = ControlInput("check", SaveExists);
            if (!usePersistantDataPath) path = ValueInput<string>("path", string.Empty);
            fileName = ValueInput<string>(nameof(fileName), string.Empty);

            @true = ControlOutput("true");
            @false = ControlOutput("false");

            if (!usePersistantDataPath) Requirement(path, check);
            Requirement(fileName, check);
            Succession(check, @true);
            Succession(check, @false);
        }

        public ControlOutput SaveExists(Flow flow)
        {
            if (File.Exists((usePersistantDataPath) ? Application.persistentDataPath + "/data/" + flow.GetValue<string>(fileName) : flow.GetValue<string>(path) + "/" + flow.GetValue<string>(fileName)))
            {
                return @true;
            }

            return @false;
        }
    }
}