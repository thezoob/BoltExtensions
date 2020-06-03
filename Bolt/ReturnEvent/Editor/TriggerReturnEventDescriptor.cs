using UnityEngine;
using Ludiq;
using Bolt;
using UnityEditor;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// A descriptor that assigns the TriggerReturnEvent icon.
    /// </summary>
    [Descriptor(typeof(TriggerReturnEvent))]
    public sealed class TriggerReturnEventDescriptor : UnitDescriptor<TriggerReturnEvent>
    {
        public TriggerReturnEventDescriptor(TriggerReturnEvent target) : base(target)
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