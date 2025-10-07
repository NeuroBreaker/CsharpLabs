using System;

namespace SecondLabOfPracticum
{

    class Program
    {

        static double DoubleParsing(string message)
        {
            double result = 0;

            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.Write(message);
            }

            return result;
        }

        // Вариант 1
        static void GuardSalary()
        {

            bool isRun = true;
            while (isRun)
            {
                Console.Clear();

                double perDay = DoubleParsing("Введите ваш оклад за один день: ");
                double workingDays = DoubleParsing("Введите количество отработанных дней: ");
                double workingNights = DoubleParsing("Введите количество ночных смен: ");
                double overtime = DoubleParsing("Введите количество отработанных сверхурочных часов: ");

                double finnalySalary = 0;

                workingDays -= workingNights;
                finnalySalary += workingDays * perDay;
                finnalySalary += workingNights * (perDay * 1.2);
                finnalySalary += overtime * 300;
                // Налог
                finnalySalary *= 0.83;

                Console.WriteLine($"Ваша итоговая зарплата: {finnalySalary}");

                Exit(ref isRun, "\nВыйти? [Y/n]: ");
            }
        }

        // Вариант 2
        static void CreditCalculator()
        {
            bool isRun = true;
            while (isRun)
            {
                Console.Clear();

                double summ = DoubleParsing("Сумма кредита: ");
                double perYear= DoubleParsing("Годовая процентная ставка: ");
                double years = DoubleParsing("На сколько лет: ");

                double result = summ * (1 + (perYear * years) / 100);

                Console.WriteLine("Вам придётся выплатить {0}", result);

                Exit(ref isRun, "\nВыйти? [Y/n]: ");
            }
        }

        // Вариант 3
        static void TravelCost()
        {
            bool isRun = true;
            while (isRun)
            {
                Console.Clear();

                double distance = DoubleParsing("Расстояние в км: ");
                double averageFuelUsage = DoubleParsing("Средний расход топлива на 100км: ");
                double pricePerLiter = DoubleParsing("Цена за литр: ");

                double fuelUsage = distance * (averageFuelUsage / 100);
                double result = fuelUsage * pricePerLiter;

                Console.WriteLine($"Цена поездки обойдётся в {result}");

                Exit(ref isRun, "\nВыйти? [Y/n]: ");
            }
        }

        // Вариант 4
        static void IndexOfMass()
        {
            bool isRun = true;
            while (isRun)
            {
                Console.Clear();
                
                double mass = DoubleParsing("Введите ваш вес: ");
                double height = DoubleParsing("Введите ваш рост(в метрах): ");

                double result = mass / (height * height);

                if (result < 18.5)
                {
                    Console.WriteLine("У вас недовес :(");
                }
                else if (result < 29.5)
                {
                    Console.WriteLine("Нормальный вес:)");
                }
                else
                {
                    Console.WriteLine("У вас ожирение :(");
                }
                
                Console.WriteLine("Ваш индекс тела: {0}", result);

                Exit(ref isRun, "\nВыйти? [Y/n]: ");
            }
        }

        // Вариант 5
        static void MunicipalServices()
        {
            bool isRun = true;
            while (isRun)
            {
                Console.Clear();

                const int perWater = 4;
                const int perGas = 14;
                const int perEnergy = 4;


                double waterUsing = DoubleParsing("Расход воды(кВт/ч): ");
                double gasUsing = DoubleParsing("Расход газа(кВт/ч): ");
                double energyUsing = DoubleParsing("Расход электроэнергии(кВт/ч): ");

                double waterPrice = perWater * waterUsing; 
                double gasPrice = (perGas * gasUsing) / 100; 
                double energyPrice = perEnergy * energyUsing; 

                Console.WriteLine("\nЦена за воду: {0}", waterPrice);
                Console.WriteLine("Цена за газ: {0}", gasPrice);
                Console.WriteLine("Цена за электроэнергию: {0}", energyPrice);

                Exit(ref isRun, "\nВыйти? [Y/n]: ");
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("Добро пожаловать в консольное приложение 💫\n");
            Console.WriteLine("1. Зарплата охранника");
            Console.WriteLine("2. Калькулятор кредита");
            Console.WriteLine("3. Цена поездки");
            Console.WriteLine("4. Индекс массы тела");
            Console.WriteLine("5. Коммунальные услуги");
            Console.WriteLine("6. Выход");
            Console.Write("\nВаш выбор: ");
        }

        static void Exit(ref bool boolean, string message)
        {

            bool exit = false;

            while (!exit)
            {
                Console.Write(message);
                string? confirm = Console.ReadLine();

                if (confirm == "" || confirm == "y")
                {
                    boolean = false;
                    exit = true; 
                }
                else if (confirm == "n")
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Совпадений не найдено");
                    Console.WriteLine("\nНажмите любую клавишу для продолжения ... ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void Menu(ref bool isRun)
        {
            Console.Clear();

            ShowMenu();

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    GuardSalary();
                    break;

                case "2":
                    CreditCalculator();
                    break;

                case "3":
                    TravelCost();
                    break;

                case "4":
                    IndexOfMass();
                    break;

                case "5":
                    MunicipalServices();
                    break;

                case "6":
                    Exit(ref isRun, "Вы точно хотите выйти? [Y/n]: ");
                    break;

                default:
                    break;
            }
        }

        static void Main(string[] args)
        {
            bool isRunning = true;
            
            while (isRunning)
            {
                Menu(ref isRunning);
            }
        }
    }
}
