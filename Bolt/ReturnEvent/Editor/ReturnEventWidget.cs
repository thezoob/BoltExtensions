using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions
{
    [Widget(typeof(ReturnEvent))]
    public class ReturnEventWidget : UnitWidget<ReturnEvent>
    {
        public ReturnEventWidget(FlowCanvas canvas, ReturnEvent unit) : base(canvas, unit)
        {
        }

        protected override NodeColorMix baseColor => NodeColor.Green;
    }
}