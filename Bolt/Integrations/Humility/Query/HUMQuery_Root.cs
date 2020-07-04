using System.Collections.Generic;

namespace Lasm.BoltExtensions.Humility
{
    public static partial class HUMQuery
    {
        /// <summary>
        /// Performs a for loop with an action.
        /// </summary>
        public static Data.For<T> For<T>(this IList<T> collection, System.Action<IList<T>, int> action)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                action(collection, i);
            }

            return new Data.For<T>(collection);
        }

        /// <summary>
        /// Begins a for operation on a collection.
        /// </summary>
        public static Data.For<T> For<T>(this IList<T> collection)
        {
            return new Data.For<T>(collection);
        }
    }
}