using System;

namespace FirstLabOfPracticum
{

    class Program
    {

        static bool isRunning = true;

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
            Console.Clear();

            double salary = DoubleParsing("Введите ваш оклад: ");
            double workingDays = DoubleParsing("Введите количество отработанных дней: ");
            double workingNights = DoubleParsing("Введите количество ночных смен: ");
            double overtime = DoubleParsing("Введите количество отработанных сверхурочных часов: ");
            double perDay = salary / workingDays;
            double finnalySalary = 0;

            workingDays -= workingNights;
            finnalySalary += workingDays * perDay;
            finnalySalary += workingNights * (perDay * 1.2);
            finnalySalary += overtime * 300;
            // Налог
            finnalySalary *= 0.83;

            Console.WriteLine($"Ваша итоговая зарплата: {finnalySalary}");

            Console.WriteLine("\nНажмите любую клавишу для продолжения ... ");
            Console.ReadKey();
        }

        // Вариант 2
        static void CreditCalculator()
        {
            Console.Clear();

            double summ = DoubleParsing("Сумма кредита: ");
            double perYear= DoubleParsing("Годовая процентная ставка: ");
            double years = DoubleParsing("На сколько лет: ");

            double result = summ * (1 + (perYear * years) / 100);

            Console.WriteLine("Вам придётся выплатить {0}", result);
            Console.WriteLine("\nНажмите любую клавишу для продолжения ... ");
            Console.ReadKey();
        }

        // Вариант 3
        static void TravelCost()
        {
            Console.Clear();

            double distance = DoubleParsing("Расстояние в км: ");
            double averageFuelUsage = DoubleParsing("Средний расход топлива на 100км: ");
            double pricePerLiter = DoubleParsing("Цена за литр: ");

            double fuelUsage = distance * (averageFuelUsage / 100);
            double result = fuelUsage * pricePerLiter;

            Console.WriteLine($"Цена поездки обойдётся в {result}");

            Console.WriteLine("\nНажмите любую клавишу для продолжения ... ");
            Console.ReadKey();
        }

        // Вариант 4
        static void IndexOfMass()
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

            Console.WriteLine("\nНажмите любую клавишу для продолжения ... ");
            Console.ReadKey();
        }

        // Вариант 5
        static void MunicipalServices()
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
            Console.WriteLine("\nНажмите любую клавишу для продолжения ... ");
            Console.ReadKey();
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

        static void Exit()
        {

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.Write("Вы точно хотите выйти? [Y/n]: ");
                string? confirm = Console.ReadLine()?.ToLower();

                if (confirm == "" || confirm == "y")
                {
                    isRunning = false;
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
        }

        static void Menu()
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
                    Exit();
                    break;

                default:
                    break;
            }
        }

        static void Main(string[] args)
        {
            
            while (isRunning)
            {
                Menu();
            }
        }
    }
}
