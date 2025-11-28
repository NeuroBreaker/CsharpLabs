using System;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Lab4Variant2
{

    class Program
    {
    
        // Запрашивает ввод у пользователя и парсит его в double тип
        static int IntegerParsing(string message)
        {
            int result;
            string? input;

            do {
                Console.Write(message);
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out result));

            return result;
        }

        // Запрашивает ввод у пользователя и парсит его в double тип
        static double DoubleParsing(string message)
        {
            double result;
            string? input;

            do {
                Console.Write(message);
                input = Console.ReadLine();
            }
            while (!double.TryParse(input, out result));

            return result;
        }

        // Выводит ✅/❌в консоль при передаче bool
        static void BoolHandler(bool boolean)
        {

            if (boolean)
            {
                Console.WriteLine("✅ Верно");
            }
            else 
            {
                Console.WriteLine("❌Неверно");
            }
        }
    
        // Часть кода из первой лабораторной работы
        static double CalculateMethod(double a, double b)
        {
            const double PI = Math.PI;

            double result = PI * (Math.Log(Math.Pow(b, 5)) / (Math.Sin(a) + 1)); // Решение для второго варианта

            return Math.Round(result, 2);
        }

        // Запрашивает ответ 3 раза, если
        // ответ верный, то цикл прервётся
        static void Guess(double result)
        {

            for (int i = 3; i > 0; i--) 
            {
                Console.WriteLine($"Количество попыток: {i}");
                double guess = DoubleParsing("Ваш ответ(с округлением до двух знаков после запятой): ");
                if (guess == result)
                {
                    BoolHandler(true);
                    i = 0;
                }
                else
                {
                    BoolHandler(false);
                }
            }
        }

        // Метод, вызываемый при выборе из меню
        static void GuessAnswer() 
        {
            Console.Clear();
    
            Console.WriteLine("Задача:\nf = π(ln b^5 / sin(a) + 1)");

            double a, b;

            a = DoubleParsing("Введите число a: ");
            b = DoubleParsing("Введите число b: ");

            if ((Math.Sin(a) + 1) == 0)
            {
                Console.WriteLine("Деление на ноль невозможно"); 
                Console.WriteLine("\nПопробуйте снова");
                Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
                Console.ReadKey();

                GuessAnswer();
            }

            double result = CalculateMethod(a, b);

            Guess(result);

            Console.WriteLine($"\nОтвет: {result}");
            Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
            Console.ReadKey();
        }

        // Об авторе (вызывается из меню)
        static void AboutAuthor()
        {
            Console.Clear();
            Console.WriteLine("Сделал Anon Anonovich");
            Console.WriteLine("группа ananisti");
            Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
            Console.ReadKey();
        }
    
        // Запрашивает размер массива, возвращает его
        static int InputArraySize()
        {
            int arraySize;
            do {
                arraySize = IntegerParsing("Выберите размер для массива: ");

                if (arraySize < 1)
                {
                    Console.WriteLine("Массив не может состоять из 0 и меньше элементов");
                }
            }
            while(arraySize < 1);

            return arraySize;
        }

        // Заполнение массива случайными значениями
        static int[] FillArray(int[] array)
        {
            
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int num = rnd.Next(-9, 9);
                array[i] = num;
            }

            return array;
        }

        // При вызове этого метода указывается размер создаваемого массива
        // После этого он заполняется методом FillArray
        static int[] ArrayInitialization(int size)
        {
            int[] array = new int[size];
            FillArray(array);

            return array;
        }

        // Возвращает клон передаваемого массива
        static int[] CloneArray(int[] array)
        {
            int size = array.Length;
            int[] cloneArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                cloneArray[i] = array[i];    
            }

            return cloneArray;
        }

        // Вывод массива в консоль
        static void OutputArray(int[] array)
        {
            int size = array.Length;
            if (size > 10)
            {
                Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массива больше 10");
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    Console.Write("{0} ", array[i]);
                }
                Console.WriteLine();
            }
        }

        // Создаёт клон передаваемого массива, сортирует его методом пузырька и после возвращает
        static int[] BubbleSorting(int[] array)
        {
            int size = array.Length;
            int[] sortingArray = CloneArray(array);
            for (int i = 0; i < size - 1; i++) {
                for (int j = 0; j < size - 1 - i; j++)
                {
                    if (sortingArray[j] > sortingArray[j+1])
                    {
                        int temp = sortingArray[j];
                        sortingArray[j] = sortingArray[j+1];
                        sortingArray[j+1] = temp;
                    }
                }
            }

            return sortingArray;
        }
        
        // Создаёт клон передаваемого массива, сортирует его методом вставок и после возвращает
        static int[] InsertSorting(int[] array)
        {
            int size = array.Length;
            int[] sortingArray = CloneArray(array);
            for (int i = 1; i < size; ++i)
            {
                int j = i - 1;
                int temp = sortingArray[i];
                while (j >= 0 && sortingArray[j] > temp)
                {
                    sortingArray[j + 1] = sortingArray[j];
                    --j;
                }
                sortingArray[j + 1] = temp;
            }

            return sortingArray;
        }

        // Метод, который будет вызываться из меню
        static void ArraysSorting()
        {
            Console.Clear();

            Console.WriteLine("Добро пожаловать в метод сравнения сортировок массива");

            int arraySize = InputArraySize();
            int[] array = ArrayInitialization(arraySize);

            Console.WriteLine("Неотсортированный массив:");
            OutputArray(array);

            Stopwatch stopwatchBubble = new Stopwatch();
            stopwatchBubble.Start();
            int[] bubbleSortingArray = BubbleSorting(array);
            stopwatchBubble.Stop();

            Console.WriteLine($"\nВремя выполнения сортировки пузырьком: {stopwatchBubble.ElapsedMilliseconds} миллисекунд");
            Console.WriteLine("Отсортированный массив:");
            OutputArray(bubbleSortingArray);

            Stopwatch stopwatchInsert = new Stopwatch();
            stopwatchInsert.Start();
            int[] insertSortingArray = InsertSorting(array);
            stopwatchInsert.Stop();

            Console.WriteLine($"\nВремя выполнения сортировки вставками: {stopwatchInsert.ElapsedMilliseconds} миллисекунд");
            Console.WriteLine("Отсортированный массив:");
            OutputArray(insertSortingArray);

            if (stopwatchInsert.ElapsedMilliseconds > stopwatchBubble.ElapsedMilliseconds)
            {
                var difference = stopwatchInsert.ElapsedMilliseconds - stopwatchBubble.ElapsedMilliseconds;
                Console.WriteLine($"\nАлгоритм сортировки пузырьком оказался быстрее на {difference} миллисекунд");
            }
            else
            {
                var difference = stopwatchBubble.ElapsedMilliseconds - stopwatchInsert.ElapsedMilliseconds;
                Console.WriteLine($"\nАлгоритм сортировки вставками оказался быстрее на {difference} миллисекунд");
            }


            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
            Console.ReadKey();
        }

        // Метод для получения цвета
        static ConsoleColor GetColor(int colorNum)
        {
            switch (colorNum)
            {
                case 1: return ConsoleColor.Cyan;
                case 2: return ConsoleColor.Yellow;
                case 3: return ConsoleColor.Magenta;
                case 4: return ConsoleColor.Green;
                case 5: return ConsoleColor.Red;
                case 6: return ConsoleColor.Blue;
                case 7: return ConsoleColor.DarkYellow;
                default: return ConsoleColor.White;
            }
        }

        static void SpawnShape()
        {

        }

        // Метод для отрисовки
        static void Draw(int[,] board)
        {
            int[,] drawBoard = (int[,])board.Clone();

            // Добавляем текущую фигуру
            // for (int row = 0; row < currentPiece.GetLength(0); row++)
            // {
            //     for (int col = 0; col < currentPiece.GetLength(1); col++)
            //     {
            //         if (currentPiece[row, col] == 1)
            //         {
            //             int y = currentY + row;
            //             int x = currentX + col;
            //             if (y >= 0 && y < BoardHeight && x >= 0 && x < BoardWidth)
            //             {
            //                 displayBoard[y, x] = currentColor;
            //             }
            //         }
            //     }
            // }

            
            // Рисуем верхнюю границу
            Console.Write("╔");
            for (int i = 0; i < board.GetLength(1) * 2; i++) Console.Write("═");
            Console.WriteLine("╗");
            
            // Рисуем поле
            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.Write("║");
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    int cell = drawBoard[row, col];
                    if (cell == 0)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.ForegroundColor = GetColor(cell);
                        Console.Write("██");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine("║");
            }

            // Рисуем нижнюю границу
            Console.Write("╚");
            for (int i = 0; i < board.GetLength(1) * 2; i++) Console.Write("═");
            Console.WriteLine("╝");
        }

        // Метод, вызываемый из меню (точка входа всех методов для тетриса)
        static void Tetris()
        {

            Console.Clear();

            const int HEIGHT = 20;
            const int WIDTH = 10;
            int[,] board = new int[HEIGHT, WIDTH];
            int[,] shape = { {1, 1}, {1, 1} };
            int[,] shapeT = { {0, 1, 0}, {1, 1, 1} };
            Console.WriteLine(shapeT.GetLength(0));
            Console.WriteLine(shapeT.GetLength(1));

            while(true)
            {
                Console.Clear();
                Draw(board);
                Thread.Sleep(1000);
            }
        }

        // Спрашивает хотите ли выйти до того момента
        // пока не введёте
        // y / Y / n / N / Enter(ничего)
        static bool Exit()
        {
            bool runnable = true;
    
            while (runnable)
            {
                Console.Clear();
                Console.Write("Вы действительно хотите выйти? [Y/n]: ");
                string? confirm = Console.ReadLine()?.ToLower();
    
                if (confirm == "д" || confirm == "y"
                        || confirm == "" )
                {
                    runnable = false;
                    Console.Clear();
                    return true;
                }
                else if (confirm == "н" || confirm == "n")
                {
                    runnable = false;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("\nВведите либо Enter, либо y, либо n, либо д, либо н.");
                    Console.WriteLine("Другие варианты не примаются");

                    Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
                    Console.ReadKey();
                }
            }
            return false;
        }
    
        // Вывод меню в консоль
        static void ShowMenu() 
        {
            Console.Clear();
            Console.WriteLine("1. Отгадай ответ");
            Console.WriteLine("2. Об авторе");
            Console.WriteLine("3. Сортировка массива");
            Console.WriteLine("4. Тетрис");
            Console.WriteLine("5. Выход");
            Console.Write("Ваш выбор: ");
        }

        // Меню с выбором
        static bool Menu()
        {
            ShowMenu();
    
            string? choice = Console.ReadLine(); 
    
            switch (choice)
            {
                case "1":
                    GuessAnswer();
                    break;
    
                case "2":
                    AboutAuthor();
                    break;

                case "3":
                    ArraysSorting();
                    break;
    
                case "4":
                    Tetris();
                    break;

                case "5":
                    return Exit();
    
                default:
                    Console.Clear();
                    Console.WriteLine("Соответствия не найдено");
                    Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
                    Console.ReadKey();
                    break;
            }

            return false;
        }
    
        // Точка входа в программу
        // запускает цикл с меню
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding  = Encoding.UTF8;
    
            bool isExit = false;
            while(!isExit)
            {
                isExit = Menu();
            }
        }
    }
}
