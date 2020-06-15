using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;
using System;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// Gets an item from a multidimensional array.
    /// </summary>
    [UnitCategory("Collections/Multi Array")]
    public sealed class GetArrayItem : Unit
    {
        [Serialize]
        private int _dimensions = 1;

        /// <summary>
        /// Sets the dimensions on this unit, that an array has. Max of 32 dimensions.
        /// </summary>
        [Inspectable]
        [UnitHeaderInspectable("Dimensions")]
        public int dimensions
        {
            get { return _dimensions; }
            set { _dimensions = Mathf.Clamp(value, 1, 32); }
        }

        /// <summary>
        /// The target array to get the item from.
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
        public ValueOutput value;

        protected override void Definition()
        {
            indexes.Clear();

            array = ValueInput<MultiArray>("array");

            for (int i = 0; i < dimensions; i++)
            {
                var dimension = ValueInput<int>(i.ToString() + " Index", 0);
                indexes.Add(dimension);
            }

            value = ValueOutput<object>("result", GetItem);
        }

        private object GetItem(Flow flow)
        {
            var lengths = new List<int>();

            for (int i = 0; i < indexes.Count; i++)
            {
                lengths.Add(flow.GetValue<int>(indexes[i]));
            }

            return flow.GetValue<MultiArray>(array).Get(lengths);
        }
    }
}