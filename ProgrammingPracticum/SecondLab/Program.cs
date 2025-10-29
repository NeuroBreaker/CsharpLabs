using System;

// Лабораторная работа для 3 варианта
namespace SecondLabThirdVariant
{

    class Program
    {
        // Будет отправлять повторно message, пока не запарсит вводимое число
        static int IntegerParsing(string message)
        {
            string? text;
            int result = 0;
            
            do {
                Console.WriteLine(message);
                text = Console.ReadLine();
            }
            while(!int.TryParse(text, out result));

            return result;
        }

        // Будет отправлять повторно message, пока не запарсит вводимое число
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

        // Коэффициент траснпорта
        static double ChoiceTransport(double result)
        {
            Console.WriteLine("Выберите транспорт");
            Console.WriteLine("1. Легковой");
            Console.WriteLine("2. Грузовик");
            Console.WriteLine("3. Мотоцикл");
            Console.Write("\nВаш выбор: ");

            string? choice = Console.ReadLine();
            switch (choice) {
                case "1":
                    break;

                case "2":
                    result *= 1.2;
                    Console.WriteLine("Транспортный коэффициент: +20%");
                    break;

                case "3":
                    result *= 0.85;
                    Console.WriteLine("Транспортный коэффициент: -15%");
                    break;

                default:
                    break;
            }

            return result;
        }

        // Коэффициент сезона 
        static double ChoiceSeason(double result)
        {

            Console.WriteLine("Выберите сезон");
            Console.WriteLine("1. Лето");
            Console.WriteLine("2. Зима");
            Console.Write("\nВаш выбор: ");

            string? choice = Console.ReadLine();
            switch (choice) {
                case "1":
                    break;

                case "2":
                    result *= 1.2;
                    Console.WriteLine("Сезонный коэффициент: +20%");
                    break;

                default:
                    Console.WriteLine("Введите 1 или 2");
                    result = ChoiceSeason(result);
                    break;
            }

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

                result = ChoiceTransport(result);
                result = ChoiceSeason(result);

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

        static bool Exit(bool running, string message)
        {

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.Write(message);
                string? confirm = Console.ReadLine()?.ToLower();

                if (confirm == "y")
                {
                    running = false;
                    exit = true; 
                }
                else if (confirm == "n")
                {
                    exit = true;
                }
            }
            return running;
        }

        static void ShowMenu()
        {
            Console.WriteLine("=== Калькулятор стоимости поездки ===");
            Console.WriteLine("1. Рассчитать поездку");
            Console.WriteLine("2. Выйти");
            Console.Write("\nВаш выбор: ");
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
                    return Exit(isRun, "Вы точно хотите выйти? [y/n]: ");

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
