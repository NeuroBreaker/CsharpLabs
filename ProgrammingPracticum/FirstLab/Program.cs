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

        Console.WriteLine("\nНажмите любую клавишу для продолжения ... ");
        Console.ReadKey();
    }

    // Вариант 2
    static void Variant2()
    {
        Console.Clear();

        Console.WriteLine("Метод в разработке");

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
    static void Variant4()
    {
        Console.Clear();

        Console.WriteLine("Метод в разработке");

        Console.WriteLine("\nНажмите любую клавишу для продолжения ... ");
        Console.ReadKey();
    }

    // Вариант 5
    static void Variant5()
    {
        Console.Clear();

        Console.WriteLine("Метод в разработке");

        Console.WriteLine("\nНажмите любую клавишу для продолжения ... ");
        Console.ReadKey();
    }

    static void ShowMenu()
    {
        Console.WriteLine("Добро пожаловать в консольное приложение 💫\n");
        Console.WriteLine("1. Зарплата охранника");
        Console.WriteLine("2. ");
        Console.WriteLine("3. Цена поездки");
        Console.WriteLine("4. ");
        Console.WriteLine("5. ");
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
            string? confirm = Console.ReadLine();

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
                Variant2();
                break;

            case "3":
                TravelCost();
                break;

            case "4":
                Variant4();
                break;

            case "5":
                Variant5();
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
