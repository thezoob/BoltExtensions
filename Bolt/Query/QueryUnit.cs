using Bolt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Ludiq;

namespace Lasm.BoltExtensions
{
    [UnitTitle("Query")]
    [UnitCategory("Collections")]
    [TypeIcon(typeof(IEnumerable))]
    public class QueryUnit : Unit
    {
        [UnitHeaderInspectable("Operation")]
        public QueryOperation operation;

        [DoNotSerialize]
        [PortLabelHidden]
        public ControlInput enter;

        [DoNotSerialize]
        public ControlOutput body;

        [DoNotSerialize]
        public ControlOutput exit;

        [DoNotSerialize]
        public ValueInput collection;

        [DoNotSerialize]
        public ValueInput condition;

        [DoNotSerialize]
        public ValueOutput item;

        [DoNotSerialize]
        public ValueOutput result;

        private object current;
        private IEnumerable<object> output;
        private object single;

        protected override void Definition()
        {
            enter = ControlInput("enter", (flow) =>
            {
                PerformOperation(flow);
                return exit;
            });

            collection = ValueInput<IEnumerable<object>>("collection");
            condition = ValueInput<bool>("condition");

            exit = ControlOutput("exit");
            body = ControlOutput("body");
            item = ValueOutput<object>("item", (flow) => { return current; });

            switch (operation)
            {
                case QueryOperation.OrderBy:
                    result = ValueOutput<IEnumerable<object>>("result", (flow) => { return output; });
                    break;
                case QueryOperation.Single:
                    result = ValueOutput<object>("result", (flow) => { return single; });
                    break;
                case QueryOperation.Where:
                    result = ValueOutput<IEnumerable<object>>("result", (flow) => { return output; });
                    break;
            }

            Succession(enter, exit);
            Succession(enter, body);
            Requirement(condition, enter);
            Assignment(enter, item);
        }

        private void PerformOperation(Flow flow)
        {
            switch (operation)
            {
                case QueryOperation.OrderBy:
                    output = flow.GetValue<IEnumerable<object>>(collection).OrderBy((item) =>
                    {
                        current = item;
                        flow.Invoke(body);
                        return flow.GetValue<bool>(condition);
                    });
                    break;

                case QueryOperation.Single:
                    single = flow.GetValue<IEnumerable<object>>(collection).Single((item) =>
                    {
                        current = item;
                        flow.Invoke(body);
                        return flow.GetValue<bool>(condition);
                    });
                    break;

                case QueryOperation.Where:
                    output = flow.GetValue<IEnumerable<object>>(collection).Where((item) =>
                    {
                        current = item;
                        flow.Invoke(body);
                        return flow.GetValue<bool>(condition);
                    });
                    break;
            }
        }
    }
}