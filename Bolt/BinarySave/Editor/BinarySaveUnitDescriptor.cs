using Ludiq;
using Bolt;
using UnityEngine;
using UnityEditor;

namespace Lasm.BoltExtensions.IO
{
    [Descriptor(typeof(BinarySaveUnit))]
    public class BinarySaveUnitDescriptor : UnitDescriptor<BinarySaveUnit>
    {
        private static Texture2D _icon;
        public static Texture2D icon
        {
            get
            {
                if (_icon == null)
                {
                    _icon = (Texture2D)AssetDatabase.LoadAssetAtPath(RootPathFinder.rootPath + "Bolt/Editor/Resources/Icons/Lasm.BoltAddons.IO.BinarySave@32x.png", typeof(Texture2D));
                }

                return _icon;
            }

            set { _icon = value; }
        }

        public BinarySaveUnitDescriptor(BinarySaveUnit target) : base(target)
        {
        }

        protected override EditorTexture DefinedIcon()
        {
            return EditorTexture.Single(icon);
        }

        protected override EditorTexture DefaultIcon()
        {
            return EditorTexture.Single(icon);
        }
    }
}