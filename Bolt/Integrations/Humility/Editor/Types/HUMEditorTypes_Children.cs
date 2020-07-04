using System;
using System.Collections;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Lasm.BoltExtensions.Humility
{
    public static partial class HUMEditorTypes_Children
    {
        /// <summary>
        /// Starts the process of getting a window of some kind.
        /// </summary>
        public static HUMEditorTypes.Data.Window Window(this HUMEditorTypes.Data.Get get, EditorWindow window)
        {
            return new HUMEditorTypes.Data.Window(get, window);
        }

        /// <summary>
        /// Finds a field within an editor window via reflection.
        /// </summary>
        public static FieldInfo Field(this HUMEditorTypes.Data.Window window, string name)
        {
            return window.window.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }

        /// <summary>
        /// Gets the value of a field via reflection.
        /// </summary>
        public static object FieldValue(this HUMEditorTypes.Data.Window window, string name)
        {
            return window.window.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(window.window);
        }

        /// <summary>
        /// Gets te value of a field via reflection.
        /// </summary>
        public static T FieldValue<T>(this HUMEditorTypes.Data.Window window, string name)
        {
            return (T)window.window.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(window.window);
        }

        /// <summary>
        /// Gets a field on any object via reflection.
        /// </summary>
        public static FieldInfo Field(this object obj, string name)
        {
            return obj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }

        /// <summary>
        /// Gets a fields value on any object via reflection.
        /// </summary>
        public static object FieldValue(this object obj, string name)
        {
            return obj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(obj);
        }

        /// <summary>
        /// Gets a fields value on any object via reflection.
        /// </summary>
        public static T FieldValue<T>(this object obj, string name)
        {
            return (T)obj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(obj);
        }

        /// <summary>
        /// Gets a field on a host view window via reflection.
        /// </summary>
        public static FieldInfo Field(this HUMEditorTypes.Data.GetHostView hostView, string name)
        {
            return hostView.window.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }

        /// <summary>
        /// Gets a field on a host view window via reflection.
        /// </summary>
        public static object FieldValue(this HUMEditorTypes.Data.GetHostView hostView, string name)
        {
            return hostView.window.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(hostView.window);
        }

        /// <summary>
        /// Gets a field on a host view window via reflection.
        /// </summary>
        public static T FieldValue<T>(this HUMEditorTypes.Data.GetHostView window, string name)
        {
            return (T)window.window.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(window.window);
        }

        /// <summary>
        /// Gets a property on a window via reflection.
        /// </summary>
        public static PropertyInfo Property(this HUMEditorTypes.Data.Window window, string name)
        {
            return window.window.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }

        /// <summary>
        /// Gets a property on a window via reflection.
        /// </summary>
        public static object PropertyValue(this HUMEditorTypes.Data.Window window, string name)
        {
            return window.window.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(window.window);
        }

        /// <summary>
        /// Gets a properties value on a window via reflection.
        /// </summary>
        public static T PropertyValue<T>(this HUMEditorTypes.Data.Window window, string name)
        {
            return (T)window.window.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(window.window);
        }

        /// <summary>
        /// Gets a property on any object via reflection.
        /// </summary>
        public static PropertyInfo Property(this object obj, string name)
        {
            return obj.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }

        /// <summary>
        /// Gets a properties value on any object via reflection.
        /// </summary>
        public static object PropertyValue(this object obj, string name)
        {
            return obj.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(obj);
        }

        /// <summary>
        /// Gets a properties value on any object via reflection.
        /// </summary>
        public static T PropertyValue<T>(this object obj, string name)
        {
            return (T)obj.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(obj);
        }

        /// <summary>
        /// Gets a property on a host view window via reflection.
        /// </summary>
        public static PropertyInfo Property(this HUMEditorTypes.Data.GetHostView hostView, string name)
        {
            return hostView.window.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }

        /// <summary>
        /// Gets a properties value on a host view window via reflection.
        /// </summary>
        public static object PropertyValue(this HUMEditorTypes.Data.GetHostView hostView, string name)
        {
            return hostView.window.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(hostView.window);
        }

        /// <summary>
        /// Gets a properties value on a host view window via reflection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hostView"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T PropertyValue<T>(this HUMEditorTypes.Data.GetHostView hostView, string name)
        {
            return (T)hostView.window.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(hostView.window);
        }

        /// <summary>
        /// Gets the host view of this window.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        public static object HostView(this HUMEditorTypes.Data.Window window)
        {
            return FieldValue(window, "m_Parent");
        }

        /// <summary>
        /// Starts the process of getting a host view from a window and doing something with it.
        /// </summary>
        public static HUMEditorTypes.Data.GetHostView HostView(this HUMEditorTypes.Data.Get get, EditorWindow window)
        {
            return new HUMEditorTypes.Data.GetHostView(get, window);
        }

        /// <summary>
        /// The inner view of the window. For instance, inside tab window, its below the tab area.
        /// </summary>
        public static object ActualView(this HUMEditorTypes.Data.GetHostView hostView)
        {
            return PropertyValue(hostView, "m_ActualView");
        }

        /// <summary>
        /// Starts the process of getting the main window and doing something.
        /// </summary>
        /// <param name="get"></param>
        /// <returns></returns>
        public static HUMEditorTypes.Data.GetMain Main(this HUMEditorTypes.Data.Get get)
        {
            return new HUMEditorTypes.Data.GetMain(get);
        }

        private static object _mainToolbar;

        private static object GetMainToolbar()
        {
            var type = Assembly.GetAssembly(typeof(EditorWindow)).GetType("UnityEditor.MainView", true, false);
            var instance = Resources.FindObjectsOfTypeAll(type)[0];
            var children = (IEnumerable)type.GetProperty("children").GetValue(instance);
            var childrenEnumerator = children.GetEnumerator();
            childrenEnumerator.MoveNext();
            return childrenEnumerator.Current;
        }

        public static object Toolbar(this HUMEditorTypes.Data.GetMain main)
        {
            if (_mainToolbar == null) _mainToolbar = GetMainToolbar();
            return _mainToolbar;
        }

        private static object _mainStatusBar;

        private static object GetMainStatusBar()
        {
            var type = Assembly.GetAssembly(typeof(EditorWindow)).GetType("UnityEditor.MainView", true, false);
            var instance = Resources.FindObjectsOfTypeAll(type)[0];
            var children = (IEnumerable)type.GetProperty("children").GetValue(instance);
            var childrenEnumerator = children.GetEnumerator();
            childrenEnumerator.MoveNext();
            childrenEnumerator.MoveNext();
            childrenEnumerator.MoveNext();
            return childrenEnumerator.Current;
        }

        /// <summary>
        /// Gets an editor type via reflection.
        /// </summary>
        public static Type EditorType(this HUMEditorTypes.Data.Get get, string typeFullName)
        {
            return Assembly.GetAssembly(typeof(EditorWindow)).GetType(typeFullName, true, false);
        }

        public static object StatusBar(this HUMEditorTypes.Data.GetMain main)
        {
            if (_mainStatusBar == null) _mainStatusBar = GetMainStatusBar();
            return _mainStatusBar;
        }

        private static object _mainDockArea;

        private static object GetMainDockArea()
        {
            var type = Assembly.GetAssembly(typeof(EditorWindow)).GetType("UnityEditor.MainView", true, false);
            var instance = Resources.FindObjectsOfTypeAll(type)[0];
            var children = (IEnumerable)type.GetProperty("children").GetValue(instance);
            var childrenEnumerator = children.GetEnumerator();
            childrenEnumerator.MoveNext();
            childrenEnumerator.MoveNext();
            return childrenEnumerator.Current;
        }

        public static object DockArea(this HUMEditorTypes.Data.GetMain main)
        {
            if (_mainDockArea == null) _mainDockArea = GetMainDockArea();
            return _mainDockArea;
        }
    }
}
