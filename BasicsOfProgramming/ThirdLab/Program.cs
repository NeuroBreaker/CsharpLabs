using System;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Lab3Variant2 {

    class Program
    {
    
        static bool isRunning = true; // Глобальная переменная для главного цикла
    
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
        static double CalculateMethod()
        {
    
            const double PI = Math.PI;
            double a, b;
    
            Console.WriteLine("Задача:\nf = π(ln b^5 / sin(a) + 1)");
            a = DoubleParsing("Введите число a: ");
            b = DoubleParsing("Введите число b: ");
    
            double task2 = PI * (Math.Log(Math.Pow(b, 5)) / (Math.Sin(a) + 1)); // Решение для второго варианта
    
            if ((Math.Sin(a) + 1) == 0)
            {
                Console.WriteLine("Деление на ноль невозможно"); 
                Console.WriteLine("\nПопробуйте снова");
                Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
                Console.ReadKey();

                return CalculateMethod();
            }
            else
            {
                return Math.Round(task2, 2);
            }
        }

        static void GuessAnswer() 
        {
            Console.Clear();
    
            double answer = CalculateMethod();

            int i;
            for (i = 3; i > 0; i--) 
            {
                Console.WriteLine($"Количество попыток: {i}");
                double guess = DoubleParsing("Ваш ответ(с округлением до двух знаков после запятой): ");
                if (guess == answer)
                {
                    BoolHandler(true);
                    i = 0;
                }
                else
                {
                    BoolHandler(false);
                }
            }

            Console.WriteLine($"\nОтвет: {answer}");
            Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
            Console.ReadKey();
        }

        // Заполнение массива случайными значениями
        static int[] RandomArray(int[] array, int len)
        {
            
            Random rnd = new Random();
            for (int i = 0; i < len; i++)
            {
                int num = rnd.Next(-9, 9);
                array[i] = num;
            }

            return array;
        }

        // Вывод массива в консоль
        static void OutputArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write("{0} ", i);
            }
        }

        static TimeSpan BubbleSorting(int[] array, int len)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i + 1 < len; i++) {
                for (int j = 0; j + 1 < len; j++)
                {
                    if (array[j] > array[j+1])
                    {
                        int temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;
                    }
                    
                }
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan PasteSorting(int[array], int len)
        {

        }

        // Метод, который будет вызываться из меню
        static void CreateArray()
        {
            Console.Clear();

            Console.WriteLine("Добро пожаловать в метод сравнения сортировок массива");
            int arraySize = IntegerParsing("Выберите размер для массива: ");
            int[] array = new int[arraySize];

            RandomArray(array, arraySize);
            TimeSpan bubbleTime = BubbleSorting(array, arraySize);
            Console.WriteLine($"Время выполнения: {bubbleTime.TotalMilliseconds} миллисекунд");
            OutputArray(array);

            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
            Console.ReadKey();
        }

        static void AboutAuthor()
        {
            Console.Clear();
            Console.WriteLine("Сделал Рахматулин Родион");
            Console.WriteLine("группа 6105-090301D");
            Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
            Console.ReadKey();
        }
    
        static void Exit()
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
                    isRunning = false;
                    runnable = false;
                    Console.Clear();
                }
                else if (confirm == "н" || confirm == "n")
                {
                    Console.Clear();
                    runnable = false;
                }
                else
                {
                    Console.WriteLine("\nВведите либо y, либо n, либо д, либо н.");
                    Console.WriteLine("Другие варианты не примаются");

                    Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
                    Console.ReadKey();
                }
            }
        }
    
        static void Run()
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
                    CreateArray();
                    break;
    
                case "4":
                    Exit();
                    break;
    
                default:
                    Console.Clear();
                    Console.WriteLine("Соответствия не найдено");
                    Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
                    Console.ReadKey();
                    break;
            }
        }
    
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding  = Encoding.UTF8;
    
            while(isRunning)
            {
                Run();
            }
        }
    }
}
