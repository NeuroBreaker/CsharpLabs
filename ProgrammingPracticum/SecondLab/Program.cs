using System;

// Лабораторная работа для 3 варианта
namespace SecondLabThirdVariant
{

    class Program
    {

        static double DoubleParsing(string message)
        {
            double result = 0;
            string? text;

            do {

                Console.Write(message);
                text = Console.ReadLine();
            }
            while (!double.TryParse(text, out result));

            return result;
        }

        // Вариант 3
        static void TravelCost()
        {
            Console.Clear();

            try {
                double distance = DoubleParsing("Расстояние в км: ");
                double averageFuelUsage = DoubleParsing("Средний расход топлива на 100км: ");
                double pricePerLiter = DoubleParsing("Цена за литр: ");

                double fuelUsage = distance * (averageFuelUsage / 100);
                double result = fuelUsage * pricePerLiter;

                Console.WriteLine($"Цена поездки обойдётся в {result}");

                Console.WriteLine("\nНажмите любую клавишу для продолжения ... ");
                Console.ReadKey();
            }
            catch(DivideByZeroException) {

            }
            finally {
                Console.WriteLine("Спасибо за использование калькулятора!");
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("=== Калькулятор стоимости поездки ===");
            Console.WriteLine("1. Рассчитать поездку");
            Console.WriteLine("2. Выйти");
            Console.Write("\nВаш выбор: ");
        }

        static bool Exit(bool running)
        {

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.Write("Вы точно хотите выйти? [Y/n]: ");
                string? confirm = Console.ReadLine()?.ToLower();

                if (confirm == "" || confirm == "y")
                {
                    running = false;
                    exit = true; 
                }
                else if (confirm == "n")
                {
                    exit = true;
                }
                else
                {
                    
                }
            }
            return running;
        }

        static bool Menu(bool isRun)
        {
            Console.Clear();
            ShowMenu();

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    break;
                    
                case "2":
                    return Exit(isRun);

                default:
                    break;
            }
            return true;
        }

        static void Main(string[] args)
        {
            
            bool isRunning = true;

            while (isRunning)
            {
                isRunning = Menu(isRunning);
            }
        }
    }
}
