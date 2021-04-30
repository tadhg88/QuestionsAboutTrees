using System;
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


            NodeFinder nodeFinder = new NodeFinder();
            nodeFinder.FindFirstVisibleNodes(root, 1);
            Console.WriteLine();

            nodeFinder.PrintLeftViewNodes_UsingQueue(root);
            Console.WriteLine();

            nodeFinder.previousMaxLevel = 0;
            nodeFinder.FindLeftTreeNodes(root, 1);

            nodeFinder.previousMaxLevel = 0;
            nodeFinder.FindRightTreeNodes(root.Right, 1);
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