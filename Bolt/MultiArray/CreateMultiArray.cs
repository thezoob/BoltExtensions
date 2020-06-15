using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;
using Lasm.OdinSerializer;
using System;

namespace Lasm.BoltExtensions
{
    [TypeIcon(typeof(object[]))]
    [UnitCategory("Collections/Multi Array")]
    public class CreateArray : Unit
    {
        [OdinSerialize]
        private int _dimensions = 2;
        [Inspectable]
        [UnitHeaderInspectable("Dimensions")]
        public int dimensions
        {
            get { return _dimensions; }
            set { _dimensions = Mathf.Clamp(value, 1, 32); }
        }

        [OdinSerialize]
        [Inspectable]
        [UnitHeaderInspectable("Type")]
        public System.Type type;
        [DoNotSerialize]
        public List<ValueInput> indexes = new List<ValueInput>();
        [DoNotSerialize]
        public ValueOutput list;
        

        protected override void Definition()
        {
            indexes.Clear();

            for (int i = 0; i < dimensions; i++)
            {
                var dimension = ValueInput<int>(i.ToString() + " Length", 0);
                indexes.Add(dimension);
            }

            list = ValueOutput<MultiArray>("array", (flow)=> { return new MultiArray(dimensions); });
        }

        [Obsolete]
        private MultiArray Create(Flow flow)
        {
            return null;
        }

        [Obsolete]
        public MultiArray MakeArrayType(int dimensions, List<int> lengths)
        {
            return null;
        }
    }
}