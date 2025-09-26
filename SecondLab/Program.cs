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
            Console.WriteLine("2. Простые математические задачки");
            Console.WriteLine("3. Об авторе");
            Console.WriteLine("4. Выход");
            Console.Write("Ваш выбор: ");
        }
    
        // Часть кода из первой лабораторной работы
        static double FirstLab()
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

                return FirstLab();
            }
            else
            {
                return task2;
            }
        }

        static void GuessAnswer() 
        {
            Console.Clear();
    
            double answer = FirstLab();

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

            Console.WriteLine($"\nОтвет: {Math.Round(answer, 2)}");
            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
            Console.ReadKey();
        }

        // Генерация задачи
        static void GenerateTask(out double result)
        {
            Random rand1 = new Random();
            Random rand2 = new Random();
            Random rand3 = new Random();
            
            int num1 = rand1.Next(1, 10); 
            int num2 = rand2.Next(1, 10); 
            int num3 = rand3.Next(1, 5);

            result = 0;

            switch (num3)
            {
                case 1: 
                    Console.WriteLine($"Решите задачу: {num1} + {num2}");
                    result = num1 + num2;
                    break;

                case 2:
                    Console.WriteLine($"Решите задачу: {num1} - {num2}");
                    result = num1 - num2;
                    break;

                case 3:
                    Console.WriteLine($"Решите задачу: {num1} * {num2}");
                    result = num1 * num2;
                    break;

                case 4:
                    Console.WriteLine($"Решите задачу: {num1} / {num2}");
                    result = Math.Round((double)num1 / num2, 2);
                    break;
            }
        }

        static void SolveSimpleTasks()
        {
            int result = 0;
            double answer;

            Console.Clear();
            for (int i = 0; i < 3; ++i)
            {
                GenerateTask(out answer);
                double guess = DoubleParsing("Ваш ответ(с округлением до двух знаков после .): ");
                BoolHandler(answer == guess);

                if (answer == guess)
                {
                    result += 1;
                }

                Console.WriteLine($"Правильный ответ: {answer}\n");
            }

            Console.WriteLine($"Количество правильных ответов: {result}");
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
                    SolveSimpleTasks();
                    break;

                case "3":
                    AboutAuthor();
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
