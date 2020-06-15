using Bolt;
using Ludiq;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// Clears all variables of a Binary Save object.
    /// </summary>
    [RenamedFrom("Lasm.BoltExtensions.IO.ClearBinarySave")]
    [UnitCategory("IO")]
    public sealed class ClearBinarySave : BinarySaveUnit
    {
        /// <summary>
        /// The Control Input port to enter when we want to clear the BinarySaves variables.
        /// </summary>
        [DoNotSerialize][PortLabelHidden]
        public ControlInput enter;

        /// <summary>
        /// The Control Output port invoked when clearing is complete.
        /// </summary>
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlOutput exit;

        /// <summary>
        /// The Value Input port of the BinarySave.
        /// </summary>
        [DoNotSerialize]
        public ValueInput save;

        protected override void Definition()
        {
            save = ValueInput<BinarySave>("save");
            enter = ControlInput("enter", (flow) => { flow.GetValue<BinarySave>(save).variables.Clear(); return exit; });
            exit = ControlOutput("exit");

            Succession(enter, exit);
        }
    }
}