using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// The Event that starts some logic before return back flow and a value.
    /// </summary>
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

        /// <summary>
        /// Weither or not the event is able to trigger.
        /// </summary>
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

        /// <summary>
        /// Sets the values of all arguments when triggered.
        /// </summary>
        protected override void AssignArguments(Flow flow, ReturnEventArg args)
        {
            flow.SetValue(eventData, new ReturnEventData(args));

            for (int i = 0; i < arguments.Count; i++)
            {
                flow.SetValue(arguments[i], args.arguments[i + 1]);
            }
        }

        /// <summary>
        /// Trigger the return event. This is meant for internal use of the trigger unit.
        /// </summary>
        /// <param name="trigger">The trigger unit we will return to when it hits a return unit.</param>
        /// <param name="target">The gameobject target of the event</param>
        /// <param name="name">The name of the event.</param>
        /// <param name="global">Is the event global to all Return Events? Will ignore the target GameObject. Target can be null in this case.</param>
        /// <param name="args">The arguments to send through.</param>
        public static void Trigger(TriggerReturnEvent trigger, GameObject target, string name, bool global = false, params object[] args)
        {
            EventBus.Trigger<ReturnEventArg>("Return", new ReturnEventArg(trigger, target, name, global, args));
        }
    }


}