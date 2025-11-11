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
            Console.WriteLine("=== Результаты расчета ===");
            Console.WriteLine("Расход топлива: {0} л", values[0]);
            Console.WriteLine("Стоимость топлива: {0} руб", values[1]);
            Console.WriteLine("Транспортный коэффициент: {0}%", values[2]);
            Console.WriteLine("Сезонный коэффициент: {0}%", values[3]);
            Console.WriteLine("Итоговая стоимость: {0} руб", values[4]);
        }

        static void MoveElementsInDoubleArray(double element, double[] array)
        {
            int size = array.Length;
            for (int i = size - 2; i >= 0; i--)
            {
                array[i + 1] = array[i];
            }

            array[0] = element;
        }

        static void MoveElementsInStringArray(string element, string[] array)
        {
            int size = array.Length;
            for (int i = size - 2; i >= 0; i--)
            {
                array[i + 1] = array[i];
            }

            array[0] = element;
        }

        static void ViewHistory(in int index, double[] distances, string[] vehicleTypes, string[] seasons, double[] totalCosts, string[] dates)
        {
            Console.Clear();
            if (index == 0) 
            {
                Console.WriteLine("Вы не использовали калькулятор до этого");
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    Console.Write($"{i + 1}\t");
                    Console.Write($"{distances[i]}\t");
                    Console.Write($"{vehicleTypes[i]}\t");
                    Console.Write($"{seasons[i]}\t");
                    Console.Write($"{totalCosts[i]}\t");
                    Console.WriteLine($"{dates[i]}");
                }
            }
            WaitEnter();
        }

        // Основной метод
        static void TravelCost(ref int index, double[] distances, string[] vehicleTypes, string[] seasons, double[] totalCosts, string[] dates)
        {
            bool isRunning = false;

            while (!isRunning) {
                Console.Clear();

                try {
                    double distance = DoubleParsing("Расстояние в км: ");
                    MoveElementsInDoubleArray(distance, distances);
                    
                    double averageFuelUsage = DoubleParsing("Средний расход топлива на 100км: ");
                    double pricePerLiter = DoubleParsing("Цена за литр: ");

                    double fuelUsage = distance * (averageFuelUsage / 100);
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
                    
                    MoveElementsInStringArray(transport, vehicleTypes);

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

                    MoveElementsInStringArray(season, seasons);

                    result *= (1 + transportCoefficient / 100);
                    result *= (1 + seasonCoefficient / 100);

                    MoveElementsInDoubleArray(result, totalCosts);
                    MoveElementsInStringArray(DateTime.Now.ToString("G"), dates);
                    double[] values = {fuelUsage, pricePerLiter, transportCoefficient, seasonCoefficient, result};

                    OutputResult(values);
                    index++;

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
            Console.WriteLine("=== Калькулятор стоимости поездки ===");
            Console.WriteLine("1. Рассчитать поездку");
            Console.WriteLine("2. История");
            Console.WriteLine("3. Выйти");
            Console.Write("\nВаш выбор: ");
        }

        // Меню
        static bool Menu(ref int index, double[] distances, string[] vehicleTypes, string[] seasons, double[] totalCosts, string[] dates)
        {

            Console.Clear();
            ShowMenu();

            bool isRepeat = true;

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    TravelCost(ref index, distances, vehicleTypes, seasons, totalCosts, dates);
                    break;
                    
                case "2":
                    ViewHistory(index, distances, vehicleTypes, seasons, totalCosts, dates);
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
            double[] distances = new double[10];
            string[] vehicleTypes = new string[10];
            string[] seasons = new string[10];
            double[] totalCosts = new double[10];
            string[] dates = new string[10];
            int index = 0;

            bool isRunning = true;
            while (isRunning)
            {
                isRunning = Menu(ref index, distances, vehicleTypes, seasons, totalCosts, dates);
            }
        }
    }
}
