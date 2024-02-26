using System.Linq;
namespace Лабораторная_работа_6
{
    internal class Program
    {
        public static int[][] jaggedArray;
        public static bool itsOver;
        private static void Main(string[] args)
        {
            do
            {
                Commands();
                string request = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                switch (request)
                {
                    case "1":
                        VvodVruchnuiu();
                        Print(jaggedArray);
                        break;
                    case "2":
                        VvodRandomom();
                        Print(jaggedArray);
                        break;
                    case "3":
                        VvodRandomom();
                        Print(jaggedArray);
                        break;
                    case "4":
                        itsOver = true;
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует. Повторите ввод: ");
                        break;
                }
            } while (!itsOver);
        }
        private static void Commands()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Создание массива при помощи ввода чисел вручную.\n" +
                              "2. Создание массива при помощи датчика случайных чисел.\n" +
                              "3. Сортировка массива. \n" +
                              "4. Завершить работу.\n");
        }
        private static void VvodVruchnuiu()
        {
            Console.WriteLine("Введите количество строк массива: ");
            int rows = Check();
            jaggedArray = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = Zaza();
            }
            Console.WriteLine("Массив создан. \n");
        }
        private static void Sorting()
        {
            jaggedArray.Select(int[] x => Array.Sort(x));
        }
        private static int[] Zaza()
        {
            Console.WriteLine("Введите длинну строки: ");
            int n = Check();
            int[] elementsOfElement = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите элемент массива под номером {i + 1}. \n");
                int number = Check();
                elementsOfElement[i] = number;
            }
            return elementsOfElement;
        }
        private static void VvodRandomom()
        {
            Console.WriteLine("Введите количество строк массива: ");
            int rows = Check();
            int[] columns = NumberOfColumns(rows);
            jaggedArray = Create(columns);
            Console.WriteLine("Массив создан. \n");
        }
        public static int Check()
        {
            bool isCorrect;
            string numbeer;
            int n;
            do
            {
                numbeer = Console.ReadLine();
                isCorrect = int.TryParse(numbeer, out n);
                if (!isCorrect)
                {
                    Console.Write("Число не распознано. Повторите ввод: ");
                }
                else if (n < 1)
                {
                    Console.Write("Число должно быть больше 1. Повторите ввод: ");
                    isCorrect = false;
                }
            } while (!isCorrect);
            return n;
        }
        public static int Check2(int[][] jaggedArray)
        {
            bool isCorrect;
            string number;
            int n;
            do
            {
                number = Console.ReadLine();
                isCorrect = int.TryParse(number, out n);
                if (!isCorrect)
                {
                    Console.Write("Число не распознано. Повторите ввод: ");
                }
                else if (n < 0 || n > jaggedArray.GetLength(0))
                {
                    Console.Write("Такой строки не существует. Повторите ввод: \n");
                    isCorrect = false;
                }
            } while (!isCorrect);
            return n;
        }
        // Создание массива
        private static int[] Create(int length)
        {
            int[] numbers = new int[length];
            Random rand = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = (rand.Next(-100, 100));
            }
            return numbers;
        }
        private static int[][] Create(int[] columns)
        {
            int rows = columns.Length;
            Random rnd = new Random();
            int[][] jaggedArray = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = Create(columns[i]);
            }
            Array.Sort(jaggedArray);
            return jaggedArray;
        }
        private static int[] NumberOfColumns(int rows)
        {
            int[] columns = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Введите длину элемента массива под номером {i + 1}. \n");
                int n = Check();
                columns[i] = n;
            }
            return columns;
        }
        private static void Print(int[][] jaggedArray)
        {
            Console.WriteLine();
            for (int i = 0; i < jaggedArray.GetLength(0); i++)
            {
                for (int j = 0; j < jaggedArray[i].GetLength(0); j++)
                {
                    Console.Write($"{jaggedArray[i][j],4}");
                }
                Console.WriteLine();
            }
        }
    }
}
