using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemeal.Model
{
    public class TMException : Exception
    {
        public TMException(string message) 
            : base(message)
        {
        }
    }
}
