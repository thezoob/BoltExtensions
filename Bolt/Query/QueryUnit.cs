using Bolt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Ludiq;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// A unit for using Linq querying operations in a Bolt graph.
    /// </summary>
    [UnitTitle("Query")]
    [UnitCategory("Collections")]
    [TypeIcon(typeof(IEnumerable))]
    public class QueryUnit : Unit
    {
        [UnitHeaderInspectable("Operation")]
        public QueryOperation operation;

        /// <summary>
        /// The Control Input entered when we want to begin the query
        /// </summary>
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlInput enter;

        /// <summary>
        /// An optional control flow for helping to determine the condition of the current loops item in relation to the results.
        /// </summary>
        [DoNotSerialize]
        public ControlOutput body;

        /// <summary>
        /// The Control Output for when the query is complete.
        /// </summary>
        [DoNotSerialize]
        public ControlOutput exit;

        /// <summary>
        /// The ValueInput for the collection/list we will be querying through.
        /// </summary>
        [DoNotSerialize]
        public ValueInput collection;

        /// <summary>
        /// The ValueInput for the condition to check for each item in the query.
        /// </summary>
        [DoNotSerialize]
        public ValueInput condition;

        /// <summary>
        /// The ValueInput for the condition to check for each item in the query.
        /// </summary>
        [DoNotSerialize]
        public ValueInput key;

        /// <summary>
        /// The ValueOutput for the current item of the query.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput item;

        /// <summary>
        /// The ValueOutput of the resulting collection after querying.
        /// </summary>
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

            switch (operation)
            {
                case QueryOperation.OrderBy:
                    key = ValueInput<object>("key");
                    break;
                case QueryOperation.Single:
                    condition = ValueInput<bool>("condition");
                    break;
                case QueryOperation.Where:
                    condition = ValueInput<bool>("condition");
                    break;
            }

            exit = ControlOutput("exit");
            body = ControlOutput("body");
            item = ValueOutput<object>("item", (flow) => { return current; });

            switch (operation)
            {
                case QueryOperation.OrderBy:
                    result = ValueOutput("result", (flow) => { return output; });
                    break;
                case QueryOperation.Single:
                    result = ValueOutput<object>("result", (flow) => { return single; });
                    break;
                case QueryOperation.Where:
                    result = ValueOutput("result", (flow) => { return output; });
                    break;
            }

            Succession(enter, exit);
            Succession(enter, body);

            Assignment(enter, item);

            switch (operation)
            {
                case QueryOperation.OrderBy:
                    Requirement(key, enter);
                    break;
                case QueryOperation.Single:
                    Requirement(condition, enter);
                    break;
                case QueryOperation.Where:
                    Requirement(condition, enter);
                    break;
            }
        }

        private void PerformOperation(Flow flow)
        {
            switch (operation)
            {
                case QueryOperation.OrderBy:
                    output = flow.GetValue<IEnumerable>(collection).Cast<object>().OrderBy((item) =>
                    {
                        current = item;
                        flow.Invoke(body);
                        return flow.GetValue<object>(key);
                    }).ToList<object>();
                    break;

                case QueryOperation.Single:
                    single = flow.GetValue<IEnumerable>(collection).Cast<object>().Single((item) =>
                    {
                        current = item;
                        flow.Invoke(body);
                        return flow.GetValue<bool>(condition);
                    });
                    break;

                case QueryOperation.Where:
                    output = flow.GetValue<IEnumerable>(collection).Cast<object>().Where((item) =>
                    {
                        current = item;
                        flow.Invoke(body);
                        return flow.GetValue<bool>(condition);
                    }).ToList<object>();
                    break;
            }
        }
    }
}