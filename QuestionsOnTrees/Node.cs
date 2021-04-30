
namespace QuestionsOnTrees
{
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
