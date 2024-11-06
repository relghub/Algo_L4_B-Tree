namespace Algo_L4_B_Tree
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            BTree btr = new();
            while (true)
            {
                Console.Write("Введіть число: ");
                string? s = Console.ReadLine();
                if (int.TryParse(s, out int val))
                {
                    btr.Add(val);
                }
                else if (s == "stop")
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Неправильне введення!");
                    Console.ReadKey();
                }
                Console.SetCursorPosition(0, 0);
                Console.Clear();
            }

            btr.Print();
            Console.WriteLine($"Шлях до найближчого мінімального позитивного елемента: {btr.FindPathLengthToMinPositive(btr._root)}");

        }
    }

}
