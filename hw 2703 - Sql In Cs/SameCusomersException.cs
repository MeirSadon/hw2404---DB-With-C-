using System;
using System.Runtime.Serialization;

namespace hw_2703___Sql_In_Cs
{
    [Serializable]
    public class SameCusomersException : Exception
    {
        public SameCusomersException()
        {
        }

        public SameCusomersException(string message) : base(message)
        {
        }

        public SameCusomersException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SameCusomersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}