using System;

namespace ProgrammingInCSharp.Lab02.Exceptions
{
    [Serializable]
    public class PastBirthdateException : Exception
    {
        public PastBirthdateException()
        {

        }

        public PastBirthdateException(string message)
            : base(message)
        {

        }

        public PastBirthdateException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
