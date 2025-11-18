using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1lab
{
    internal class MeterReadingException : Exception
    {
        public MeterReadingException(string message) : base(message)
        {
        }
    }
}
