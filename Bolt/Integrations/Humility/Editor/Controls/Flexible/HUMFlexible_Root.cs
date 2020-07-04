#if UNITY_EDITOR
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEditor;

namespace Lasm.BoltExtensions.Humility
{
    public static partial class HUMEditor
    {
        public static Data.Flexible Draw()
        {
            return new Data.Flexible();
        }

        public static void Horizontal(Action action, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginHorizontal(options);
            action();
            EditorGUILayout.EndHorizontal();
        }

        public static Data.Horizontal Horizontal()
        {
            return new Data.Horizontal();
        }

        public static void Horizontal(GUIStyle style, Action action, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginHorizontal(style, options);
            action();
            EditorGUILayout.EndHorizontal();
        }

        public static void Vertical(Action action, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginVertical(options);
            action();
            EditorGUILayout.EndVertical();
        }

        public static void Vertical(GUIStyle style, Action action, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginVertical(style, options);
            action();
            EditorGUILayout.EndVertical();
        }
    }
}
#endif