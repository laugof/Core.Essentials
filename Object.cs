using System;

namespace Core.Interface
{
    /// <summary>
    /// Author : Laurent Goffin
    /// Named object
    /// </summary>
    public interface INamed
    {
        string Name { get; }
    }
}

namespace Core
{
    public class Object : Core.Interface.INamed, Core.Interface.ITimestamped
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Object name</param>
        public Object(string name)
        {
            m_name = name;
        }

        /// <summary>
        /// Object name
        /// </summary>
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        /// <summary>
        /// Object creation timestamp 
        /// </summary>
        public DateTime DateTime
        {
            get { return m_timestamp; }
        }

        /// <summary>
        /// Unique serial number
        /// </summary>
        public readonly long UID = ++Increment;

        #region Private and protected members

        /// <summary>
        /// Last attributed UID
        /// </summary>
        private static long Increment = 0;

        /// <summary>
        /// Timestamp of the object creation
        /// </summary>
        private readonly DateTime m_timestamp = DateTime.Now;

        /// <summary>
        /// Object name
        /// </summary>
        protected string m_name = "";

        #endregion Private and protected members
    }
}
