using System;

// Лабораторная работа для 3 варианта
namespace SecondLabThirdVariant
{

    class Program
    {

        // Метод для продолжения
        static bool Continue(bool running, string message)
        {

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.Write(message);
                string? confirm = Console.ReadLine()?.ToLower();

                if (confirm == "y")
                {
                    exit = true; 
                }
                else if (confirm == "" || confirm == "n")
                {
                    running = !running;
                    exit = true;
                }
            }
            return running;
        }

        // Метод для выхода
        static bool Exit(bool running, string message)
        {

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.Write(message);
                string? confirm = Console.ReadLine()?.ToLower();

                if (confirm == "" || confirm == "y")
                {
                    running = !running;
                    exit = true; 
                }
                else if (confirm == "n")
                {
                    exit = true;
                }
            }
            return running;
        }

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
        static int ChoiceTransport(double result)
        {
            Console.WriteLine("Выберите транспорт");
            Console.WriteLine("1. Легковой");
            Console.WriteLine("2. Грузовик");
            Console.WriteLine("3. Мотоцикл");
            Console.Write("\nВаш выбор: ");

            int coefficient;
            string? choice = Console.ReadLine();
            switch (choice) {
                case "1":
                    coefficient = 0;
                    break;

                case "2":
                    coefficient = 20;
                    break;

                case "3":
                    coefficient = -15;
                    break;

                default:
                    Console.WriteLine("Введите 1 или 2");
                    coefficient = ChoiceTransport(result);
                    break;
            }

            return coefficient;
        }

        // Коэффициент сезона 
        static int ChoiceSeason(double result)
        {

            Console.WriteLine("Выберите сезон");
            Console.WriteLine("1. Лето");
            Console.WriteLine("2. Зима");
            Console.Write("\nВаш выбор: ");

            int coefficient;
            string? choice = Console.ReadLine();
            switch (choice) {
                case "1":
                    coefficient = 0;
                    break;

                case "2":
                    coefficient = 20;
                    break;

                default:
                    Console.WriteLine("Введите 1 или 2");
                    coefficient = ChoiceSeason(result);
                    break;
            }

            return coefficient;
        }

        static void OutputResult(double[] values)
        {
            Console.WriteLine("=== Результаты расчета ===");
            Console.WriteLine("Расход топлива: {0} л", values[0]);
            Console.WriteLine("Стоимость топлива: {0} руб", values[1]);
            Console.WriteLine("Транспортный коэффициент: {0}%", values[2]);
            Console.WriteLine("Сезонный коэффициент: {0}%", values[3]);
            Console.WriteLine("Итоговая стоимость: {0} руб", values[4]);
        }

        // Вариант 3
        static void TravelCost()
        {
            bool isExit = false;

            while (!isExit) {
                Console.Clear();

                try {
                    double distance = DoubleParsing("Расстояние в км: ");
                    double averageFuelUsage = DoubleParsing("Средний расход топлива на 100км: ");
                    double pricePerLiter = DoubleParsing("Цена за литр: ");

                    double fuelUsage = distance * (averageFuelUsage / 100);
                    double result = fuelUsage * pricePerLiter;

                    double transportCoefficient = (double)ChoiceTransport(result);
                    double seasonCoefficient= (double)ChoiceSeason(result);

                    result *= (1 + transportCoefficient / 100);
                    result *= (1 + seasonCoefficient / 100);

                    double[] values = {fuelUsage, pricePerLiter, transportCoefficient, seasonCoefficient, result};

                    OutputResult(values);

                    isExit = Continue(isExit, "Хотите сделать еще один расчет? [y/N]: ");
                }
                catch(DivideByZeroException) {

                }
                finally {
                    Console.WriteLine("Спасибо за использование калькулятора!");
                }
            }
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
                    TravelCost();
                    break;
                    
                case "2":
                    return Exit(isRun, "Вы точно хотите выйти? [Y/n]: ");

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
