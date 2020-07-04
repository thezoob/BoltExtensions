using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Lasm.BoltExtensions.Humility
{
    /// <summary>
    /// Binds itself to a type. Allows for easy lookup of a type, based on an objects instance.
    /// Perfect for creating plugins and modules where the implementation (the decorated type) is seperate from the decorator type.
    /// </summary>
    /// <typeparam name="TDecorator"></typeparam>
    /// <typeparam name="TDecoratorAttribute"></typeparam>
    /// <typeparam name="TDecoratedType"></typeparam>
    [Serializable]
    public abstract class Decorator<TDecorator, TDecoratorAttribute, TDecoratedType>
        where TDecoratorAttribute : DecoratorAttribute
        where TDecorator : Decorator<TDecorator, TDecoratorAttribute, TDecoratedType>
    {
        private static Dictionary<Type, Type> decoratorTypes;
        private static Dictionary<TDecoratedType, TDecorator> decorators = new Dictionary<TDecoratedType, TDecorator>();
        public static TDecorator activeDecorator; /// <summary> The current active editor. </summary>
        public static TDecoratedType activeDecorated; /// <summary> The current active editor. </summary>
        [SerializeField] public TDecoratedType decorated; 

        /// <summary>
        /// Find a decorator based on its type.
        /// </summary>
        /// <param name="decorated"></param>
        /// <returns></returns>
        public static TDecorator GetDecorator(TDecoratedType decorated)
        {
            if (decorated == null) return null;
            var decorator = GetDecoratorFromDecorated(decorated);
            if (decorator.decorated == null) decorator.decorated = decorated;

            return decorator;
        }

        private static Type GetDecoratorType(Type decoratedType)
        {
            if (decoratedType == null) return null;

            if (decoratorTypes == null) CacheDecorators();

            Type result = null;

            if (decoratorTypes.TryGetValue(decoratedType, out result)) return result;

            return GetDecoratorType(decoratedType.BaseType);
        }

        private static TDecorator GetDecoratorFromDecorated(TDecoratedType decorated)
        {
            var hasDecorator = decorators.ContainsKey(decorated);

            if (!hasDecorator)
            {
                Type type = decorated.GetType();
                Type decoratorType = GetDecoratorType(type);
                var decorator = (TDecorator)Activator.CreateInstance(decoratorType);
                decorator.decorated = decorated;
                activeDecorator = decorator;
                activeDecorated = decorated;
                decorators.Add(decorated, decorator);
                return decorator;
            }

            return decorators[decorated];
        }

        private static void CacheDecorators()
        {
            decoratorTypes = new Dictionary<Type, Type>();

            Type[] decorators = typeof(TDecorator).Get().Derived();

            for (int i = 0; i < decorators.Length; i++)
            {
                if (decorators[i].IsAbstract) continue;
                var attribs = decorators[i].GetCustomAttributes(typeof(TDecoratorAttribute), false);
                if (attribs == null || attribs.Length == 0) continue;
                TDecoratorAttribute attrib = attribs[0] as TDecoratorAttribute;
                decoratorTypes.Add(attrib.type, decorators[i]);
            }
        }
    }
}
