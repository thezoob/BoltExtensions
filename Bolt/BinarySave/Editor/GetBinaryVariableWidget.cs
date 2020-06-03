using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions.IO
{
    /// <summary>
    /// The visuals and visual behaviour of a GetBinaryVariable Unit.
    /// </summary>
    [Widget(typeof(GetBinaryVariable))]
    public sealed class GetBinaryVariableWidget : UnitWidget<GetBinaryVariable>
    {
        public GetBinaryVariableWidget(FlowCanvas canvas, GetBinaryVariable unit) : base(canvas, unit)
        {
        }

        /// <summary>
        /// Overrides the color of this unit to be Teal like other variable units.
        /// </summary>
        protected override NodeColorMix baseColor => NodeColorMix.TealReadable;
    }
}