using DataStructures.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataStructures;

public static class Parsing
{
    public static Node? ToBinaryTree(this string encoding)
    {
        if(string.IsNullOrEmpty(encoding))
            return null;

        var terminalMatch = Regex.Match(encoding, @"^[^\(\,\)]+$");

        if (terminalMatch.Success)
            return new Node(terminalMatch.Value);

        var leftEncoding = encoding.GetLeftChildEncoding();
        var rightEncoding = encoding.GetRightChildEncoding();

        var leftChild = leftEncoding.ToBinaryTree();
        var rightChild = rightEncoding.ToBinaryTree();

        return new Node(leftChild, rightChild);
    }

    public static string GetLeftChildEncoding(this string parentEncoding)
    {
        Match rootNodeValidation = Regex.Match(parentEncoding, @"^\(.*\)$");

        if (!rootNodeValidation.Success)
            throw new ParseErrorException(
                $"parentEncoding \"{parentEncoding}\" is not a valid root node encoding");

        parentEncoding = parentEncoding[1..^1];

        var sb = new StringBuilder();

        int i = 0;
        int depth = 0;

        while(i < parentEncoding.Length)
        {
            switch(parentEncoding[i])
            {
                case '(':
                {
                    sb.Append('(');
                    depth++;
                    break;
                }
                case ')':
                {
                    sb.Append(')');
                    depth--;
                    if (depth < 0)
                    {
                        throw new ParseErrorException(
                            $"Too many closing parens in encoding: \"{parentEncoding}\"");
                    }
                    break;
                }
                case ',':
                {
                    if (depth == 0)
                        return sb.ToString();
                    else
                        sb.Append(',');
                        break;
                }
                default:
                {
                    sb.Append(parentEncoding[i]);
                    break;
                }
            }
            i++;
        }
        Console.WriteLine("Didnt find parent comma");
        return sb.ToString();
    }

    public static string GetRightChildEncoding(this string parentEncoding)
    {
        Match rootNodeValidation = Regex.Match(parentEncoding, @"^\(.*\)$");

        if (!rootNodeValidation.Success)
            throw new ParseErrorException(
                $"parentEncoding \"{parentEncoding}\" is not a valid root node encoding");

        parentEncoding = parentEncoding[1..^1];

        var sb = new StringBuilder();

        int i = parentEncoding.Length - 1;
        int depth = 0;

        while(i >= 0)
        {
            switch(parentEncoding[i])
            {
                case ')':
                {
                    sb.Insert(0, ')');
                    depth++; 
                    break;
                }
                case '(':
                {
                    sb.Insert(0, '(');
                    depth--;
                    break;
                }
                case ',':
                {
                    if (depth == 0)
                        return sb.ToString();
                    else
                        sb.Insert(0, ',');
                        break;
                }
                default:
                {
                    sb.Insert(0, parentEncoding[i]);
                    break;
                }
            }
            i--;
        }
        return sb.ToString();
    }

    public static string GetSubstringToClosingParen(this string s,
        int indexOfOpeningParen)
    {
        int depth = 1;
        int i = indexOfOpeningParen + 1;

        while (i < s.Length)
        {
            switch (s[i])
            {
                case ')':
                {
                    depth--;
                    if (depth == 0)
                        return s.Substring(indexOfOpeningParen, (i - indexOfOpeningParen) + 1);
                    break;
                }
                case '(':
                {
                    depth++;
                    break;
                }
            }
            i++;
        }

        throw new ParseErrorException("Closing paren not found");
    }
}

public class ParseErrorException : Exception
{
    public ParseErrorException(string message) : base(message) { }
}
