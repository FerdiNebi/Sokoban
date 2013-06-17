using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NotJustSokoban
{
    [Serializable]
    class WrongSourceTypeException : Exception
    {
        public WrongSourceTypeException()
            : base()
        {
        }
    
        public WrongSourceTypeException(string message)
            : base(message)
        {
        }
    
        public WrongSourceTypeException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }
    
        public WrongSourceTypeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    
        public WrongSourceTypeException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected WrongSourceTypeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
