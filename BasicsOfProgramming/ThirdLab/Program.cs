using System;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Lab3Variant2 {

    class Program
    {
    
        static int IntegerParsing(string message)
        {
            int result;

            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write(message);
            }

            return result;
        }

        // Запрашивает ввод у пользователя и парсит его в double тип
        static double DoubleParsing(string message)
        {
            double result;

            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.Write(message);
            }
    
            return result;
        }

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

        static void ShowMenu() 
        {
            Console.Clear();
            Console.WriteLine("1. Отгадай ответ");
            Console.WriteLine("2. Об авторе");
            Console.WriteLine("3. Сортировка массива");
            Console.WriteLine("4. Выход");
            Console.Write("Ваш выбор: ");
        }
    
        // Часть кода из первой лабораторной работы
        static double CalculateMethod(double a, double b)
        {
            const double PI = Math.PI;

            double result = PI * (Math.Log(Math.Pow(b, 5)) / (Math.Sin(a) + 1)); // Решение для второго варианта

            return Math.Round(result, 2);
        }

        static void Guess(double result)
        {
            int i;
            for (i = 3; i > 0; i--) 
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

        // Угадайка
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

        // Ввод размера массива
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

        static int[] ArrayInitialization(int size)
        {
            int[] array = new int[size];
            FillArray(array);

            return array;
        }

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

        static void AboutAuthor()
        {
            Console.Clear();
            Console.WriteLine("Сделал Anon Anonovich");
            Console.WriteLine("группа ananisti");
            Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
            Console.ReadKey();
        }
    
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
    
        static bool Run()
        {
            ShowMenu();
    
            string? choice = Console.ReadLine(); 
    
            switch (choice)
            {
                case "1":
                    GuessAnswer();
                    return false;
    
                case "2":
                    AboutAuthor();
                    return false;

                case "3":
                    ArraysSorting();
                    return false;
    
                case "4":
                    return Exit();
    
                default:
                    Console.Clear();
                    Console.WriteLine("Соответствия не найдено");
                    Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
                    Console.ReadKey();
                    return false;
            }
        }
    
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding  = Encoding.UTF8;
    
            bool isExit = false;
            while(!isExit)
            {
                isExit = Run();
            }
        }
    }
}
