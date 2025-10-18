using System;
using System.Text;

namespace Lab2Variant2 {

    class Program
    {
    
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

        // Принимает true или false, на основе них выдаёт сообщение
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

        // Отображает меню выбора
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
        static double CalculateMethod(double a, double b)
        {
            const double PI = Math.PI;

            double result = PI * (Math.Log(Math.Pow(b, 5)) / (Math.Sin(a) + 1)); // Решение для второго варианта

            return Math.Round(result, 2);
        }

        // Метод для сравнения ввода пользователя и верного результата
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

        // Метод вызываемый после меню 
        // (генерация мат. задачи на основе ввода пользователя, попытки пользователя угадать ответ 3 раза)
        static void GuessAnswer() 
        {
            Console.Clear();
    
            Console.WriteLine("Задача:\nf = π(ln b^5 / sin(a) + 1)");

            double a = DoubleParsing("Введите число a: ");
            double b = DoubleParsing("Введите число b: ");

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

        // Генерация задачи
        static double GenerateTask()
        {
            Random random = new Random();
            
            int num1 = random.Next(1, 10); 
            int num2 = random.Next(1, 10); 
            int operation = random.Next(1, 5);

            double result;

            switch (operation)
            {
                case 1: 
                    Console.WriteLine($"Решите задачу: {num1} + {num2}");
                    result = num1 + num2;
                    return result;

                case 2:
                    Console.WriteLine($"Решите задачу: {num1} - {num2}");
                    result = num1 - num2;
                    return result;

                case 3:
                    Console.WriteLine($"Решите задачу: {num1} * {num2}");
                    result = num1 * num2;
                    return result;

                case 4:
                    Console.WriteLine($"Решите задачу: {num1} / {num2}");
                    result = Math.Round((double)num1 / (double)num2, 2);
                    return result;
            }
            return 0;
        }

        // Решение случайных задач
        static void SolveSimpleTasks()
        {
            int result = 0;
            double correctValue;

            Console.Clear();
            for (int i = 0; i < 3; ++i)
            {
                correctValue = GenerateTask();
                double guess = DoubleParsing("Ваш ответ(с округлением до двух знаков после .): ");
                BoolHandler(guess == correctValue);

                if (guess == correctValue)
                {
                    result += 1;
                }

                Console.WriteLine($"Правильный ответ: {correctValue}\n");
            }

            Console.WriteLine($"Количество правильных ответов: {result}");
            Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
            Console.ReadKey();
        }

        static void AboutAuthor()
        {
            Console.Clear();
            Console.WriteLine("Сделал anon anonovich");
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
                    SolveSimpleTasks();
                    return false;

                case "3":
                    AboutAuthor();
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
