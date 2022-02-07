using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using Helppad;

namespace Helppad.Linq
{
    /// <summary>
    /// The linq reflection extensions for <see cref="IEnumerable{Type}"/> and others methods.
    /// </summary>
    public static class LinqReflection
    {
        /// <summary>
        /// Return true if the tyoe has passed type interface.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        public static bool Implement(this Type type, Type interfaceType)
        {
            return type.GetInterfacesOf(interfaceType).Length > 0;
        }

        /// <summary>
        /// Return true if the tyoe has passed type interface.
        /// </summary>
        /// <typeparam name="TAbstraction"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Implement<TAbstraction>(this Type type)
        {
            return type.GetInterfacesOf(typeof(TAbstraction)).Length > 0;
        }

        /// <summary>
        /// Return true if the tyoe has passed type interface.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        public static Type[] GetInterfacesOf(this Type type, Type interfaceType)
        {
            return type.FindInterfaces((i, _) => i.GetGenericTypeDefinitionSafe() == interfaceType, null);
        }

        /// <summary>
        /// Get generic type defintion.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetGenericTypeDefinitionSafe(this Type type)
        {
            return type.IsGenericType
                ? type.GetGenericTypeDefinition()
                : type;
        }

        /// <summary>
        /// Make a generic type safe.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="typeArguments"></param>
        /// <returns></returns>
        public static Type MakeGenericTypeSafe(this Type type, params Type[] typeArguments)
        {
            return type.IsGenericType && !type.GenericTypeArguments.Any()
                ? type.MakeGenericType(typeArguments)
                : type;
        }

        /// <summary>
        /// Return true if the tyoe has the passed attributes instances.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attrs"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static bool AnyAttributeOf(this Type type, Type[] attrs, bool inherit = false)
        {
            foreach (var item in attrs)
            {
                if (type.IsDefined(item, inherit))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Return true if the tyoe has the passed attributes instances.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static bool AnyAttributeOf<T, T2>(this Type type, bool inherit = false)
        {
            return AnyAttributeOf(type, new[] { typeof(T), typeof(T2) }, inherit);
        }

        /// <summary>
        /// Return true if the tyoe has the passed attributes instances.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static bool AnyAttributeOf<T, T2, T3>(this Type type, bool inherit = false)
        {
            return AnyAttributeOf(type, new[] { typeof(T), typeof(T2), typeof(T3) }, inherit);
        }

        /// <summary>
        /// Return true if the tyoe has the passed attributes instances.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static bool AnyAttributeOf<T, T2, T3, T4>(this Type type, bool inherit = false)
        {
            return AnyAttributeOf(type, new[] { typeof(T), typeof(T2), typeof(T3), typeof(T4) }, inherit);
        }

        /// <summary>
        /// Filter by attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static IEnumerable<Type> WithAttribute<T>(this IEnumerable<Type> enumerable, bool inherit = false)
        {
            return enumerable.Where(t => t.IsDefined(typeof(T), inherit));
        }

        /// <summary>
        /// Filter by attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<Type> WithAnyAttributes<T, T2>(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.AnyAttributeOf<T, T2>());
        }
        /// <summary>
        /// Filter by attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<Type> WithAnyAttributes<T, T2, T3>(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.AnyAttributeOf<T, T2, T3>());
        }

        /// <summary>
        /// Filter by attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<Type> WithAnyAttributes<T, T2, T3, T4>(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.AnyAttributeOf<T, T2, T3, T4>());
        }

