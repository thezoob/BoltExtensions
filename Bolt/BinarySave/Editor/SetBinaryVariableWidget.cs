using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions.IO
{
    [Widget(typeof(SetBinaryVariable))]
    public class SetBinaryVariableWidget : UnitWidget<SetBinaryVariable>
    {
        public SetBinaryVariableWidget(FlowCanvas canvas, SetBinaryVariable unit) : base(canvas, unit)
        {
        }

        protected override NodeColorMix baseColor => NodeColorMix.TealReadable;
    }
}