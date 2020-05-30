using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions
{
    [Widget(typeof(TriggerReturnEvent))]
    public class TriggerReturnEventWidget : UnitWidget<TriggerReturnEvent>
    {
        public TriggerReturnEventWidget(FlowCanvas canvas, TriggerReturnEvent unit) : base(canvas, unit)
        {
        }

        protected override NodeColorMix baseColor => NodeColor.Gray;
    }
}