using SBCommon.Helpers;

namespace SB.Common.Logics.ObjectMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectMessageReplaceInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Replacement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="replacement"></param>
        public ObjectMessageReplaceInfo(string replacement)
        {
            Replacement = replacement;
            Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            var text = Replacement.Replace(Strings.LFigureBracket, string.Empty);
            text = text.Replace(Strings.RFigureBracket, string.Empty);

            var propAndFormat = text.Split(Strings.TwoPoints.ToCharArray());
            if (propAndFormat.Length > 0)
                Property = propAndFormat[0];

            if (propAndFormat.Length > 1)
                Format = propAndFormat[1];
        }
    }
}
