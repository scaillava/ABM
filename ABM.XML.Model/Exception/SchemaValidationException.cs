using System;
using System.Collections.Generic;
using System.Text;

namespace ABM.XML.Model.Exception
{
    public class SchemaValidationException : System.Exception
    {
        public SchemaValidationException(string message)
       : base(message)
        {
        }

        public SchemaValidationException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
