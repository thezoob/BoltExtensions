using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// The descriptor that sets the icon for Get Array Item.
    /// </summary>
    [Descriptor(typeof(GetArrayItem))]
    public class GetArrayItemDescriptor : UnitDescriptor<GetArrayItem>
    {
        public static Texture2D icon;

        public GetArrayItemDescriptor(GetArrayItem unit) : base(unit)
        {

        }

        protected override EditorTexture DefaultIcon()
        {
            if (icon == null) icon = AssetDatabase.LoadAssetAtPath<Texture2D>(RootPathFinder.rootPath + "Bolt/MultiArray/Editor/Resources/Lasm.BoltExtensions.GetArrayItem@32x.png");
            return EditorTexture.Single(icon);
        }

        protected override EditorTexture DefinedIcon()
        {
            if (icon == null) icon = AssetDatabase.LoadAssetAtPath<Texture2D>(RootPathFinder.rootPath + "Bolt/MultiArray/Editor/Resources/Lasm.BoltExtensions.GetArrayItem@32x.png");
            return EditorTexture.Single(icon);
        }
    }
}