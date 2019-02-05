using SBCommon.Extensions;
using SBCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SB.Common.Logics.ObjectMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectMessageReplaceHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public ObjectMessageBuilder Builder { get; }

        /// <summary>
        /// 
        /// </summary>
        public List<ObjectMessageReplaceInfo> ReplaceInfos { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public ObjectMessageReplaceHelper(ObjectMessageBuilder builder)
        {
            Builder = builder;
            ReplaceInfos = new List<ObjectMessageReplaceInfo>();
            Initialize(builder.OriginalMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Initialize(string message)
        {
            var leftIndex = LeftIndex(message);
            while (leftIndex != -1)
            {
                InitializeReplaceInfo(message, leftIndex);
                leftIndex = LeftIndex(message, ++leftIndex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="leftIndex"></param>
        private void InitializeReplaceInfo(string message, int leftIndex)
        {
            var rightIndex = RightIndex(message, leftIndex);
            if (rightIndex == -1)
                return;

            var text = message.Substring(leftIndex, rightIndex - leftIndex + 1);
            ReplaceInfos.Add(new ObjectMessageReplaceInfo(text));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private int LeftIndex(string message, int startIndex = 0)
        {
            return message.IndexOf(Strings.LFigureBracket, startIndex, StringComparison.InvariantCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private int RightIndex(string message, int startIndex = 0)
        {
            return message.IndexOf(Strings.RFigureBracket, startIndex, StringComparison.InvariantCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageProperty"></param>
        /// <param name="value"></param>
        public void Replace(ObjectMessageProperty messageProperty, object value)
        {
            Replace(messageProperty.ToString(), value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propName"></param>
        /// <param name="value"></param>
        public void Replace(string propName, object value)
        {
            var replaceInfo = ReplaceInfos.FirstOrDefault(f => f.Property == propName);
            if (replaceInfo == null)
                return;

            if (!string.IsNullOrEmpty(replaceInfo.Format))
            {
                ReplaceWithFormat(replaceInfo, value);
                return;
            }

            InternalReplace(replaceInfo, value.ToSafeString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="replaceInfo"></param>
        /// <param name="value"></param>
        private void ReplaceWithFormat(ObjectMessageReplaceInfo replaceInfo, object value)
        {
            if (value is IFormattable formattable)
            {
                var text = formattable.ToString(replaceInfo.Format, null);
                InternalReplace(replaceInfo, text);
                return;
            }

            InternalReplace(replaceInfo, value.ToSafeString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="replaceInfo"></param>
        /// <param name="value"></param>
        private void InternalReplace(ObjectMessageReplaceInfo replaceInfo, string value)
        {
            Builder.Message = Builder.Message.Replace(replaceInfo.Replacement, value);
        }
    }
}
