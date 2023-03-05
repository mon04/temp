using DataStructures;
using DataStructures.BinaryTree;

namespace Solution;

public static class Solver
{

    public static bool GetSolution(string encoding1, string encoding2)
    {
        try
        {
            Node root1 = Parsing.StringToBinaryTree(encoding1);
            Node root2 = Parsing.StringToBinaryTree(encoding2);

            var fringe1 = root1.GetFringe();
            var fringe2 = root2.GetFringe();

            return fringe1.SequenceEqual(fringe2, new NodeLabelEqualityComparer());
        }
        catch(Exception e)
        {
            throw e;
        }
    }
}