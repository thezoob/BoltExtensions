using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;
using System.Linq;

namespace Lasm.BoltExtensions
{
    [UnitCategory("Events")]
    public class TriggerReturnEvent : GlobalEventUnit<ReturnEventArg>
    {
        protected override string hookName => "TriggerReturn";

        [Serialize]
        private int _count;

        [Inspectable]
        [UnitHeaderInspectable("Arguments")]
        public int count { get { return _count; } set { _count = Mathf.Clamp(value, 0, 10); } }
        [UnitHeaderInspectable("Global")]
        public bool global;

        public object storingValue;

        [DoNotSerialize]
        [PortLabelHidden]
        public ControlInput enter;
        [DoNotSerialize]
        [PortLabelHidden]
        [NullMeansSelf]
        public ValueInput target, name;
        [DoNotSerialize]
        public ControlOutput exit, complete;
        [DoNotSerialize]
        public List<ValueInput> arguments = new List<ValueInput>();
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueOutput value;
        
        protected override void Definition()
        {
            base.Definition();

            arguments.Clear();

            enter = ControlInput("enter", Enter);

            name = ValueInput<string>("name", string.Empty);

            if (!global) target = ValueInput<GameObject>("target", (GameObject)null).NullMeansSelf();

            for (int i = 0; i < count; i++)
            {
                var input = ValueInput<object>(i.ToString());
                arguments.Add(input);
                Requirement(input, enter);
            }

            exit = ControlOutput("exit");
            value = ValueOutput<object>("value", GetValue);
            
            Succession(enter, exit);
            Requirement(name, enter);
            if (!global) Requirement(target, enter);
            Succession(enter, trigger);
        }

        public ControlOutput Enter(Flow flow)
        {
            List<object> argumentList = new List<object>();
            var eventData = new ReturnEventData(new ReturnEventArg(this, global ? (GameObject)null : flow.GetValue<GameObject>(target), flow.GetValue<string>(name), global, argumentList.ToArray()));
            argumentList.Add(eventData);
            argumentList.AddRange(arguments.Select(new System.Func<ValueInput, object>(flow.GetConvertedValue)));
            ReturnEvent.Trigger(this, global ? (GameObject)null : flow.GetValue<GameObject>(target), flow.GetValue<string>(name), global, argumentList.ToArray());
          
            return exit;
        }

        public object GetValue(Flow flow)
        {
            return storingValue;
        }
       
        public static void Trigger(ReturnEventArg args)
        {
            if (args.global) { EventBus.Trigger<ReturnEventArg>("TriggerReturn", args); return; }
            EventBus.Trigger<ReturnEventArg>("TriggerReturn", args);
        }

        protected override bool ShouldTrigger(Flow flow, ReturnEventArg args)
        {
            if (args.trigger == this && global && args.name == flow.GetValue<string>(name)) return true;
            if (args.trigger == this && !global && args.target == flow.GetValue<GameObject>(target)) return true;
            return false;
        }
    }
}