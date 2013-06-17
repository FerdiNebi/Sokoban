using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NotJustSokoban.Classes.Timer
{
    [Serializable]
    class TimeOutException: Exception
    {
        public TimeOutException()
            : base()
        {
        }
    
        public TimeOutException(string message)
            : base(message)
        {
        }
    
        public TimeOutException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }
    
        public TimeOutException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    
        public TimeOutException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected TimeOutException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
