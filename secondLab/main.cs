using System;
using System.Text;

namespace Lab2Variant2 {

    class Program
    {
    
        static bool isRunning = true;
    
        static double DoubleParsing(string message)
        {
            double n;

            Console.WriteLine(message);
            while (!double.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine(message);
            }
    
            return n;
        }

        static double FirstLab()
        {
    
            const double PI = Math.PI;
            double a, b;
    
            a = DoubleParsing("Введите число a: ");
            b = DoubleParsing("Введите число b: ");
    
            double task2 = PI * (Math.Log(Math.Pow(b, 5)) / (Math.Sin(a) + 1)); // Решение для второго варианта
    
            if ((Math.Sin(a) + 1) == 0)
            {
                Console.WriteLine("Деление на ноль невозможно"); 
            }
            else
            {
                Console.WriteLine($"\nОтвет: {Math.Round(task2, 2)}");
            }
    
            return task2;
        }
    
        static void ShowMenu() 
        {
            Console.Clear();
            Console.WriteLine("1. Отгадай ответ");
            Console.WriteLine("2. Об авторе");
            Console.WriteLine("3. Выход");
            Console.Write("Ваш выбор: ");
        }
    
        static void GuessAnswer() 
        {
            Console.Clear();
            Console.WriteLine("Решите\nf = π(ln b^5 / sin(a) + 1)");
            Console.Write("Ваш ответ(с округлением до двух знаков после запятой): ");
    
            double guess = DoubleParsing("");
            double answer = FirstLab();
    
            if (guess == answer)
            {
                Console.WriteLine("Абсолютно верно!");
            }
            else
            {
                Console.WriteLine("Вы не угадали:(");
            }
    
            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
            Console.ReadLine();
        }
    
        static void AboutAuthor()
        {
            Console.Clear();
            Console.WriteLine("Сделал Рахматулин Родион");
            Console.WriteLine("6105-090301D группа\n");
            Console.WriteLine("Нажмите Enter, чтобы вернуться в меню...");
            Console.ReadLine();
        }
    
        static void Exit()
        {
            bool runnable = true;
    
            while (runnable)
            {
                Console.Clear();
                Console.Write("Вы действительно хотите выйти? [Y/n]: ");
                string confirm = Console.ReadLine()?.ToLower();
    
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
                    Console.WriteLine("Принимаются только символы 'д' и 'н'");
                }
            }
        }
    
        static void Run()
        {
            ShowMenu();
    
            string choice = Console.ReadLine(); 
    
            switch (choice)
            {
                case "1":
                    GuessAnswer();
                    break;
    
                case "2":
                    AboutAuthor();
                    break;
    
                case "3":
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
