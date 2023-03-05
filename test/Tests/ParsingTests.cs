using Solution;
using DataStructures;
using DataStructures.BinaryTree;
using System.Runtime.CompilerServices;

namespace Tests;

public class ParsingTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Parse_EmptyString_ReturnsNull()
    {
        var input = "";
        var result = Parsing.StringToBinaryTree(input);

        Console.WriteLine($"input: {input}");

        Assert.That(result, Is.Null);
    }

    [Test]
    public void Parse_EmptyParens_ReturnsChildlessRoot()
    {
        var input = "(,)";
        var result = Parsing.StringToBinaryTree(input);

        Console.WriteLine($"input: {input}");

        Assert.That(result, Is.Not.Null, "Root is not null");
        Assert.That(result.IsLeaf, "Root is leaf");
    }

    [Test]
    public void Parse_Terminal_ReturnsLeafRoot()
    {
        var input = "1";
        var result = Parsing.StringToBinaryTree(input);

        Console.WriteLine($"input: {input}");

        Assert.That(result, Is.Not.Null, "Root is null");
        Assert.That(result.IsLeaf);
        Assert.That(result.Label, Is.EqualTo("1"), "Leaf-root's label = \"1\"");
    }

    [Test]
    public void Parse_SingleParensWithTwoTerminals_ReturnsRootWithLeafChildren()
    {
        var input = "(1,2)";
        var result = Parsing.StringToBinaryTree(input);

        Console.WriteLine($"input: {input}");

        Assert.That(result, Is.Not.Null, "Root is not null");
        Assert.That(result.IsLeaf, Is.False, "Root is not leaf");

        Assert.Multiple(() =>
        {
            Assert.That(result.LeftChild, Is.Not.Null, "Left child is not null");
            Assert.That(result.RightChild, Is.Not.Null, "Right child is not null");
        });

        Assert.Multiple(() =>
        {
            Assert.That(result.LeftChild.IsLeaf, "Left child is a leaf");
            Assert.That(result.RightChild.IsLeaf, "Right child a leaf");
        });

        Assert.Multiple(() =>
        {
            Assert.That(result.LeftChild.Label, Is.EqualTo("1"), "Left child's label = \"1\"");
            Assert.That(result.RightChild.Label, Is.EqualTo("2"), "Right child's label = \"2\"");
        });
    }

    [Test]
    public void Parse_OnlyLeftNestedParens_ReturnsTreeWithOnlyLeftChildren()
    {
        var input = "((((1,),),),)";
        var result = Parsing.StringToBinaryTree(input);

        Console.WriteLine($"input: {input}");

        Node visit = result;
        int visitDepth = 0;

        while(visit.HasLeftChild)
        {
            Assert.That(visit.HasRightChild, Is.False, $"Node at visit depth {visitDepth} has no right child");
            visit = visit.LeftChild;
            visitDepth++;
        }

        Assert.That(visit is not null, "Final visited node is not null");
        Assert.That(visitDepth, Is.EqualTo(4), "Visit depth = 4");
        Assert.That(visit.IsLeaf, Is.True, "Final visited node is a leaf");
        Assert.That(visit.HasRightChild, Is.False, $"Leaf node has no right child");
        Assert.That(visit.Label, Is.EqualTo("1"), "Leaf node has label = \"1\"");

    }

    [Test]
    public void Parse_OnlyRightNestedParens_ReturnsTreeWithOnlyRightChildren()
    {
        var input = "(,(,(,(,(,1)))))";
        var result = Parsing.StringToBinaryTree(input);

        Console.WriteLine($"input: {input}");

        Node visit = result;
        int visitDepth = 0;

        while (visit.HasRightChild)
        {
            Assert.That(visit.HasLeftChild, Is.False, $"Node at visit depth {visitDepth} has no left child");
            visit = visit.RightChild;
            visitDepth++;
        }

        Assert.That(visit is not null, "Final visited node is not null");
        Assert.That(visitDepth, Is.EqualTo(5), "Visit depth = 5");
        Assert.That(visit.IsLeaf, Is.True, "Final visited node is a leaf");
        Assert.That(visit.HasLeftChild, Is.False, $"Leaf node has no left child");
        Assert.That(visit.Label, Is.EqualTo("1"), "Leaf node has label = \"1\"");
    }
}