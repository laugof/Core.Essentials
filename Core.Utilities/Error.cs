using System;

namespace Core
{
    /// <summary>
    /// Author: Laurent Goffin
    /// Error
    /// </summary>
    [Serializable]
    public class Error
    {
        public static bool SetError(int number, string comment, ref Error error)
        {
            error.Set(number, comment);
            return false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="number">Erro</param>
        /// <param name="comment"></param>
        public Error(int number, string comment)
        {
            Set(number, comment);
        }

        public void Set(Error error)
        {
            Number = error.Number;
            Comment = error.Comment;
        }

        public void Set(int number, string comment)
        {
            Number = number;
            Comment = comment;
        }

        public void Set(string comment)
        {
            Comment = comment;
        }

        public string Comment { get; private set; } = "OK";

        public int Number { get; private set; } = 0;
    }
}
