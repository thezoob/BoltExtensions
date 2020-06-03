using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions.IO
{
    /// <summary>
    /// The visuals and visual behaviour of a HasBinaryVariable Unit.
    /// </summary>
    [Widget(typeof(HasBinaryVariable))]
    public sealed class HasBinaryVariableWidget : UnitWidget<HasBinaryVariable>
    {
        public HasBinaryVariableWidget(FlowCanvas canvas, HasBinaryVariable unit) : base(canvas, unit)
        {
        }

        /// <summary>
        /// Overrides the color of this unit to be Teal like other variable units.
        /// </summary>
        protected override NodeColorMix baseColor => NodeColorMix.TealReadable;
    }
}