using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NotJustSokoban
{
    [Serializable]
    class WrongMapNameException : Exception
    {
        public WrongMapNameException()
            : base()
        {
        }
    
        public WrongMapNameException(string message)
            : base(message)
        {
        }
    
        public WrongMapNameException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }
    
        public WrongMapNameException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    
        public WrongMapNameException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected WrongMapNameException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
