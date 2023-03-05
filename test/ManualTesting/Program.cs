using DataStructures;
using DataStructures.BinaryTree;

namespace ManualTesting;

public class Program
{
    public static void Main(string[] args)
    {
        string? input;
        while((input = Console.ReadLine()) is not null && input != "quit")
        {
            if (input == "") continue;

            try
            {
                Console.WriteLine($"Left child encoding:  \"{input.GetLeftChildEncoding()}\"");
                Console.WriteLine($"Right child encoding: \"{input.GetRightChildEncoding()}\"\n");
                Node? root = input.ToBinaryTree();

                if (root is null)
                {
                    Console.WriteLine("Resulting tree is null");
                }
                else if(root.IsLeaf)
                {
                    Console.WriteLine($"Root {root.Label} is a leaf");
                }
                else
                {
                    Node visit = root;
                    while(visit.HasLeftChild)
                    {
                        visit = visit.LeftChild;
                    }
                    Console.WriteLine($"Leftmost child: {visit.Label}");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}\n");
            }
        }
    }
}