using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;
using System;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// Sets an item from a multidimensional array.
    /// </summary>
    [TypeIcon(typeof(object[]))]
    [UnitCategory("Collections/Multi Array")]
    public class SetArrayItem : Unit
    {
        [Serialize]
        private int _dimensions = 1;

        /// <summary>
        /// Sets the dimensions on this unit, that an array has.
        /// </summary>
        [Inspectable]
        [UnitHeaderInspectable("Dimensions")]
        public int dimensions
        {
            get { return _dimensions; }
            set { _dimensions = Mathf.Clamp(value, 1, 32); }
        }

        /// <summary>
        /// The target array to set the item on.
        /// </summary>
        [DoNotSerialize]
        public ValueInput array;

        /// <summary>
        /// The Value Inputs of each dimensions length.
        /// </summary>
        [DoNotSerialize]
        public List<ValueInput> indexes = new List<ValueInput>();

        /// <summary>
        /// The value of the desired selection of dimensions.
        /// </summary>
        [DoNotSerialize]
        public ValueInput value;

        /// <summary>
        /// The Control Input entered when we want to set the item.
        /// </summary>
        [DoNotSerialize][PortLabelHidden]
        public ControlInput enter;

        /// <summary>
        /// The Control Ouput invoked when setting the array item is complete.
        /// </summary>
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlOutput exit;

        protected override void Definition()
        {
            indexes.Clear();

            enter = ControlInput("enter", SetItem);

            array = ValueInput<MultiArray>("array");

            for (int i = 0; i < dimensions; i++)
            {
                var dimension = ValueInput<int>(i.ToString() + " Index", 0);
                indexes.Add(dimension);
            }

            value = ValueInput<object>("value");

            exit = ControlOutput("exit");
        }

        private ControlOutput SetItem(Flow flow)
        {
            var lengths = new List<int>();

            for (int i = 0; i < indexes.Count; i++)
            {
                lengths.Add(flow.GetValue<int>(indexes[i]));
            }

            flow.GetValue<MultiArray>(array).Set(flow.GetValue<object>(value), lengths);

            return exit;
        }
    }
}