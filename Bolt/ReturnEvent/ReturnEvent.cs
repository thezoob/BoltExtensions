using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions
{
    [UnitCategory("Events")]
    public class ReturnEvent : GlobalEventUnit<ReturnEventArg>
    {
        [Serialize]
        private int _count;
        [Inspectable]
        [UnitHeaderInspectable("Arguments")]
        public int count { get { return _count; } set { _count = Mathf.Clamp(value, 0, 10); } }
        [UnitHeaderInspectable("Global")]
        public bool global;
        [DoNotSerialize]
        public ValueOutput eventData;
        [DoNotSerialize]
        public List<ValueOutput> arguments = new List<ValueOutput>();
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueInput name;
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueOutput value;
        [DoNotSerialize][PortLabelHidden][NullMeansSelf]
        public ValueInput target;
        protected override string hookName { get { return "Return"; } }

        protected override void Definition()
        {
            base.Definition();

            arguments.Clear();

            if (!global) target = ValueInput<GameObject>("target", (GameObject)null).NullMeansSelf();

            name = ValueInput<string>("name", string.Empty);

            eventData = ValueOutput<ReturnEventData>("data");

            for (int i = 0; i < count; i++)
            {
                arguments.Add(ValueOutput<object>(i.ToString()));
            }
        }

        protected override bool ShouldTrigger(Flow flow, ReturnEventArg args)
        {
            bool should = flow.GetValue<string>(name) == args.name;

            if (arguments.Count + 1 == args.arguments.Length && should)
            {
                if (args.global)
                {
                    return true;
                }
                else
                {
                    if (args.target != null && args.target == flow.GetValue<GameObject>(target)) return true;
                }
            }

            return false;
        }

        protected override void AssignArguments(Flow flow, ReturnEventArg args)
        {
            flow.SetValue(eventData, new ReturnEventData(args));

            for (int i = 0; i < arguments.Count; i++)
            {
                flow.SetValue(arguments[i], args.arguments[i + 1]);
            }
        }

        public static void Trigger(TriggerReturnEvent trigger, GameObject target, string name, bool global = false, params object[] args)
        {
            EventBus.Trigger<ReturnEventArg>("Return", new ReturnEventArg(trigger, target, name, global, args));
        }
    }


}