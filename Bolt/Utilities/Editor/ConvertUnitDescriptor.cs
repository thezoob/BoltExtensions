using Bolt;
using Ludiq;
using UnityEngine;

namespace Lasm.BoltExtensions
{
    [Descriptor(typeof(ConvertUnit))]
    public class ConvertUnitDescriptor : UnitDescriptor<ConvertUnit>
    {
        private static Texture2D icon;

        public ConvertUnitDescriptor(ConvertUnit target) : base(target)
        {
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);

            description.showLabel = false;
        }
    }
} 