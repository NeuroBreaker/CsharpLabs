using System;
using System.Text;

namespace Lab2Variant2 {

    class Program
    {
    
        static bool isRunning = true; // Глобальная переменная для главного цикла
    
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

        // Запрашивает ввод у пользователя и парсит его в int тип
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
            Console.WriteLine("3. Создание массива");
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
                Console.ReadKey();

                return CalculateMethod();
            }
            else
            {
                return task2;
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
                if (guess == Math.Round(answer, 2))
                {
                    BoolHandler(true);
                    i = 0;
                }
                else
                {
                    BoolHandler(false);
                }
            }

            Console.WriteLine($"\nОтвет: {Math.Round(answer, 2)}");
            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
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

        // Метод, который будет вызываться из меню
        static void ArraySorting()
        {

            Console.Clear();

            Console.WriteLine("Добро пожаловать в метод для создания массива");
            int arraySize = IntegerParsing("Введите размер для массива: ");
            int[] array = new int[arraySize];

            RandomArray(array, arraySize);
            OutputArray(array);

            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
            Console.ReadKey();
        }

        static void AboutAuthor()
        {
            Console.Clear();
            Console.WriteLine("Сделал Рахматулин Родион");
            Console.WriteLine("группа 6105-090301D");
            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
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

                    Console.WriteLine("\nНажмите Enter, чтобы вернуться к выбору ...");
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
                    ArraySorting();
                    break;
    
                case "4":
                    Exit();
                    break;
    
                default:
                    Console.Clear();
                    Console.WriteLine("Нет такого варианта\n");
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
