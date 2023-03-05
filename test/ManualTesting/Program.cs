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
                //Console.WriteLine($"Left child encoding:  \"{input.GetLeftChildEncoding()}\"");
                //Console.WriteLine($"Right child encoding: \"{input.GetRightChildEncoding()}\"\n");

                Node? root = Parsing.StringToBinaryTree(input);

                if (root is null)
                {
                    Console.WriteLine("Resulting tree is null");
                }
                else if(root.IsLeaf)
                {
                    Console.WriteLine($"Root '{root.Label}' is a leaf");
                }
                else
                {
                    Console.Write("Fringe:");
                    foreach (var node in root.GetFringe())
                        Console.Write($" {node.Label}");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}\n");
                return;
            }
        }
    }
}