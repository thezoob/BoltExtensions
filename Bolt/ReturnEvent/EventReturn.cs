using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions
{
    [UnitCategory("Events")][UnitShortTitle("Return")][UnitSubtitle("Return Event")]
    public class EventReturn : Unit
    {
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlInput enter;
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueInput value;
        [DoNotSerialize]
        public ValueInput data;
        private GraphReference triggerReference;
        private FlowMachine machine;

        protected override void Definition()
        {
            enter = ControlInput("enter", Enter);
            data = ValueInput<ReturnEventData>("data");
            value = ValueInput<object>("value");
        }

        public ControlOutput Enter(Flow flow)
        {
            var _data = flow.GetValue<ReturnEventData>(data);
            var val = flow.GetValue(value);
            Debug.Log(_data);
            Debug.Log(_data.args);
            Debug.Log(_data.args.trigger);
            _data.args.trigger.storingValue = val;
            TriggerReturnEvent.Trigger(_data.args);
            return null;
        }
    }
}