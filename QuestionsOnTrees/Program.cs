﻿using System;
using System.Collections.Generic;

namespace QuestionsOnTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            //               1
            //             /   \
            //            2     3
            //           / \   /  \
            //          4   5 6    7
            //                      \
            //                        8
            Node root = CreateTree();

            Console.WriteLine("Print nodes visible from left using Recursion");
            NodeFinder nodeFinder = new NodeFinder();
            nodeFinder.FindFirstVisibleNodes(root, 1);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Print nodes visible from left using Queue");
            nodeFinder.PrintLeftViewNodes_UsingQueue(root);
            Console.WriteLine();
            Console.WriteLine();

            nodeFinder.PrintTreeOutline(root);
            Console.WriteLine();
            Console.WriteLine();

            var sum = nodeFinder.SumTreeNodes(root);
            Console.WriteLine("Sum: " + sum);
        }

        private static Node CreateTree()
        {
            Node root = new Node(1);
            root.Left = new Node(2);
            root.Left.Left = new Node(4);
            root.Left.Right = new Node(5);

            root.Right = new Node(3);
            root.Right.Left = new Node(6);
            root.Right.Right = new Node(7);
            root.Right.Right.Right = new Node(8);
            
            return root;
        }
    }
}