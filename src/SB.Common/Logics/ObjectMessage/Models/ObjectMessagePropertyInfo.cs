namespace SB.Common.Logics.ObjectMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectMessagePropertyInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public object PropertyObject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyObject"></param>
        /// <param name="propertyName"></param>
        public ObjectMessagePropertyInfo(object propertyObject, string propertyName)
        {
            PropertyObject = propertyObject;
            PropertyName = propertyName;
        }
    }
}
