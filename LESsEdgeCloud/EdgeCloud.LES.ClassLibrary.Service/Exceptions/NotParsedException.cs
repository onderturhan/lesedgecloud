using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeCloud.LES.ClassLibrary.Service.Exceptions
{
    public class NotParsedException : Exception
    {
        public override string Message => "Data is not parsed";
    }
}
