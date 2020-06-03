using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions.IO
{
    /// <summary>
    /// The visuals and visual behaviour of a SetBinaryVariable Unit.
    /// </summary>
    [Widget(typeof(SetBinaryVariable))]
    public sealed class SetBinaryVariableWidget : UnitWidget<SetBinaryVariable>
    {
        public SetBinaryVariableWidget(FlowCanvas canvas, SetBinaryVariable unit) : base(canvas, unit)
        {
        }

        /// <summary>
        /// Overrides the color of this unit to be Teal like other variable units.
        /// </summary>
        protected override NodeColorMix baseColor => NodeColorMix.TealReadable;
    }
}