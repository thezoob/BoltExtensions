using Bolt;
using Ludiq;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// The root of all Binary Units. Does nothing on its own. Used for consistancy for units and the editors.
    /// </summary>
    [RenamedFrom("Lasm.BoltExtensions.IO.BinarySaveUnit")]
    public abstract class BinarySaveUnit : Unit
    {
        protected override void Definition()
        {
            
        }
    }
}