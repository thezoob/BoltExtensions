using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions.IO
{
    [Widget(typeof(RemoveBinaryVariable))]
    public class RemoveBinaryVariableWidget : UnitWidget<RemoveBinaryVariable>
    {
        public RemoveBinaryVariableWidget(FlowCanvas canvas, RemoveBinaryVariable unit) : base(canvas, unit)
        {
        }

        protected override NodeColorMix baseColor => NodeColorMix.TealReadable;
    }
}