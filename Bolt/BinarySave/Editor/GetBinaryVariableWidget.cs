using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions.IO
{
    [Widget(typeof(GetBinaryVariable))]
    public class GetBinaryVariableWidget : UnitWidget<GetBinaryVariable>
    {
        public GetBinaryVariableWidget(FlowCanvas canvas, GetBinaryVariable unit) : base(canvas, unit)
        {
        }

        protected override NodeColorMix baseColor => NodeColorMix.TealReadable;
    }
}