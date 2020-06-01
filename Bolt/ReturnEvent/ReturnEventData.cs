namespace Lasm.BoltExtensions
{
    /// <summary>
    /// Wraps up the arg data we used on the event, to use with the EventReturn unit.
    /// </summary>
    public class ReturnEventData
    {
        /// <summary>
        /// The arguments from the ReturnEvent.
        /// </summary>
        public ReturnEventArg args;

        public ReturnEventData(ReturnEventArg args)
        {
            this.args = args;
        }
    }
}