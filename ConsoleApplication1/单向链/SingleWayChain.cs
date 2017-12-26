using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.单向链
{
    class SingleWayChain
    {
        public static void Exec()
        {
            Node n1 = new Node("n1", null);

            Node n2 = new Node("n2", n1);

            Node n3 = new Node("n3", n2);

            n3.Print();

            n3.Pop();

            n3.Print();
        }
    }
}
