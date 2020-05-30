using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions.IO
{
    [UnitCategory("IO")]
    public class RemoveBinaryVariable : BinarySaveUnit
    {
        [DoNotSerialize][PortLabelHidden]
        public ControlInput enter;
        [DoNotSerialize][PortLabelHidden]
        public ControlOutput exit;
        [DoNotSerialize]
        public ValueInput binary;
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueInput variableName;

        protected override void Definition()
        {
            enter = ControlInput("enter", RemoveVariable);
            binary = ValueInput<BinarySave>(nameof(binary));
            variableName = ValueInput<string>(nameof(variableName), string.Empty);
            exit = ControlOutput("exit");

            Succession(enter, exit);
            Requirement(binary, enter);
            Requirement(variableName, enter);
        }

        private ControlOutput RemoveVariable(Flow flow)
        {
            flow.GetValue<BinarySave>(binary).Remove(flow.GetValue<string>(variableName));
            return exit;
        }
    }
}