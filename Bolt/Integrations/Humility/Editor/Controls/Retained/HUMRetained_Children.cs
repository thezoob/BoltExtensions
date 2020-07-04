using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Lasm.BoltExtensions.Humility
{
    public static partial class HUMRetained_Children
    {
        /// <summary>
        /// Sets the border thickness of the element equally on all sides.
        /// </summary>
        public static VisualElement Border(this HUMRetained.Data.Set set, int amount)
        {
            set.element.style.borderBottomWidth = amount;
            set.element.style.borderTopWidth = amount;
            set.element.style.borderLeftWidth = amount;
            set.element.style.borderRightWidth = amount;
            return set.element;
        }

        /// <summary>
        /// Sets the border radius of the element equally on all corners.
        /// </summary>
        public static VisualElement Radius(this HUMRetained.Data.Set set, int amount)
        {
            set.element.style.borderBottomLeftRadius = amount;
            set.element.style.borderBottomRightRadius = amount;
            set.element.style.borderTopLeftRadius = amount;
            set.element.style.borderTopRightRadius = amount;
            return set.element;
        }

        /// <summary>
        /// Pads the element equally on all sides.
        /// </summary>
        public static VisualElement Padding(this HUMRetained.Data.Set set, int amount)
        {
            set.element.style.paddingBottom = amount;
            set.element.style.paddingTop = amount;
            set.element.style.paddingLeft = amount;
            set.element.style.paddingRight = amount;
            return set.element;
        }

        /// <summary>
        /// Sets the margin of the element equally on all sides.
        /// </summary>
        public static VisualElement Margin(this HUMRetained.Data.Set set, int amount)
        {
            set.element.style.marginBottom = amount;
            set.element.style.marginTop = amount;
            set.element.style.marginLeft = amount;
            set.element.style.marginRight = amount;
            return set.element;
        }

        /// <summary>
        /// Sets the slice of the element equally on all sides.
        /// </summary>
        public static VisualElement Slice(this HUMRetained.Data.Set set, int amount)
        {
            set.element.style.unitySliceBottom = amount;
            set.element.style.unitySliceTop = amount;
            set.element.style.unitySliceLeft = amount;
            set.element.style.unitySliceRight = amount;
            return set.element;
        }

        /// <summary>
        /// Sets the border thickness of the element equally on all sides.
        /// </summary>
        public static VisualElement BorderColor(this HUMRetained.Data.Set set, Color color)
        {
            set.element.style.borderBottomColor = color;
            set.element.style.borderTopColor = color;
            set.element.style.borderLeftColor = color;
            set.element.style.borderRightColor = color;
            return set.element;
        }
    }
}
