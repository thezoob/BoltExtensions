using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Lasm.BoltExtensions
{
    public class MultiArrayDimensionsWindow : EditorWindow
    {
        private MultiArray multiArray;

        public static void Open(MultiArray multiArray, Rect position)
        {
            var window = CreateInstance<MultiArrayDimensionsWindow>();
            window.position = position;
            window.multiArray = multiArray;
            window.ShowPopup();
        }

        private void OnGUI()
        {
            var height = (multiArray.lengths.Count * 20) + 20;
            var pos = new Rect();
            pos.height = 18;
            pos.x = 8;
            pos.width = position.width - 16;
            pos.y = 10;

            EditorGUI.DrawRect(new Rect(0,0, position.width, position.height), Color.black);
            EditorGUI.DrawRect(new Rect(2,2, position.width - 4, position.height - 4), new Color(0.475f, 0.475f, 0.475f));

            for (int i = 0; i < multiArray.lengths.Count; i++)
            {
                multiArray.lengths[i] = EditorGUI.IntField(pos, "Dimension " + i.ToString(), Mathf.Clamp(multiArray.lengths[i], 1, 32));
                pos.y += 20;
            }
        }

        private void OnLostFocus()
        {
            Close();
        }
    }
}