using UnityEngine.UIElements;

namespace Lasm.BoltExtensions.Humility
{
    public static partial class HUMRetained
    {
        public static partial class Data
        {
            public struct Set
            {
                public VisualElement element;

                public Set(VisualElement element)
                {
                    this.element = element;
                }
            }
        }
    }
}
