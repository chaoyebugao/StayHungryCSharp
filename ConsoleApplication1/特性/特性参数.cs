using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.特性
{
    [AttributeUsage(AttributeTargets.Parameter)]
    class SetMinAttr : Attribute
    {
        public int Min = 100;
    }
    class AttributeTest
    {
        public static void TestMethod([SetMinAttr]int pa1)
        {
            ParameterInfo pi = MethodInfo.GetCurrentMethod().GetParameters()[0];
            SetMinAttr att = SetMinAttr.GetCustomAttribute(pi, typeof(SetMinAttr)) as SetMinAttr;
            if(att.Min > pa1)
            {
                 throw new Exception("errrr");
            }
        }
    }
}
