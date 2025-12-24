using System;

using ThirdLab.Utils;
using ThirdLab.HistoryClass;

// 3 variant
namespace ThirdLab
{

    class Program
    {

        static History History1 = new History();

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

        static void PrintInfo(double[] values)
        {
            Console.WriteLine("╭── Результаты расчета ────────────────────╮");
            Console.WriteLine("│ Расход топлива:             {0, 10} л │", values[0]);
            Console.WriteLine("│ Стоимость топлива:        {0, 10} руб │", values[1]);
            Console.WriteLine("│ Транспортный коэффициент:    {0, 10}% │", values[2]);
            Console.WriteLine("│ Сезонный коэффициент:        {0, 10}% │", values[3]);
            Console.WriteLine("│ Итоговая стоимость:       {0, 10} руб │", values[4]);
            Console.WriteLine("╰──────────────────────────────────────────╯");
        }

        static double CalculateFuelConsumption(double distance, double averageFuelUsage)
        {
            return Math.Round(distance * (averageFuelUsage / 100), 2);
        }

        static double ApplyCoefficient(double cost, double coefficient)
        {
            cost *= (1 + coefficient / 100);
            return cost;
        }

        static void CalculateCost()
        {
            bool isRunning = false;

            while (!isRunning) {
                Console.Clear();

                try {
                    double distance = InputHandler.DoubleParsing("Расстояние в км: ");
                    double averageFuelUsage = InputHandler.DoubleParsing("Средний расход топлива на 100км: ");
                    double pricePerLiter = InputHandler.DoubleParsing("Цена за литр: ");

                    double fuelConsumption = CalculateFuelConsumption(distance, averageFuelUsage);
                    double cost = fuelConsumption * pricePerLiter;

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


                    cost = ApplyCoefficient(cost, transportCoefficient);
                    cost = ApplyCoefficient(cost, seasonCoefficient);
                    cost = Math.Round(cost, 2);

                    History1.AddRecord(distance, transport, season, cost, DateTime.Now);

                    History1.AverageCostSum += (averageFuelUsage / 100) * pricePerLiter;
                    
                    double[] values = {fuelConsumption, pricePerLiter, transportCoefficient, seasonCoefficient, cost};

                    PrintInfo(values);

                    isRunning = InputHandler.Continue(isRunning, "Хотите сделать еще один расчет? [y/N]: ");
                }
                catch (DivideByZeroException error) {
                    Console.WriteLine(error);
                }
                finally {
                    Console.WriteLine("Спасибо за использование калькулятора!");
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("╭── Калькулятор стоимости поездки ──╮");
            Console.WriteLine("│ 1. Рассчитать поездку             │");
            Console.WriteLine("│ 2. История                        │");
            Console.WriteLine("│ 3. Анализ поездок                 │");
            Console.WriteLine("│ 4. Выйти                          │");
            Console.WriteLine("╰───────────────────────────────────╯");
            Console.Write("  Ваш выбор: ");
        }

        static bool Menu()
        {

            Console.Clear();
            ShowMenu();

            bool isRepeat = true;

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CalculateCost();
                    break;
                    
                case "2":
                    History1.Show();
                    break;

                case "3":
                    History1.TravelAnalysis();
                    break;

                case "4":
                    isRepeat = InputHandler.Exit(isRepeat);
                    break;

                default:
                    break;
            }
            return isRepeat;
        }

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
