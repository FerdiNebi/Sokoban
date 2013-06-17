using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NotJustSokoban.Classes.Game_Objects
{
    [Serializable]
    class TooManyPlayersException : Exception
    {
        public TooManyPlayersException()
            : base()
        {
        }
    
        public TooManyPlayersException(string message)
            : base(message)
        {
        }
    
        public TooManyPlayersException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }
    
        public TooManyPlayersException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    
        public TooManyPlayersException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected TooManyPlayersException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
