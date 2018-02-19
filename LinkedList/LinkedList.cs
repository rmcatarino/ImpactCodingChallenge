using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList<T>
    {
        public Node<T> Head = null;

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>();
            newNode.Data = data;

            //Set to head
            newNode.Next = Head;
            Head = newNode;
        }

    }
}
