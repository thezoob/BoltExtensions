using Bolt;
using Ludiq;
using UnityEditor;
using UnityEngine;

namespace Lasm.BoltExtensions
{
    [Descriptor(typeof(ValueReroute))]
    public sealed class RerouteDescriptor : UnitDescriptor<ValueReroute>
    {
        private static Texture2D icon;

        public RerouteDescriptor(ValueReroute target) : base(target)
        {
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
            
            description.showLabel = false;
        }

        protected override EditorTexture DefaultIcon()
        {
            if (icon == null) icon = AssetDatabase.LoadAssetAtPath<Texture2D>(RootPathFinder.rootPath + "Bolt/Utilities/Editor/Resources/ValueReroute@32x.png");
            return EditorTexture.Single(icon); 
        }

        protected override EditorTexture DefinedIcon()
        {
            if (icon == null) icon = AssetDatabase.LoadAssetAtPath<Texture2D>(RootPathFinder.rootPath + "Bolt/Utilities/Editor/Resources/ValueReroute@32x.png");
            return EditorTexture.Single(icon);
        }
    }
} 