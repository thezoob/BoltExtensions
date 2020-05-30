using UnityEngine;
using Ludiq;
using Bolt;
using Lasm.OdinSerializer;

namespace Lasm.BoltExtensions.IO
{
    [UnitCategory("IO")]
    [UnitTitle("Delete Save")]
    public class DeleteBinarySave : BinarySaveUnit
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
        public ControlInput delete;
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
            if (!usePersistantDataPath) path = ValueInput<string>("path", string.Empty);
            fileName = ValueInput<string>(nameof(fileName), string.Empty);

            complete = ControlOutput("complete");
            delete = ControlInput("delete", (flow) => {
                BinarySave.Delete((usePersistantDataPath) ? Application.persistentDataPath + "/data/" + flow.GetValue<string>(fileName) : flow.GetValue<string>(path) + "/" + flow.GetValue<string>(fileName));
                return complete;
            });

            Requirement(fileName, delete);
            Succession(delete, complete);
        }

    }
}