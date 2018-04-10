using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Exceptions
{
    [global::System.Serializable]
    public class VariavelInvalida : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public VariavelInvalida() { }
        public VariavelInvalida(string message) : base(message) { }
        public VariavelInvalida(string message, Exception inner) : base(message, inner) { }
        protected VariavelInvalida(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
