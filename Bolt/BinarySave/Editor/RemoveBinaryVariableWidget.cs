using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions.IO
{
    /// <summary>
    /// The visuals and visual behaviour of a RemoveBinaryVariable Unit.
    /// </summary>
    [Widget(typeof(RemoveBinaryVariable))]
    public sealed class RemoveBinaryVariableWidget : UnitWidget<RemoveBinaryVariable>
    {
        public RemoveBinaryVariableWidget(FlowCanvas canvas, RemoveBinaryVariable unit) : base(canvas, unit)
        {
        }

        /// <summary>
        /// Overrides the color of this unit to be Teal like other variable units.
        /// </summary>
        protected override NodeColorMix baseColor => NodeColorMix.TealReadable;
    }
}