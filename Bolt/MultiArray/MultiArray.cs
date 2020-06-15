using Ludiq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lasm.OdinSerializer;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// A multi array type. Currently does nothing. We want editor creation capabilities. This is how we'll go about it, using a custom type.
    /// </summary>
    [Serializable]
    [Inspectable]
    [IncludeInSettings(true)]
    public class MultiArray
    {
        [OdinSerialize]
        [Inspectable]
        public Type type = typeof(int);

        [Inspectable]
        public int dimensions = 1;

#if UNITY_EDITOR 
        public int lastDimensions = 1;
        [OdinSerialize]
        public Type lastType = typeof(int);
#endif

        [Inspectable]
        public List<int> lengths { get; internal set; } = new List<int>();

        [OdinSerialize]
        [DoNotSerialize]
        public Array array = null;

        public MultiArray()
        {
            lengths.Add(1);
            array = Create();
        }

        public MultiArray(int dimensions)
        {
            lengths.Add(dimensions);
            array = Create();
        }

        public System.Array Create()
        {
            switch (dimensions)
            {
                case 1:
                    {
                        return System.Array.CreateInstance(type, lengths[0]);
                    }

                case 2:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1]);
                    }

                case 3:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2]);
                    }

                case 4:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3]);
                    }

                case 5:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4]);
                    }

                case 6:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5]);
                    }

                case 7:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6]);
                    }

                case 8:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7]);
                    }

                case 9:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8]);
                    }

                case 10:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9]);
                    }

                case 11:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10]);
                    }

                case 12:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11]);
                    }

                case 13:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12]);
                    }

                case 14:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13]);
                    }

                case 15:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14]);
                    }

                case 16:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15]);
                    }

                case 17:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16]);
                    }

                case 18:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17]);
                    }

                case 19:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18]);
                    }

                case 20:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19]);
                    }

                case 21:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20]);
                    }

                case 22:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21]);
                    }

                case 23:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22]);
                    }

                case 24:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23]);
                    }

                case 25:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24]);
                    }

                case 26:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25]);
                    }

                case 27:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26]);
                    }

                case 28:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27]);
                    }

                case 29:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28]);
                    }

                case 30:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28], lengths[29]);
                    }

                case 31:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28], lengths[29], lengths[30]);
                    }

                case 32:
                    {
                        return System.Array.CreateInstance(type, lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28], lengths[29], lengths[30], lengths[31]);
                    }
            }

            return null;
        }

        public object Get(List<int> lengths)
        {
            switch (dimensions)
            {
                case 1:
                    {
                        return array.GetValue(lengths[0]);
                    }

                case 2:
                    {
                        return array.GetValue(lengths[0], lengths[1]);
                    }

                case 3:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2]);
                    }

                case 4:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3]);
                    }

                case 5:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4]);
                    }

                case 6:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5]);
                    }

                case 7:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6]);
                    }

                case 8:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7]);
                    }

                case 9:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8]);
                    }

                case 10:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9]);
                    }

                case 11:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10]);
                    }

                case 12:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11]);
                    }

                case 13:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12]);
                    }

                case 14:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13]);
                    }

                case 15:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14]);
                    }

                case 16:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15]);
                    }

                case 17:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16]);
                    }

                case 18:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17]);
                    }

                case 19:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18]);
                    }

                case 20:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19]);
                    }

                case 21:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20]);
                    }

                case 22:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21]);
                    }

                case 23:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22]);
                    }

                case 24:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23]);
                    }

                case 25:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24]);
                    }

                case 26:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25]);
                    }

                case 27:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26]);
                    }

                case 28:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27]);
                    }

                case 29:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28]);
                    }

                case 30:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28], lengths[29]);
                    }

                case 31:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28], lengths[29], lengths[30]);
                    }

                case 32:
                    {
                        return array.GetValue(lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28], lengths[29], lengths[30], lengths[31]);
                    }
            }

            return null;
        }

        public void Set(object value, List<int> lengths)
        {
            switch (dimensions)
            {
                case 1:
                    {
                        array.SetValue(value, new int[] { lengths[0] });
                        break;
                    }

                case 2:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1] });
                        break;
                    }

                case 3:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2] });
                        break;
                    }

                case 4:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3] });
                        break;
                    }

                case 5:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4] });
                        break;
                    }

                case 6:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5] });
                        break;
                    }

                case 7:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6] });
                        break;
                    }

                case 8:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7] });
                        break;
                    }

                case 9:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8] });
                        break;
                    }

                case 10:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9] });
                        break;
                    }

                case 11:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10] });
                        break;
                    }

                case 12:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11] });
                        break;
                    }

                case 13:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12] });
                        break;
                    }

                case 14:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13] });
                        break;
                    }

                case 15:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14] });
                        break;
                    }

                case 16:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15] });
                        break;
                    }

                case 17:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16] });
                        break;
                    }

                case 18:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17] });
                        break;
                    }

                case 19:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18] });
                        break;
                    }

                case 20:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19] });
                        break;
                    }

                case 21:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20] });
                        break;
                    }

                case 22:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21] });
                        break;
                    }

                case 23:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22] });
                        break;
                    }

                case 24:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23] });
                        break;
                    }

                case 25:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24] });
                        break;
                    }

                case 26:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25] });
                        break;
                    }

                case 27:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26] });
                        break;
                    }

                case 28:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27] });
                        break;
                    }

                case 29:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28] });
                        break;
                    }

                case 30:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28], lengths[29] });
                        break;
                    }

                case 31:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28], lengths[29], lengths[30] });
                        break;
                    }

                case 32:
                    {
                        array.SetValue(value, new int[] { lengths[0], lengths[1], lengths[2], lengths[3], lengths[4], lengths[5], lengths[6], lengths[7], lengths[8], lengths[9], lengths[10], lengths[11], lengths[12], lengths[13], lengths[14], lengths[15], lengths[16], lengths[17], lengths[18], lengths[19], lengths[20], lengths[21], lengths[22], lengths[23], lengths[24], lengths[25], lengths[26], lengths[27], lengths[28], lengths[29], lengths[30], lengths[31] });
                        break;
                    }
            }
        }
    }
}
