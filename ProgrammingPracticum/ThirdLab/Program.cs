using System;

// Третья лабораторная работа для 3 варианта
namespace ThirdLabThirdVariant
{

    class Program
    {

        // Выводит message, ожидает Enter
        static void WaitEnter(string message = "Введите Enter для продолжения ...")
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }

        // Метод для продолжения
        static bool Continue(bool running, string message = "Хотите продолжить? [y/N]: ")
        {

            bool exit = false;

            while (!exit)
            {
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
        static bool Exit(bool running, string message = "Вы точно хотите выйти? [Y/n]: ")
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
            while(!int.TryParse(text, out result) || result <= 0m);

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
            while (!double.TryParse(text, out result) || result <= 0);

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

        // Вывод результата
        static void OutputResult(double[] values)
        {
            Console.WriteLine("╭── Результаты расчета ────────────────────╮");
            Console.WriteLine("│ Расход топлива:             {0, 10} л │", values[0]);
            Console.WriteLine("│ Стоимость топлива:        {0, 10} руб │", values[1]);
            Console.WriteLine("│ Транспортный коэффициент:    {0, 10}% │", values[2]);
            Console.WriteLine("│ Сезонный коэффициент:        {0, 10}% │", values[3]);
            Console.WriteLine("│ Итоговая стоимость:       {0, 10} руб │", values[4]);
            Console.WriteLine("╰──────────────────────────────────────────╯");
        }

        static void MoveElementsInArray(double element, double[] array)
        {
            for (int i = 0; i < History.Index - 1 && History.Index == 10; i--)
            {
                array[i] = array[i + 1];
            }

            array[History.Index] = element;
        }

        static void MoveElementsInArray(string element, string[] array)
        {
            for (int i = 0; i < History.Index - 1 && History.Index == 10; i--)
            {
                array[i] = array[i + 1];
            }

            array[History.Index] = element;
        }

        // Основной метод
        static void TravelCost()
        {
            bool isRunning = false;

            while (!isRunning) {
                Console.Clear();

                try {
                    double distance = DoubleParsing("Расстояние в км: ");
                    MoveElementsInArray(distance, History.distances);
                    
                    double averageFuelUsage = DoubleParsing("Средний расход топлива на 100км: ");
                    double pricePerLiter = DoubleParsing("Цена за литр: ");

                    double fuelUsage = Math.Round(distance * (averageFuelUsage / 100), 2);
                    double result = fuelUsage * pricePerLiter;

                    string transport;
                    double transportCoefficient = (double)ChoiceTransport(result);
                    if (transportCoefficient == 0)
                    {
                        transport = "Легковой";
                    }
                    else if (transportCoefficient == 20)
                    {
                        transport = "Грузовик";
                    }
                    else
                    {
                        transport = "Мотоцикл";
                    }
                    
                    MoveElementsInArray(transport, History.vehicleTypes);

                    string season;
                    double seasonCoefficient= (double)ChoiceSeason(result);
                    if (seasonCoefficient == 0)
                    {
                        season = "Лето";
                    }
                    else
                    {
                        season = "Зима";
                    }

                    MoveElementsInArray(season, History.seasons);

                    result *= (1 + transportCoefficient / 100);
                    result *= (1 + seasonCoefficient / 100);
                    result = Math.Round(result, 2);

                    MoveElementsInArray(result, History.totalCosts);
                    MoveElementsInArray(DateTime.Now.ToString("G"), History.dates);
                    double[] values = {fuelUsage, pricePerLiter, transportCoefficient, seasonCoefficient, result};

                    OutputResult(values);
                    if (History.Index < 10)
                    {
                        History.Index++;
                    }

                    isRunning = Continue(isRunning, "Хотите сделать еще один расчет? [y/N]: ");
                }
                catch (DivideByZeroException error) {
                    Console.WriteLine(error);
                }
                catch (OverflowException error)
                {
                    Console.WriteLine(error);
                }
                finally {
                    Console.WriteLine("Спасибо за использование калькулятора!");
                }
            }
        }

        // Отображение меню
        static void ShowMenu()
        {
            Console.WriteLine("╭── Калькулятор стоимости поездки ──╮");
            Console.WriteLine("│ 1. Рассчитать поездку             │");
            Console.WriteLine("│ 2. История                        │");
            Console.WriteLine("│ 3. Выйти                          │");
            Console.WriteLine("╰───────────────────────────────────╯");
            Console.Write("  Ваш выбор: ");
        }

        // Меню
        static bool Menu()
        {

            Console.Clear();
            ShowMenu();

            bool isRepeat = true;

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    TravelCost();
                    break;
                    
                case "2":
                    History.DrawHistory();
                    break;

                case "3":
                    isRepeat = Exit(isRepeat);
                    break;

                default:
                    break;
            }
            return isRepeat;
        }

        // Точка входа в программу
        static void Main(string[] args)
        {

            bool isRunning = true;
            while (isRunning)
            {
                isRunning = Menu();
            }
        }
    }
}
