using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Exceptions
{
    [global::System.Serializable]
    public class RegraLogicaInvalida : Exception
    {
        public RegraLogicaInvalida() { }
        public RegraLogicaInvalida(string message) : base(message) { }
        public RegraLogicaInvalida(string message, Exception inner) : base(message, inner) { }
        protected RegraLogicaInvalida(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
