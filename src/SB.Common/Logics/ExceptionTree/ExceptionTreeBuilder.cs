using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SB.Common.Extensions;
using SB.Common.Logics.ExceptionTree.Helpers;
using SB.Common.Logics.ExceptionTree.Models;

namespace SB.Common.Logics.ExceptionTree
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionTreeBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<object> _recursiveObjects;

        /// <summary>
        /// 
        /// </summary>
        public ExceptionTreeBuilder()
        {
            _recursiveObjects = new List<object>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public ExceptionTreeNode Build(Exception exception)
        {
            return InternalBuild(exception).Clone();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        private ExceptionTreeNodeItem InternalBuild(Exception exception)
        {
            if (exception == null)
                return null;

            _recursiveObjects.Add(exception);
            var rootNode = new ExceptionTreeNodeItem(exception, exception.GetType().ToString(), exception.Message);

            var properties = GetProperties(exception);
            if (properties.Length == 0)
                return rootNode;

            rootNode.Childs = new List<ExceptionTreeNode>();
            foreach (var property in properties)
            {
                var node = GetInformationNode(property, exception);
                if (IsRecursive(node))
                    continue;

                rootNode.Childs.Add(node);
                _recursiveObjects.Add(node.TreeItemObject);
            }

            return rootNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private ExceptionTreeNodeItem GetInformationNode(PropertyInfo property, object obj)
        {
            try
            {
                return TryGetInformationNode(property, obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private ExceptionTreeNodeItem TryGetInformationNode(PropertyInfo property, object obj)
        {
            var value = TryGetValue(property, obj);
            var resultNode = new ExceptionTreeNodeItem(value, property.Name, value.ToSafeString());

            if (value == null || ExceptionTreeHelper.ExcludesTypes.Contains(property.PropertyType))
                return resultNode;

            var properties = GetProperties(value);
            if (properties.Length == 0)
                return resultNode;

            resultNode.Childs = new List<ExceptionTreeNode>();
            foreach (var propertyRow in properties)
            {
                var node = GetInformationNode(propertyRow, value);
                if (IsRecursive(node))
                    continue;

                resultNode.Childs.Add(node);
                _recursiveObjects.Add(node.TreeItemObject);
            }

            return resultNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool IsRecursive(ExceptionTreeNodeItem node)
        {
            if (node == null)
                return true;

            return node.TreeItemObject != null && _recursiveObjects.Any(a => ReferenceEquals(a, node.TreeItemObject));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private PropertyInfo[] GetProperties(object obj)
        {
            if (obj == null || obj is MethodInfo)
                return new PropertyInfo[0];

            return obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private object TryGetValue(PropertyInfo propertyInfo, object obj)
        {
            try
            {
                return propertyInfo.GetValue(obj, null);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
