using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions.IO
{
    [UnitCategory("IO")]
    public class SetBinaryVariable : BinarySaveUnit
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
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueInput value;
        protected override void Definition()
        {
            enter = ControlInput("enter", SetVariable);
            binary = ValueInput<BinarySave>(nameof(binary));
            variableName = ValueInput<string>(nameof(variableName), string.Empty);
            value = ValueInput<object>(nameof(value));
            exit = ControlOutput("exit");

            Requirement(binary, enter);
            Requirement(value, enter);
            Requirement(variableName, enter);

            Succession(enter, exit);
        }

        private ControlOutput SetVariable(Flow flow)
        {
            flow.GetValue<BinarySave>(binary).Set(flow.GetValue<string>(variableName), flow.GetValue<object>(value));
            return exit;
        }
    }
}