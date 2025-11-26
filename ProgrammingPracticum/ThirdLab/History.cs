using System;
using System.Collections.Generic;
using System.Linq;

class HistoryRecord {
    
    public int Id { get; set; }
    public double Distance { get; set; }
    public string VehicleType { get; set; }
    public string Season { get; set; }
    public double TotalCost { get; set; }
    public DateTime Date { get; set; }

    public HistoryRecord(int id, double distance, string vehicle,
                    string season, double totalCost, DateTime date)
    {
        Id = id;
        Distance = distance;
        VehicleType = vehicle ?? throw new ArgumentNullException(nameof(vehicle));
        Season = season ?? throw new ArgumentNullException(nameof(season));
        TotalCost = totalCost;
        Date = date;
    }
}

class History
{
    private const string TopLeft = "┌";
    private const string TopRight = "┐";
    private const string MiddleLeft = "├";
    private const string MiddleRight = "┤";
    private const string BottomLeft = "└";
    private const string BottomRight = "┘";
    private const string Horizontal = "─";
    private const string Vertical = "│";
    private const int TableWidth = 94;

    private static List<HistoryRecord> records;
    private static SortOrder currentSortOrder;

    private enum SortOrder
    {
        Index,
        Distance,
        Transport,
        Season,
        Cost,
        Date,
        Nothing
    }

    public History()
    {
        records = new List<HistoryRecord>();
        currentSortOrder = SortOrder.Index;
    }

    public void AddRecord(double distance, string vehicle, string season, double totalCost, DateTime date)
    { 
        if (distance <= 0)
            throw new ArgumentException("Расстояние должно быть положительным", nameof(distance));

        if (totalCost < 0)
            throw new ArgumentException("Итоговая цена не должна быть меньше 0", nameof(totalCost));

        HistoryRecord record = new HistoryRecord(
            records.Count + 1,
            distance,
            vehicle,
            season,
            totalCost,
            date
        );

        records.Add(record);
    }

    private void DrawHorizontal(string left, string right)
    {
        Console.Write(left);
        Console.Write(new string(Horizontal[0], TableWidth));
        Console.WriteLine(right);
    }

    private void DrawTop() => DrawHorizontal(TopLeft, TopRight);
    private void DrawMiddle() => DrawHorizontal(MiddleLeft, MiddleRight);
    private void DrawBottom() => DrawHorizontal(BottomLeft, BottomRight);

    private void DrawHeader()
    {
        Console.Write(Vertical);
        Console.Write(currentSortOrder == SortOrder.Index ? "▾▴" : " ");
        Console.Write("№");
        Console.Write(currentSortOrder == SortOrder.Distance ? "▾" : " ");
        Console.Write("Расстояние");
        Console.Write(currentSortOrder == SortOrder.Transport ? "" : ""); 
        Console.Write("Машина");
        Console.Write(currentSortOrder == SortOrder.Season ? "" : "");
        Console.Write("Сезон");
        Console.Write(currentSortOrder == SortOrder.Date ? "▾" : " ");
        Console.Write("Дата");
        Console.WriteLine(Vertical);
    }

    private void DrawRecord(HistoryRecord record)
    {
        Console.Write(Vertical);
        Console.Write($" {record.Id + 1, 2}\t");
        Console.Write($"  {record.VehicleType,-15}");
        Console.Write($"  {record.Season,-12}");
        Console.Write($"  {record.TotalCost,8:F2} руб ");
        Console.Write($"  {record.Date:dd.MM.yyyy HH:mm} ");
        Console.WriteLine(Vertical);
    }

    // private List<HistoryRecord> SortedHistory()
    // {
    //
    // }

    private void DrawTable()
    {
        DrawTop();
        DrawHeader();
        DrawMiddle();

        foreach (HistoryRecord record in records)
        {
            DrawRecord(record);
        }

        DrawBottom();
    }

    private void ShowMenu()
    {
        Console.WriteLine("1. Сортировка по индексу");
        Console.WriteLine("2. Сортировка по расстоянию");
        Console.WriteLine("3. Сортировка по транспорту");
        Console.WriteLine("4. Сортировка по сезону");
        Console.WriteLine("5. Сортировка по стоимости");
        Console.WriteLine("6. Сортировка по времени запроса");
        Console.WriteLine("7. Выход");
        Console.Write("\nВаш выбор: ");
    }

    private bool ProcessUserInput(string? input)
    {
        switch (input?.Trim())
        {
            case "1":
                currentSortOrder = SortOrder.Index; break;
            case "2":
                currentSortOrder = SortOrder.Distance; break;
            case "3":
                currentSortOrder = SortOrder.Transport; break;
            case "4":
                currentSortOrder = SortOrder.Season; break;
            case "5":
                currentSortOrder = SortOrder.Cost; break;
            case "6":
                currentSortOrder = SortOrder.Date; break;
            case "7":
                return false;
            default:
                Console.Clear();
                Console.WriteLine("\nНеверный выбор, нажмите любую клавишу ...");
                Console.ReadKey();
                break;
        }
        return true;
    }

    public void Show()
    {
        Console.Clear();

        bool continueLoop = true;

        if (records.Count == 0)
        {
            continueLoop = false;
            Console.WriteLine("История пуста.");
            Console.WriteLine("Вы ещё не использовали калькулятор");
            Console.ReadKey();
        }

        while (continueLoop)
        {
            DrawTable();
            ShowMenu();

            string? input = Console.ReadLine();
            continueLoop = ProcessUserInput(input);
        }

    }
}
