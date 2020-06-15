using Ludiq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Lasm.BoltExtensions
{
    [Inspector(typeof(MultiArray))]
    [Serializable]
    public class MultiArrayInspector : Inspector
    {
        private Metadata type => metadata["type"];
        private Metadata dimensions => metadata["dimensions"];
        private Metadata lengths => metadata["lengths"];
        private Metadata array => metadata["array"];
        private Metadata lastDimensions => metadata["lastDimensions"];
        private Metadata lastType => metadata["lastType"];

        public MultiArrayInspector(Metadata metadata) : base(metadata)
        {
        }

        protected override float GetHeight(float width, GUIContent label)
        {
            return 100f;
        }

        protected override void OnGUI(Rect position, GUIContent label)
        {
            if (metadata != null && metadata.value != null)
            {
                BeginBlock(metadata, position, GUIContent.none);

                var multiArray = metadata.value as MultiArray;

                var typeRect = position;
                typeRect.height = 18;

                LudiqGUI.Inspector(type, typeRect);

                var dimensionsLabelRect = typeRect;
                dimensionsLabelRect.y += 20;
                dimensionsLabelRect.width = GUI.skin.label.CalcSize(new GUIContent("Dimensions")).x;

                var dimensionsRect = typeRect;
                dimensionsRect.y += 20;
                dimensionsRect.x += dimensionsLabelRect.width + 4;
                dimensionsRect.width -= dimensionsLabelRect.width + 4;

                dimensions.value = Mathf.Clamp((int)dimensions.value, 1, 32);

                GUI.Label(dimensionsLabelRect, "Dimensions");
                LudiqGUI.Inspector(dimensions, dimensionsRect, GUIContent.none);

                SetArray();

                var capacityRect = Capacity(typeRect, dimensionsRect, position, multiArray);

                var editValueRect = capacityRect;
                editValueRect.y += 28;
                editValueRect.height += 12;

                EditorGUI.HelpBox(editValueRect, "At this time values cannot be modified in the inspector.", MessageType.Warning);
                
                EndBlock(metadata);
            }
            else
            {
                metadata.value = new MultiArray();
            }
        }

        private Rect Capacity(Rect typeRect, Rect dimensionsRect, Rect position, MultiArray multiArray)
        {
            var lengthsButtonRect = typeRect;
            lengthsButtonRect.y += dimensionsRect.height + typeRect.height + 4;

            var lengthsText = string.Empty;
            var listOfLengths = ((List<int>)lengths.value);
            var count = listOfLengths.Count;

            for (int i = 0; i < count; i++)
            {
                lengthsText += listOfLengths[i].ToString();
                if (i < count - 1)
                {
                    lengthsText += ", ";
                }
            }

            if (GUI.Button(lengthsButtonRect, "Capacity (" + lengthsText + ")"))
            {
                var winPos = new Rect();
                winPos.x = position.x;
                winPos.height = Mathf.Clamp(20 + (multiArray.dimensions * 20), 40, 350);
                winPos.y = lengthsButtonRect.y - winPos.height;
                winPos.width = position.width;

                MultiArrayDimensionsWindow.Open(metadata.value as MultiArray, EditorGUIUtility.GUIToScreenRect(winPos));
            }

            return lengthsButtonRect;
        }

        private void SetArray()
        {
            var lastDimension = (int)lastDimensions.value;
            var value = (int)dimensions.value;
            
            if (value != lastDimension || value != ((Array)array.value).Rank)
            {
                for (int i = ((List<int>)lengths.value).Count - 1; i > value-1; i--)
                {
                    ((List<int>)lengths.value).RemoveAt(i);
                }

                for (int i = ((List<int>)lengths.value).Count; i < value; i++)
                {
                    ((List<int>)lengths.value).Add(1);
                }

                lastDimensions.value = (int)dimensions.value;
                ((MultiArray)metadata.value).array = ((MultiArray)metadata.value).Create();
            }
        }

        private void SetType()
        {
            var _lastType = (Type)lastType.value;
            var value = (Type)type.value;
             
            if (value != _lastType)
            {
                lastType.value = (Type)type.value;
                array.value = ((MultiArray)metadata.value).Create();
            }
        }
    }
}