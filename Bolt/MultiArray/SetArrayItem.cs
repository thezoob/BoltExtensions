using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions
{
    [TypeIcon(typeof(object[]))]
    [UnitCategory("Collections/Multi Array")]
    public class SetArrayItem : Unit
    {
        [Serialize]
        private int _dimensions = 1;
        [Inspectable]
        [UnitHeaderInspectable("Dimensions")]
        public int dimensions
        {
            get { return _dimensions; }
            set { _dimensions = Mathf.Clamp(value, 1, 32); }
        }

        [DoNotSerialize]
        public ValueInput array;
        [DoNotSerialize]
        public List<ValueInput> indexes = new List<ValueInput>();
        [DoNotSerialize]
        public ValueInput value;
        [DoNotSerialize][PortLabelHidden]
        public ControlInput enter;
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlOutput exit;

        protected override void Definition()
        {
            indexes.Clear();

            enter = ControlInput("enter", SetItem);

            array = ValueInput<System.Array>("array");

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


            switch (_dimensions)
            {
                case 1:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0] });
                        break;
                    }

                case 2:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1] });
                        break;
                    }

                case 3:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2] });
                        break;
                    }

                case 4:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3] });
                        break;
                    }

                case 5:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4] });
                        break;
                    }

                case 6:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5] });
                        break;
                    }

                case 7:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6] });
                        break;
                    }

                case 8:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7] });
                        break;
                    }

                case 9:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8] });
                        break;
                    }

                case 10:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9] });
                        break;
                    }

                case 11:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10] });
                        break;
                    }

                case 12:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11] });
                        break;
                    }

                case 13:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12] });
                        break;
                    }

                case 14:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13] });
                        break;
                    }

                case 15:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14] });
                        break;
                    }

                case 16:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15] });
                        break;
                    }

                case 17:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16] });
                        break;
                    }

                case 18:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17] });
                        break;
                    }

                case 19:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18] });
                        break;
                    }

                case 20:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19] });
                        break;
                    }

                case 21:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20] });
                        break;
                    }

                case 22:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21] });
                        break;
                    }

                case 23:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22] });
                        break;
                    }

                case 24:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23] });
                        break;
                    }

                case 25:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24] });
                        break;
                    }

                case 26:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25] });
                        break;
                    }

                case 27:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26] });
                        break;
                    }

                case 28:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27] });
                        break;
                    }

                case 29:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28] });
                        break;
                    }

                case 30:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28], lengths[29] });
                        break;
                    }

                case 31:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28], lengths[29], lengths[30] });
                        break;
                    }

                case 32:
                    {
                        flow.GetValue<System.Array>(array).SetValue(flow.GetValue<object>(value), new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28], lengths[29], lengths[30], lengths[31] });
                        break;
                    }
            }

            return exit;
        }
    }
}