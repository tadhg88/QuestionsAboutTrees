using System;

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

            findNodes.maxLevel = 0;
            findNodes.FindLeftTreeNodes(root, 1);

            findNodes.maxLevel = 0;
            findNodes.FindRightTreeNodes(root.Right, 1);
        }
    }

    public class FindNodes
    {
        public int maxLevel = 0;

        public void FindFirstVisibleNodes(Node root, int currentLevel)
        {
            if (root == null)
                return;

            // If this is the first node of its level
            if (maxLevel < currentLevel)
            {
                Console.Write(root.Data + " ");
                maxLevel = currentLevel;
            }

            FindFirstVisibleNodes(root.Left, currentLevel+1);
            FindFirstVisibleNodes(root.Right, currentLevel+1);
        }

        public void FindLeftTreeNodes(Node root, int currentLevel)
        {
            if (root == null)
                return;

            int? itemToPrint = null;

            // If this is the first node of its level
            if (maxLevel < currentLevel)
            {
                itemToPrint = root.Data;
                maxLevel = currentLevel;
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
            if (maxLevel < currentLevel)
            {
                Console.Write(root.Data + " ");
                maxLevel = currentLevel;
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
