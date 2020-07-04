using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Lasm.BoltExtensions.Humility
{
    public static partial class HUMType_Children
    {
        /// <summary>
        /// Begins a type filtering operation.
        /// </summary>
        public static HUMType.Data.With With(this HUMType.Data.Types types)
        {
            return new HUMType.Data.With(types);
        }

        /// <summary>
        /// Converts a type to its actual declared csharp name. Custom types return the type name. Example 'System.Int32' becomes 'int'.
        /// </summary>
        public static string CSharpName(this HUMType.Data.As @as, bool hideSystemObject = false, bool fullName = false)
        {
            if (@as.type == null) return "null";
            if (@as.type == typeof(int)) return "int";
            if (@as.type == typeof(string)) return "string";
            if (@as.type == typeof(float)) return "float";
            if (@as.type == typeof(void)) return "void";
            if (@as.type == typeof(double)) return "double";
            if (@as.type == typeof(bool)) return "bool";
            if (@as.type == typeof(byte)) return "byte";
            if (@as.type == typeof(System.Object) && @as.type.BaseType == null) return hideSystemObject ? string.Empty : "object";

            return fullName ? @as.type.FullName : @as.type.Name;
        }

        /// <summary>
        /// Converts a string that was retrieved via type.Name to its actual declared csharp name. Custom types return the type name. Example 'Int32' becomes 'int'.
        /// </summary>
        public static string CSharpName(this HUMString.Data.As asData, bool hideSystemObject = false)
        {
            if (string.IsNullOrEmpty(asData.text) || string.IsNullOrWhiteSpace(asData.text)) return "null";
            if (asData.text == "Int32") return "int";
            if (asData.text == "String") return "string";
            if (asData.text == "Float") return "float";
            if (asData.text == "Void") return "void";
            if (asData.text == "Double") return "double";
            if (asData.text == "Bool" || asData.text == "Boolean") return "bool";
            if (asData.text == "Byte") return "byte";
            if (asData.text == "Object") return hideSystemObject ? string.Empty : "object";
            return asData.text;
        }

        /// <summary>
        /// Returns true if a type is equal to another type.
        /// </summary>
        public static bool Type<T>(this HUMType.Data.Is isData)
        {
            return isData.type == typeof(T);
        }

        /// <summary>
        /// Returns true if a type is equal to another type.
        /// </summary>
        public static bool Type(this HUMType.Data.Is isData, Type type)
        {
            return isData.type == type;
        }

        /// <summary>
        /// Returns true if the type is a void.
        /// </summary>
        public static bool Void(this HUMType.Data.Is isData)
        {
            return isData.type == typeof(void);
        }

        /// <summary>
        /// Returns true if the type is a enumerator collection type.
        /// </summary>
        public static bool Enumerator(this HUMType.Data.Is isData)
        {
            if (isData.type == typeof(IEnumerator) || isData.type == typeof(IEnumerable) || isData.type == typeof(IEnumerator<>) || isData.type == typeof(IEnumerable<>))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns true if the type contains a field or method this or returns an Enumerator
        /// </summary>
        public static bool Enumerator(this HUMType.Data.Has hasData, bool fields = true, bool methods = true)
        {
            return hasData.type.HasFieldOrMethodOfType<IEnumerator>(fields, methods);
        }

        /// <summary>
        /// Returns true if the enumerator includes a generic argument.
        /// </summary>
        public static bool Enumerator(this HUMType.Data.Generic genericData)
        {
            var interfaces = genericData.isData.type.GetInterfaces();

            for (int i = 0; i < interfaces.Length; i++)
            {
                if (interfaces[i].IsGenericType && interfaces[i].GetGenericTypeDefinition() == typeof(IEnumerator<>))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns true if an enumerable includes a generic argument.
        /// </summary>
        public static bool Enumerable(this HUMType.Data.Generic genericData)
        {
            var interfaces = genericData.isData.type.GetInterfaces();

            for (int i = 0; i < interfaces.Length; i++)
            {
                if (interfaces[i].IsGenericType && interfaces[i].GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns true if the type is an enumerable collection type.
        /// </summary>
        public static bool Enumerable(this HUMType.Data.Is isData)
        {
            return isData.type.Inherits(typeof(IEnumerator)) || isData.type.Inherits(typeof(IEnumerable)) || isData.type.Is().Generic().Enumerator() || isData.Enumerator();
        }

        /// <summary>
        /// Returns true if the type has a field or method of this a type.
        /// </summary>
        public static bool Enumerable(this HUMType.Data.Has has, bool fields = true, bool methods = true)
        {
            return has.type.HasFieldOrMethodOfType<IEnumerable>(fields, methods);
        }

        /// <summary>
        /// Returns true if the type is a Coroutine.
        /// </summary>
        public static bool Coroutine(this HUMType.Data.Is isData)
        {
            if (isData.type == typeof(IEnumerator) && isData.type != typeof(IEnumerable) && isData.type != typeof(IEnumerator<>) && isData.type != typeof(IEnumerable<>))
            {
                return true;
            }

            return isData.type == typeof(Coroutine) || isData.type == typeof(YieldInstruction) || isData.type == typeof(CustomYieldInstruction);
        }

        /// <summary>
        /// Finds all types with this attribute.
        /// </summary>
        public static Type[] Attribute<TAttribute>(this HUMType.Data.With with) where TAttribute : Attribute
        {
            List<Type> result = new List<Type>();
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            for (int assembly = 0; assembly < assemblies.Length; assembly++)
            {
                Type[] types = assemblies[assembly].GetTypes();

                for (int type = 0; type < types.Length; type++)
                {
                    if (with.types.get.type.IsAssignableFrom(types[type]))
                    {
                        if (types[type].IsAbstract) continue;
                        var attribs = types[type].GetCustomAttributes(typeof(TAttribute), false);
                        if (attribs == null || attribs.Length == 0) continue;
                        TAttribute attrib = attribs[0] as TAttribute;
                        attrib.Is().NotNull(() => { result.Add(types[type]); });
                    }
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Starts an operation where we determing if a type is a generic of some kind.
        /// </summary>
        public static HUMType.Data.Generic Generic(this HUMType.Data.Is isData)
        {
            return new HUMType.Data.Generic(isData);
        }

        /// <summary>
        /// Returns all types that derive or have a base type of a this type.
        /// </summary>
        public static Type[] Derived(this HUMType.Data.Get derived)
        {
            List<Type> result = new List<Type>();
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            for (int assembly = 0; assembly < assemblies.Length; assembly++)
            {
                Type[] types = assemblies[assembly].GetTypes();

                for (int type = 0; type < types.Length; type++)
                {
                    if (!types[type].IsAbstract && derived.type.IsAssignableFrom(types[type]))
                    {
                        result.Add(types[type]);
                    }
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Continues the get operation by getting types of some kind.
        /// </summary>
        public static HUMType.Data.Types Types(this HUMType.Data.Get get)
        {
            return new HUMType.Data.Types(get);
        }
    }
}