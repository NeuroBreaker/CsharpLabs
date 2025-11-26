using System;

// Третья лабораторная работа для 3 варианта
namespace ThirdLabThirdVariant
{

    class Program
    {

        static History History1 = new History();

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
        static string ChoiceTransport()
        {

            string transport = "Нету";

            bool continueLoop = true;
            while (continueLoop)
            {

                Console.WriteLine("Выберите транспорт");
                Console.WriteLine("1. Легковой");
                Console.WriteLine("2. Грузовик");
                Console.WriteLine("3. Мотоцикл");
                Console.Write("\nВаш выбор: ");

                string? choice = Console.ReadLine();
                switch (choice?.Trim()) {
                    case "1":
                        transport = "Легковой";
                        continueLoop = false;
                        break;

                    case "2":
                        transport = "Грузовик";
                        continueLoop = false;
                        break;

                    case "3":
                        transport = "Мотоцикл";
                        continueLoop = false;
                        break;

                    default:
                        Console.WriteLine("\nНеверный ввод, нажмите любую клавишу для продолжения ...");
                        Console.ReadKey();
                        break;
                }
            }

            return transport;
        }

        // Коэффициент сезона 
        static string ChoiceSeason()
        {

            string season = "Нету";

            bool isContinue = true;
            while (isContinue)
            {
                Console.WriteLine("Выберите сезон");
                Console.WriteLine("1. Лето");
                Console.WriteLine("2. Зима");
                Console.Write("\nВаш выбор: ");

                string? choice = Console.ReadLine();
                switch (choice?.Trim()) {
                    case "1":
                        season = "Лето";
                        isContinue = false;
                        break;

                    case "2":
                        season = "Зима";
                        isContinue = false;
                        break;

                    default:
                        Console.WriteLine("\nНеверный выбор, введите любую клавишу для продолжения ...");
                        Console.ReadKey();
                        break;
                }
            }

            return season;
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


        // Основной метод
        static void TravelCost()
        {
            bool isRunning = false;

            while (!isRunning) {
                Console.Clear();

                try {
                    double distance = DoubleParsing("Расстояние в км: ");
                    double averageFuelUsage = DoubleParsing("Средний расход топлива на 100км: ");
                    double pricePerLiter = DoubleParsing("Цена за литр: ");

                    double fuelUsage = Math.Round(distance * (averageFuelUsage / 100), 2);
                    double cost = fuelUsage * pricePerLiter;

                    string transport = ChoiceTransport();
                    double transportCoefficient = transport switch
                    {
                        "Легковой" => 0,
                        "Грузовик" => 20,
                        "Мотоцикл" => -15,
                        _ => 0
                    };

                    string season = ChoiceSeason();
                    double seasonCoefficient = season switch
                    {
                        "Лето" => 0,
                        "Зима" => 20,
                        _ => 0
                    };


                    cost *= (1 + transportCoefficient / 100);
                    cost *= (1 + seasonCoefficient / 100);
                    cost = Math.Round(cost, 2);

                    History1.AddRecord(distance, transport, season, cost, DateTime.Now);
                    
                    double[] values = {fuelUsage, pricePerLiter, transportCoefficient, seasonCoefficient, cost};

                    OutputResult(values);

                    isRunning = Continue(isRunning, "Хотите сделать еще один расчет? [y/N]: ");
                }
                catch (DivideByZeroException error) {
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
                    History1.Show();
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
