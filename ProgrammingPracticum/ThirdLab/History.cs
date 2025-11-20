using System;

class History
{

    public static double[] distances { get; set; } = new double[10];
    public static string[] vehicleTypes { get; set; } = new string[10];
    public static string[] seasons { get; set; } = new string[10];
    public static double[] totalCosts { get; set; } = new double[10];
    public static string[] dates { get; set; } = new string[10];
    public static int Index { get; set; } = 0;

    enum Sort
    {
        Index,
        Distance,
        Transport,
        Season,
        Cost,
        Date
    }

    static Sort status = Sort.Index;

    // Write top line
    static void WriteTop()
    {
        Console.Write("┌");
        for (int i = 0; i < 94; i++)
        {
            Console.Write("─");
        }
        Console.WriteLine("┐");
    }

    // Write middle line
    static void WriteMiddle()
    {
        // Разделение
        Console.Write("├");
        for (int i = 0; i < 94; i++)
        {
            Console.Write("─");
        }
        Console.WriteLine("┤");
    }

    // Write bottom line
    static void WriteBottom()
    {
        Console.Write("└");
        for (int i = 0; i < 94; i++)
        {
            Console.Write("─");
        }
        Console.WriteLine("┘");
    }

    // Write table sorted by index
    static void WriteSortedByIndex()
    {
        string title = "│▾ №       Расстояние    Транспорт           Сезон           Стоимость         Время запроса   │"; 
        Console.WriteLine(title);

        WriteMiddle();

        for (int i = 0; i < Index; i++)
        {
            Console.Write("│ ");
            Console.Write($"{i + 1, 2}\t");
            Console.Write($"{distances[i], 10} км\t");
            Console.Write($"{vehicleTypes[i], 10}\t");
            Console.Write($"{seasons[i], 10}\t");
            Console.Write($"{totalCosts[i], 10} руб\t");
            Console.Write($"{dates[i], 20}");
            Console.WriteLine("   │");
        }
    }

    // Write table sorted by distance
    // NEED TO REFACTOR
    static void WriteSortedByDistance()
    {
        string title = "│  №       Расстояние    Транспорт           Сезон           Стоимость       ▴ Время запроса   │"; 
        Console.WriteLine(title);

        WriteMiddle();

        for (int i = 0; i < Index; i++)
        {
            Console.Write("│ ");
            Console.Write($"{i + 1, 2}\t");
            Console.Write($"{distances[i], 10} км\t");
            Console.Write($"{vehicleTypes[i], 10}\t");
            Console.Write($"{seasons[i], 10}\t");
            Console.Write($"{totalCosts[i], 10} руб\t");
            Console.Write($"{dates[i], 20}");
            Console.WriteLine("   │");
        }
    }

    // Write table sorted by date
    static void WriteSortedByDate()
    {
        string title = "│  №       Расстояние    Транспорт           Сезон           Стоимость       ▴ Время запроса   │"; 
        Console.WriteLine(title);

        WriteMiddle();

        for (int i = Index - 1; i >= 0; i--)
        {
            Console.Write("│ ");
            Console.Write($"{i + 1, 2}\t");
            Console.Write($"{distances[i], 10} км\t");
            Console.Write($"{vehicleTypes[i], 10}\t");
            Console.Write($"{seasons[i], 10}\t");
            Console.Write($"{totalCosts[i], 10} руб\t");
            Console.Write($"{dates[i], 20}");
            Console.WriteLine("   │");
        }
    }

    // Write documentation for user
    static void WriteMenu()
    {
        Console.WriteLine("1. Сортировка по индексу");
        Console.WriteLine("2. Сортировка по расстоянию");
        Console.WriteLine("3. Сортировка по транспорту");
        Console.WriteLine("4. Сортировка по сезону");
        Console.WriteLine("5. Сортировка по стоимости");
        Console.WriteLine("6. Сортировка по времени запроса");
        Console.WriteLine("7. Выход");
        Console.Write("Ваш выбор: ");
    }

    // Main method
    public static void DrawHistory()
    {
        Console.Clear();
        if (Index == 0) 
        {
            Console.WriteLine("Вы не использовали калькулятор до этого");
        }
        else
        {
            bool is_loop = true;
            while (is_loop)
            {
                Console.Clear();
                WriteTop();

                switch (status)
                {
                    case Sort.Index:
                        WriteSortedByIndex();
                        break;

                    case Sort.Distance:
                        WriteSortedByDistance();
                        break;

                    case Sort.Date:
                        WriteSortedByDate();
                        break;

                    default:
                        break;
                }
     
                WriteBottom();
                WriteMenu();

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        status = Sort.Index;
                        break;

                    case "2":
                        status = Sort.Distance;
                        break;

                    case "3":
                        status = Sort.Transport;
                        break;

                    case "4":
                        status = Sort.Season;
                        break;

                    case "5":
                        status = Sort.Cost;
                        break;

                    case "6":
                        status = Sort.Date;
                        break;

                    case "7":
                        status = Sort.Index;
                        is_loop = false;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
