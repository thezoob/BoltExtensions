﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// The Unit that returns your flow and value back to the Complete port of the initial trigger unit.
    /// </summary>
    [UnitCategory("Events")][UnitShortTitle("Return")][UnitSubtitle("Return Event")]
    public class EventReturn : Unit
    {
        /// <summary>
        /// The Control Input entered when we want to return back.
        /// </summary>
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlInput enter;

        /// <summary>
        /// The Value Input that set the value to return back.
        /// </summary>
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueInput value;

        /// <summary>
        /// The data output from the ReturnEventUnit. This is necessary for the unit to return back to the original unit, as it stores the data about which unit we came from.
        /// </summary>
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

        /// <summary>
        /// Set the data to return back, then triggers a return back to the ReturnEventUnit.
        /// </summary>
        public ControlOutput Enter(Flow flow)
        {
            var _data = flow.GetValue<ReturnEventData>(data);
            var val = flow.GetValue(value);
            _data.args.trigger.storingValue = val;
            TriggerReturnEvent.Trigger(_data.args);
            return null;
        }
    }
}