using System;

namespace Lasm.BoltExtensions.Humility {
    public static partial class HUMString
    {
        public static Data.Remove Remove(this string text, string remove)
        {
            return new Data.Remove(text, remove);
        }

        /// <summary>
        /// Begins adding something into text.
        /// </summary>
        public static Data.Add Add(this string text)
        {
            return new Data.Add(text);
        }

        /// <summary>
        /// Begins an operation that capitalizes some text.
        /// </summary>
        public static Data.Capitalize Captialize(this string text)
        {
            return new Data.Capitalize(text);
        }
    }
}
