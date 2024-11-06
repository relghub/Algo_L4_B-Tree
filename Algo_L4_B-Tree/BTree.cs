namespace Algo_L4_B_Tree
{
    partial class Program
    {
        public class BTree
        {
            public BTNode _root;
            private int _count;
            private IComparer<int> _comparer = Comparer<int>.Default;


            public BTree()
            {
                _root = null;
                _count = 0;
            }


            public bool Add(int Item)
            {
                if (_root == null)
                {
                    _root = new BTNode(Item);
                    _count++;
                    return true;
                }
                else
                {
                    return Add_Sub(_root, Item);
                }
            }

            private bool Add_Sub(BTNode Node, int Item)
            {
                if (_comparer.Compare(Node.item, Item) < 0)
                {
                    if (Node.right == null)
                    {
                        Node.right = new BTNode(Item);
                        _count++;
                        return true;
                    }
                    else
                    {
                        return Add_Sub(Node.right, Item);
                    }
                }
                else if (_comparer.Compare(Node.item, Item) > 0)
                {
                    if (Node.left == null)
                    {
                        Node.left = new BTNode(Item);
                        _count++;
                        return true;
                    }
                    else
                    {
                        return Add_Sub(Node.left, Item);
                    }
                }
                else
                {
                    return false;
                }
            }

            public void Print()
            {
                _root.PrintPretty("", NodePosition.center, true, false);
            }

            // Знаходить довжину шляху до найближчого мінімального позитивного елемента
            public int FindPathLengthToMinPositive(BTNode root)
            {
                // Ініціалізуємо мінімальне значення як великим числом
                int minPositiveValue = int.MaxValue;
                int minPathLength = int.MaxValue;

                // Виконуємо симетричний обхід дерева
                FindMinPositive(root, 0, ref minPositiveValue, ref minPathLength);

                // Якщо мінімальний позитивний елемент не знайдено, повертаємо -1
                return minPathLength == int.MaxValue ? -1 : minPathLength;
            }

            // Рекурсивний метод для симетричного обходу дерева і пошуку мінімального позитивного елемента
            private void FindMinPositive(BTNode node, int currentPathLength, ref int minPositiveValue, ref int minPathLength)
            {
                if (node == null)
                {
                    return;
                }

                // Спочатку обходимо ліве піддерево
                FindMinPositive(node.right, currentPathLength + 1, ref minPositiveValue, ref minPathLength);

                // Перевіряємо, чи є поточний елемент позитивним і мінімальним
                if (node.item > 0 && node.item < minPositiveValue)
                {
                    minPositiveValue = node.item;
                    minPathLength = currentPathLength;
                }

                // Далі обходимо праве піддерево
                FindMinPositive(node.right, currentPathLength + 1, ref minPositiveValue, ref minPathLength);
            }

        }
    }

}
