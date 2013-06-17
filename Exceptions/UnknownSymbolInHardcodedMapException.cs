using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NotJustSokoban
{
    [Serializable]
    class UnknownSymbolInHardcodedMapException : Exception
    {
        public UnknownSymbolInHardcodedMapException()
            : base()
        {
        }
    
        public UnknownSymbolInHardcodedMapException(string message)
            : base(message)
        {
        }
    
        public UnknownSymbolInHardcodedMapException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }
    
        public UnknownSymbolInHardcodedMapException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    
        public UnknownSymbolInHardcodedMapException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected UnknownSymbolInHardcodedMapException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
