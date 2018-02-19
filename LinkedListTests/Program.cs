using LinkedList;

namespace LinkedListTests
{
    class Program
    {
        static void Main(string[] args)
        {

            LinkedList<int> ll = new LinkedList<int>();

            ll.Add(1);
            ll.Add(2);
            ll.Add(3);


            var node = ll.Head;
            while (node.Next != null)
            {
                System.Console.WriteLine(node.Data.ToString());
            }


        }
    }
}
