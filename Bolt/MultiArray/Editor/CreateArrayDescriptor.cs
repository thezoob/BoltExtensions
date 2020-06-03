using UnityEngine;
using UnityEditor;
using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// The descriptor that sets the icon for CreateMultiArray.
    /// </summary>
    [Descriptor(typeof(CreateMultiArray))]
    [RenamedFrom("Lasm.BoltExtensions.CreateArrayDescriptor")]
    public class CreateMultiArrayDescriptor : UnitDescriptor<CreateMultiArray>
    {
        /// <summary>
        /// The icon for CreateMultiArray.
        /// </summary>
        public static Texture2D icon;

        public CreateMultiArrayDescriptor(CreateMultiArray unit) : base(unit)
        {

        }

        /// <summary>
        /// Sets the default icon of CreateMultiArray.
        /// </summary>
        protected override EditorTexture DefaultIcon()
        {
            if (icon == null) icon = AssetDatabase.LoadAssetAtPath<Texture2D>(RootPathFinder.rootPath + "Bolt/MultiArray/Editor/Resources/Lasm.BoltExtensions.GetArrayItem@32x.png");

            return EditorTexture.Single(icon);
        }

        /// <summary>
        /// Sets the defined icon of CreateMultiArray.
        /// </summary>
        protected override EditorTexture DefinedIcon()
        {
            if (icon == null) icon = AssetDatabase.LoadAssetAtPath<Texture2D>(RootPathFinder.rootPath + "Bolt/MultiArray/Editor/Resources/Lasm.BoltExtensions.GetArrayItem@32x.png");

            return EditorTexture.Single(icon);
        }
    }
}