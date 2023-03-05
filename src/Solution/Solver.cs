using DataStructures;
using DataStructures.BinaryTree;

namespace Solution;

public static class Solver
{

    public static Node? GetSolution(string input)
    {
        try
        {
            return input.ToBinaryTree();
        }
        catch(Exception)
        {
            throw;
        }
    }
}