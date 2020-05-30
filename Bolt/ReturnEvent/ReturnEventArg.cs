namespace Lasm.BoltExtensions
{
    public struct ReturnEventArg
    {
        public readonly TriggerReturnEvent trigger;
        public readonly UnityEngine.GameObject target;
        public readonly bool global;
        public readonly object[] arguments;
        public readonly string name;

        public ReturnEventArg(TriggerReturnEvent trigger, UnityEngine.GameObject target, string name, bool global, object[] arguments = null)
        {
            this.trigger = trigger;
            this.target = target;
            this.global = global;
            this.arguments = arguments;
            this.name = name;
        }

        public ReturnEventArg(ReturnEventData data)
        {
            trigger = data.args.trigger;
            target = data.args.target;
            global = data.args.global;
            arguments = data.args.arguments;
            name = data.args.name;
        }
    }
}