using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foog.Core.DependencyInjection.Exceptions
{
    public class DependencyException:Exception
    {
        public DependencyException()
        {

        }

        public DependencyException(string message):base(message)
        {

        }
    }
}
