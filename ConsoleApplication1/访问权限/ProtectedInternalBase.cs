using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.访问权限
{
    public class ProtectedInternalBase
    {
        protected static void Method1()
        {

        }

        internal static void Method2()
        {

        }

        protected internal static void Method3()
        {

        }
    }
}
