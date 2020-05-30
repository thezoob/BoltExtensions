using UnityEngine;
using UnityEditor;
using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions
{
    [Descriptor(typeof(SetArrayItem))]
    public class SetArrayItemDescriptor : UnitDescriptor<SetArrayItem>
    {
        public static Texture2D icon;

        public SetArrayItemDescriptor(SetArrayItem unit) : base(unit)
        {

        }

        protected override EditorTexture DefaultIcon()
        {
            if (icon == null) icon = AssetDatabase.LoadAssetAtPath<Texture2D>(RootPathFinder.rootPath + "Bolt/MultiArray/Editor/Resources/Lasm.BoltExtensions.GetArrayItem@32x.png");

            return EditorTexture.Single(GetArrayItemDescriptor.icon);
        }

        protected override EditorTexture DefinedIcon()
        {
            if (icon == null) icon = AssetDatabase.LoadAssetAtPath<Texture2D>(RootPathFinder.rootPath + "Bolt/MultiArray/Editor/Resources/Lasm.BoltExtensions.GetArrayItem@32x.png");

            return EditorTexture.Single(GetArrayItemDescriptor.icon);
        }
    }
}