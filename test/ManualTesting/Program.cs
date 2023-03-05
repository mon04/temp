using Solution;
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

                //Node? root = Parsing.StringToBinaryTree(input);

                //if (root is null)
                //{
                //    Console.WriteLine("Resulting tree is null");
                //}
                //else
                //{
                //    Console.Write("Fringe:");
                //    foreach (var node in root.GetFringe())
                //        Console.Write($" {node.Label}");
                //}

                string[] inputs = input.Split(' ');

                var fringe1 = Parsing.StringToBinaryTree(inputs[0]).GetFringe();
                var fringe2 = Parsing.StringToBinaryTree(inputs[1]).GetFringe();

                Console.Write("Fringe 1:");
                foreach(var node in fringe1)
                    Console.Write($" {node.Label}");
                Console.WriteLine();

                Console.Write("Fringe 2:");
                foreach (var node in fringe2)
                    Console.Write($" {node.Label}");
                Console.WriteLine();

                Console.WriteLine($"Equal: {Solver.GetSolution(inputs[0], inputs[1])}");

            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}\n");
                return;
            }
        }
    }
}