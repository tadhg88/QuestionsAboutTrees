using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionsOnTrees
{
    public class NodeFinder
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

            FindFirstVisibleNodes(root.Left, currentLevel + 1);
            FindFirstVisibleNodes(root.Right, currentLevel + 1);
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

        public void PrintTreeOutline(Node root)
        {
            Console.WriteLine("Tree outline");

            previousMaxLevel = 0;
            FindLeftTreeNodes(root, 1);

            previousMaxLevel = 0;
            FindRightTreeNodes(root.Right, 1);
        }

        private void FindLeftTreeNodes(Node root, int currentLevel)
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

            if (itemToPrint.HasValue)
                Console.Write(itemToPrint + " ");
        }

        private void FindRightTreeNodes(Node root, int currentLevel)
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

        public int SumTreeNodes(Node root)
        {
            if (root == null)
                return 0;

            var leftSum = SumTreeNodes(root.Left);
            var rightSum = SumTreeNodes(root.Right);

            return root.Data + leftSum + rightSum;
        }

        public int Fib(int position)
        {
            if (position <= 2)
                return 1;

            var fib1 = Fib(position - 1);
            var fib2 = Fib(position - 2);

            return fib1 + fib2;
        }

        public int GridTraveller(int columns, int rows)
        {
            if (columns == 1 && rows == 1)
                return 1;
            if (columns == 0 || rows == 0)
                return 0;

            return GridTraveller(columns - 1, rows) + GridTraveller(columns, rows - 1);
        }

        public bool CanSum(int targetSum, int[] numbers)
        {
            if (targetSum == 0)
                return true;
            if (targetSum < 0)
                return false;

            foreach (int number in numbers)
            {
                int remainder = targetSum - number;
                if (CanSum(remainder, numbers) == true)
                    return true;
            }

            return false;
        }
    }
}
