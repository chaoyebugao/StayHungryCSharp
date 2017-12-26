using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.单向链
{
    public class Node
    {
        private object _data;

        private Node _next;

        public Node(object data, Node next)
        {
            this._data = data;
            this._next = next;
        }

        public object Data
        {
            get
            {
                return this._data;
            }
        }

        public Node Next
        {
            get
            {
                return this._next;
            }
        }

        public void Pop()
        {
            if (this._next != null && this._next._next == null)
            {
                this._next = null;
            }
            else if (this._next != null)
            {
                this._next.Pop();
            }
        }
        
        public void Print()
        {
            if(this.Next != null)
            {
                this.Next.Print();
            }
            
            Console.WriteLine(this.Data.ToString());
        }

    }
}
