using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions.IO
{
    [Widget(typeof(HasBinaryVariable))]
    public class HasBinaryVariableWidget : UnitWidget<HasBinaryVariable>
    {
        public HasBinaryVariableWidget(FlowCanvas canvas, HasBinaryVariable unit) : base(canvas, unit)
        {
        }

        protected override NodeColorMix baseColor => NodeColorMix.TealReadable;
    }
}