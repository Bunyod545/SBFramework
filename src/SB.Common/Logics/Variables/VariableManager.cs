using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SB.Common.Logics.Variables.Attributes;
using SB.Common.Logics.Variables.Interfaces;

namespace SB.Common.Logics.Variables
{
    /// <summary>
    /// 
    /// </summary>
    public static class VariableManager
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<Type, List<Variable>> Cache = new Dictionary<Type, List<Variable>>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(object context)
        {
            lock (Cache)
                InternalInitialize(context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        private static void InternalInitialize(object context)
        {
            if (context == null)
                return;

            if (Cache.TryGetValue(context.GetType(), out var variables))
            {
                variables.ForEach(f => f.PropertyInfo.SetValue(context, f.Clone(context)));
                return;
            }

            var variableProps = GetVariableProperties(context).ToList();
            var initializedVariables = variableProps.Select(s => InitializeVariableProperty(context, s)).ToList();
            Cache.Add(context.GetType(), initializedVariables);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<PropertyInfo> GetVariableProperties(object context)
        {
            if (context == null)
                return new List<PropertyInfo>();

            var props = context.GetType().GetProperties().ToList();
            return props.Where(IsVariableProperty).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static bool IsVariableProperty(PropertyInfo prop)
        {
            return prop != null &&
                   prop.PropertyType.IsGenericType &&
                   prop.PropertyType.GetGenericTypeDefinition() == typeof(Variable<>);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static Variable InitializeVariableProperty(object context, PropertyInfo prop)
        {
            if (context == null || prop == null)
                return null;

            var variable = (Variable)Activator.CreateInstance(prop.PropertyType);
            variable.Name = prop.Name;
            variable.PropertyInfo = prop;
            variable.ValueType = prop.PropertyType.GetGenericArguments().FirstOrDefault();
            variable.ContextObject = context;
            variable.ContextType = context.GetType();
            variable.TableType = GetVariableTableType(context, prop);
            variable.VariableService = GetVariableService(context, prop);

            prop.SetValue(context, variable);
            return variable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Type GetVariableTableType(object context, PropertyInfo prop)
        {
            return prop.IsHasAttribute<VariableTableAttribute>() ?
                prop.GetCustomAttribute<VariableTableAttribute>()?.TableType :
                context?.GetType().GetCustomAttribute<VariableTableAttribute>()?.TableType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static IVariableService GetVariableService(object context, PropertyInfo prop)
        {
            var attr = prop?.GetCustomAttribute<VariableServiceAttribute>() ??
                       context.GetType().GetCustomAttribute<VariableServiceAttribute>();

            if (attr != null)
                return (IVariableService)Activator.CreateInstance(attr.VariableServiceType);

            return context as IVariableService;
        }
    }
}
