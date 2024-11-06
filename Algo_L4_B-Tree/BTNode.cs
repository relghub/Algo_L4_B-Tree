namespace Algo_L4_B_Tree
{
    partial class Program
    {
        public class BTNode
        {
            public int item;
            public BTNode right;
            public BTNode left;

            public BTNode(int item)
            {
                this.item = item;
            }

            private void PrintValue(string value, NodePosition nodePostion)
            {
                switch (nodePostion)
                {
                    case NodePosition.left:
                        PrintLeftValue(value);
                        break;
                    case NodePosition.right:
                        PrintRightValue(value);
                        break;
                    case NodePosition.center:
                        Console.WriteLine(value);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            private void PrintLeftValue(string value)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("L:");
                Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.WriteLine(value);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            private void PrintRightValue(string value)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("R:");
                Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.WriteLine(value);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            public void PrintPretty(string indent, NodePosition nodePosition, bool last, bool empty)
            {

                Console.Write(indent);
                if (last)
                {
                    Console.Write("└─");
                    indent += "  ";
                }
                else
                {
                    Console.Write("├─");
                    indent += "│ ";
                }

                var stringValue = empty ? "-" : item.ToString();
                PrintValue(stringValue, nodePosition);

                if (!empty && (this.left != null || this.right != null))
                {
                    if (this.left != null)
                        this.left.PrintPretty(indent, NodePosition.left, false, false);
                    else
                        PrintPretty(indent, NodePosition.left, false, true);

                    if (this.right != null)
                        this.right.PrintPretty(indent, NodePosition.right, true, false);
                    else
                        PrintPretty(indent, NodePosition.right, true, true);
                }
            }

        }
    }

}
