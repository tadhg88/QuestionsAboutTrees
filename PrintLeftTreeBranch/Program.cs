using System;
using System.Collections.Generic;

namespace PrintLeftTreeBranch
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(1);
            root.Left = new Node(2);
            root.Left.Left =  new Node(4);
            root.Left.Right = new Node(5);

            root.Right = new Node(3);
            root.Right.Left = new Node(6);
            root.Right.Right = new Node(7);
            root.Right.Right.Right = new Node(8);


            //               1
            //             /   \
            //            2     3
            //           / \   /  \
            //          4   5 6    7
            //                      \
            //                        8


            FindNodes findNodes = new FindNodes();
            findNodes.FindFirstVisibleNodes(root, 1);
            Console.WriteLine();

            findNodes.PrintLeftViewNodes_UsingQueue(root);
            Console.WriteLine();

            findNodes.previousMaxLevel = 0;
            findNodes.FindLeftTreeNodes(root, 1);

            findNodes.previousMaxLevel = 0;
            findNodes.FindRightTreeNodes(root.Right, 1);
        }
    }

    public class FindNodes
    {
        public int previousMaxLevel = 0;

        /// <summary>
        /// Given a Binary Tree, print left view of it. Left view of a Binary Tree is set of nodes visible when tree is visited from left side.
        /// https://www.geeksforgeeks.org/print-left-view-binary-tree/
        /// </summary>
        /// <param name="root">Current node being traversed.</param>
        /// <param name="currentLevel">Level of current node.</param>
        public void FindFirstVisibleNodes(Node root, int currentLevel)
        {
            if (root == null)
                return;

            // If this is the first node of its level
            if (currentLevel > previousMaxLevel)
            {
                Console.Write(root.Data + " ");
                previousMaxLevel = currentLevel;
            }

            FindFirstVisibleNodes(root.Left, currentLevel+1);
            FindFirstVisibleNodes(root.Right, currentLevel+1);
        }

        /// <summary>
        /// Print left view of binary tree using queue
        /// </summary>
        /// <param name="root"></param>
        public void PrintLeftViewNodes_UsingQueue(Node root)
        {
            if (root == null)
                return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                // number of nodes at current level
                int n = queue.Count;

                // Traverse all nodes of current level
                for (int i = 1; i <= n; i++)
                {
                    Node temp = queue.Dequeue();

                    // Print the left most element at the level
                    if (i == 1)
                        Console.Write(temp.Data + " ");

                    // Add left node to queue
                    if (temp.Left != null)
                        queue.Enqueue(temp.Left);

                    // Add right node to queue
                    if (temp.Right != null)
                        queue.Enqueue(temp.Right);
                }
            }
        }

        public void FindLeftTreeNodes(Node root, int currentLevel)
        {
            if (root == null)
                return;

            int? itemToPrint = null;

            // If this is the first node of its level
            if (previousMaxLevel < currentLevel)
            {
                itemToPrint = root.Data;
                previousMaxLevel = currentLevel;
            }

            FindLeftTreeNodes(root.Left, currentLevel + 1);

            if(itemToPrint.HasValue)
                Console.Write(itemToPrint + " ");
        }

        public void FindRightTreeNodes(Node root, int currentLevel)
        {
            if (root == null)
                return;

            // If this is the first node of its level
            if (previousMaxLevel < currentLevel)
            {
                Console.Write(root.Data + " ");
                previousMaxLevel = currentLevel;
            }

            FindRightTreeNodes(root.Right, currentLevel + 1);
        }

    }

    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;

        public Node(int data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }
    }
}
