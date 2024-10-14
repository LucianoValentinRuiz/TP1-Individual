using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ModelNullException : Exception
    {
        public ModelNullException(string message) : base(message)
        {
        }
    }
}
