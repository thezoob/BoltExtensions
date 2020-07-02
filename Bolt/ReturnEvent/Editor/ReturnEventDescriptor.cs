using UnityEngine;
using Ludiq;
using Bolt;
using UnityEditor;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// A descriptor that assigns the ReturnEvents icon.
    /// </summary>
    [Descriptor(typeof(ReturnEvent))]
    public sealed class ReturnEventDescriptor : EventUnitDescriptor<ReturnEvent>
    {
        public static Texture2D icon;

        public ReturnEventDescriptor(ReturnEvent target) : base(target)
        {

        }

        protected override EditorTexture DefaultIcon()
        {
            if (ReturnEventDescriptor.icon == null) ReturnEventDescriptor.icon = AssetDatabase.LoadAssetAtPath<Texture2D>(RootPathFinder.rootPath + "Bolt/ReturnEvent/Editor/Resources/Lasm.BoltExtensions.ReturnEvent@32x.png");
            return EditorTexture.Single(ReturnEventDescriptor.icon);
        }

        protected override EditorTexture DefinedIcon()
        {
            if (ReturnEventDescriptor.icon == null) ReturnEventDescriptor.icon = AssetDatabase.LoadAssetAtPath<Texture2D>(RootPathFinder.rootPath + "Bolt/ReturnEvent/Editor/Resources/Lasm.BoltExtensions.ReturnEvent@32x.png");
            return EditorTexture.Single(ReturnEventDescriptor.icon);
        }
    }
}