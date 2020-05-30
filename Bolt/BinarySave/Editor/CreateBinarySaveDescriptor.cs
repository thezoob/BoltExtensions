using Ludiq;
using Bolt;

namespace Lasm.BoltExtensions.IO
{
    [Descriptor(typeof(CreateBinarySave))]
    public class CreateBinarySaveDescriptor : BinarySaveUnitDescriptor
    {
        public CreateBinarySaveDescriptor(CreateBinarySave target) : base(target)
        {
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);

            for (int i = 0; i < ((CreateBinarySave)target).count; i++)
            {
                if (port.key == "name_" + i.ToString()) description.showLabel = false;
                if (port.key == "value_" + i.ToString()) description.label = "Value";
            }
        }
    }
}