        /// <summary>
        /// Filter by attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<Type> WithInterface<T>(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.Implement<T>());
        }

        /// <summary>
        /// Filter by a conditional criteria base on types target type feature.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<Type> ShouldBeClass(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsClass);
        }

        /// <summary>
        /// Filter by a conditional criteria base on types target type feature.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<Type> ShouldBePrimitive(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsPrimitive);
        }

        /// <summary>
        /// Filter by a conditional criteria base on types target type feature.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<Type> ShouldBeValueType(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsValueType);
        }

        /// <summary>
        /// Filter by a conditional criteria base on types target type feature.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<Type> ShouldBeGenericType(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsGenericType);
        }

        /// <summary>
        /// Filter by a conditional criteria base on types target type feature.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<Type> ShouldBeArray(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsArray);
        }

        /// <summary>
        /// Filter by a conditional criteria base on types target type feature.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<Type> ShouldBeRef(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsByRef);
        }

        /// <summary>
        /// Filter by a conditional criteria base on types target type feature.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<Type> ShouldBeCOMObject(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsCOMObject);
        }

        /// <summary>
        /// Filter by a conditional criteria base on types target type feature.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<Type> ShouldBePublic(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsPublic);
        }

        /// <summary>
        /// Filter by a conditional criteria base on types target type feature.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<Type> ShouldBeImport(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsImport);
        }

        /// <summary>
        /// Filter by a conditional criteria base on types target type feature.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<Type> ShouldBeEnum(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsEnum);
        }

        /// <summary>
        /// Determine if any element in type sequence enuemrable has the feature that evaluate this oeprand.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool AnyIsClass(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsClass).Any();
        }

        /// <summary>
        /// Determine if any element in type sequence enuemrable has the feature that evaluate this oeprand.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool AnyIsPrimitive(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsPrimitive).Any();
        }

        /// <summary>
        /// Determine if any element in type sequence enuemrable has the feature that evaluate this oeprand.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool AnyIsValueType(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsValueType).Any();
        }

        /// <summary>
        /// Determine if any element in type sequence enuemrable has the feature that evaluate this oeprand.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool AnyIsGenericType(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsGenericType).Any();
        }

        /// <summary>
        /// Determine if any element in type sequence enuemrable has the feature that evaluate this oeprand.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool AnyIsArray(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsArray).Any();
        }

        /// <summary>
        /// Determine if any element in type sequence enuemrable has the feature that evaluate this oeprand.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool AnyIsRef(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsByRef).Any();
        }

        /// <summary>
        /// Determine if any element in type sequence enuemrable has the feature that evaluate this oeprand.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool AnyIsCOMObject(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsCOMObject).Any();
        }

        /// <summary>
        /// Determine if any element in type sequence enuemrable has the feature that evaluate this oeprand.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool AnyIsPublic(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsPublic).Any();
        }

        /// <summary>
        /// Determine if any element in type sequence enuemrable has the feature that evaluate this oeprand.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool AnyIsImport(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsImport).Any();
        }

        /// <summary>
        /// Determine if any element in type sequence enuemrable has the feature that evaluate this oeprand.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool AnyIsEnum(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(t => t.IsEnum).Any();
        }

        /// <summary>
        /// Simple herlper to filter a concrete type
        /// </summary>
        /// <typeparam name="T">The target type to filter.</typeparam>
        /// <param name="enumerable">The type enuemration.</param>
        /// <returns></returns>
        public static IEnumerable<Type> WhereIs<T>(this IEnumerable<Type> enumerable)
        {
            return enumerable.Where(x =>
            {
                Type currentType = typeof(T);
                return x.Equals(currentType);
            });
        }

        /// <summary>
        /// Filter type by construct criteria.
        /// </summary>
        /// <param name="types"></param>
        /// <param name="typesTraget"></param>
        /// <returns></returns>
        public static IEnumerable<Type> WithConstruct(this IEnumerable<Type> types, Type[] typesTraget)
        {
            return types
                .Where(x => !(x.GetConstructor(typesTraget) is null));
        }

        /// <summary>
        /// Filter type by construct criteria.
        /// </summary>
        /// <param name="assemblies"></param>
        /// <param name="typesTraget"></param>
        /// <param name="all"></param>
        /// <returns></returns>
        public static IEnumerable<Type> WithConstruct(this Assembly assemblies, Type[] typesTraget, bool all = false)
        {
            return assemblies
                .GetExportedTypes()
                .Where(x => !(x.GetConstructor(typesTraget) is null));
        }

        /// <summary>
        /// Get all type from the assemblies sequence enumerable.
        /// </summary>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static IEnumerable<Type> AllTypes(this IEnumerable<Assembly> assemblies)
        {
            return assemblies.SelectMany(x => x.GetTypes());
        }

        /// <summary>
        /// Get all type from the assemblies sequence enumerable.
        /// </summary>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static IEnumerable<Type> AllExportedTypes(this IEnumerable<Assembly> assemblies)
        {
            return assemblies.SelectMany(x => x.GetExportedTypes());
        }
    }
}
