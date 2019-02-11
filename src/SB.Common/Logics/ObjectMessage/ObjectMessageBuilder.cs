using SB.Common.Extensions;
using SB.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SB.Common.Logics.ObjectMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectMessageBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        internal List<object> CirculationObjects { get; }

        /// <summary>
        /// 
        /// </summary>
        public string OriginalMessage { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public ObjectMessageReplaceHelper ReplaceHelper { get; }

        /// <summary>
        /// 
        /// </summary>
        public ObjectMessagePropertyManager PropertyManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalMessage"></param>
        public ObjectMessageBuilder(string originalMessage)
        {
            OriginalMessage = originalMessage;

            CirculationObjects = new List<object>();
            ReplaceHelper = new ObjectMessageReplaceHelper(this);
            PropertyManager = new ObjectMessagePropertyManager(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Build(params object[] args)
        {
            try
            {
                Message = OriginalMessage;
                InternalBuild(args);
            }
            catch (Exception e)
            {
                LogHelper.Error(e);
            }

            return Message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void InternalBuild(params object[] args)
        {
            if (args == null)
                return;

            var argsList = args.ToList();
            argsList.ForEach(BuildArgMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="index"></param>
        private void BuildArgMessage(object arg, int index)
        {
            var props = PropertyManager.GetProperties(arg);
            if (!props.Any())
            {
                BuildArgWithoutProperty(arg, index);
                return;
            }

            InitalizeCirculationObjects(arg);
            props.ForEach(f => BuildMessageProperty(arg, f));

            InitalizeCirculationObjects(arg);
            props.ForEach(f => BuildMessagePropertyWithIndex(arg, f, index));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="index"></param>
        private void BuildArgWithoutProperty(object arg, int index)
        {
            InitalizeCirculationObjects(arg);
            var propInfo = new ObjectMessageProperty();
            PropertyManager.Build(arg, propInfo);

            InitalizeCirculationObjects(arg);
            propInfo = new ObjectMessageProperty();
            propInfo.AddToStartArgsIndex(index, propInfo);
            PropertyManager.Build(arg, propInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        private void InitalizeCirculationObjects(object arg)
        {
            CirculationObjects.Clear();
            CirculationObjects.Add(arg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="info"></param>
        private void BuildMessageProperty(object arg, PropertyInfo info)
        {
            var propInfo = new ObjectMessageProperty();
            propInfo.Add(info.Name, arg);

            var propValue = info.GetValue(arg);
            PropertyManager.Build(propValue, propInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="info"></param>
        /// <param name="index"></param>
        private void BuildMessagePropertyWithIndex(object arg, PropertyInfo info, int index)
        {
            var propInfo = new ObjectMessageProperty();
            propInfo.AddToStartArgsIndex(index, propInfo);
            propInfo.Add(info.Name, arg);

            var propValue = info.GetValue(arg);
            PropertyManager.Build(propValue, propInfo);
        }
    }
}
