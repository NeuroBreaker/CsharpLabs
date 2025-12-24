using System;
using System.Collections.Generic;

using ThirdLab.Utils;

namespace ThirdLab.HistoryClass
{

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
        private const int TableWidth = 70;

        private readonly List<HistoryRecord> _records;
        private SortOrder _currentSortOrder;
        private HistoryRecord? _minHistoryRecord;
        private HistoryRecord? _maxHistoryRecord;
        public double AverageCostSum;

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
            _records = new List<HistoryRecord>();
            _currentSortOrder = SortOrder.Index;
            AverageCostSum = 0;
        }

        public void TravelAnalysis()
        {
            if (_maxHistoryRecord is null && _minHistoryRecord is null)
            {
                Console.WriteLine("Не записано историй");
                return;
            }

            Console.WriteLine($"Всего поездок: {_records.Count}");
            Console.Write($"Максимальная стоимость поездки: {_maxHistoryRecord?.TotalCost}");
            Console.Write($"({_maxHistoryRecord?.Distance} км ");
            Console.Write($"на {_maxHistoryRecord?.VehicleType} ");
            Console.WriteLine($"{_maxHistoryRecord?.Season})");
            Console.Write($"Минимальная стоимость поездки: {_minHistoryRecord?.TotalCost}");
            Console.Write($"({_minHistoryRecord?.Distance} км ");
            Console.Write($"на {_minHistoryRecord?.VehicleType} ");
            Console.WriteLine($"{_minHistoryRecord?.Season})");
            Console.WriteLine($"Средняя стоимость 1 км {AverageCostSum / _records.Count}");

            InputHandler.WaitEnter();
        }
        
        public void AddRecord(double distance, string vehicle, string season, double totalCost, DateTime date)
        { 
            if (distance <= 0)
                throw new ArgumentException("Расстояние должно быть положительным", nameof(distance));

            if (totalCost < 0)
                throw new ArgumentException("Итоговая цена не должна быть меньше 0", nameof(totalCost));

            HistoryRecord record = new HistoryRecord(
                _records.Count + 1,
                distance,
                vehicle,
                season,
                totalCost,
                date
            );

            if (totalCost < _minHistoryRecord?.TotalCost
                    || _minHistoryRecord is null)
            {
                _minHistoryRecord = record;
            }
            if (totalCost > _maxHistoryRecord?.TotalCost
                    || _maxHistoryRecord is null)
            {
                _maxHistoryRecord = record;
            }

            _records.Add(record);
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
            Console.Write(Vertical, " ");
            Console.Write(_currentSortOrder == SortOrder.Index ? "▾ " : "  ");
            Console.Write("№  ");
            Console.Write(_currentSortOrder == SortOrder.Distance ? "▾" : " ");
            Console.Write("Расстояние ");
            Console.Write(_currentSortOrder == SortOrder.Transport ? "▾" : " "); 
            Console.Write("Машина     ");
            Console.Write(_currentSortOrder == SortOrder.Season ? "▾" : " ");
            Console.Write("Сезон    ");
            Console.Write(_currentSortOrder == SortOrder.Cost ? "▾" : " ");
            Console.Write("Цена(руб)   ");
            Console.Write(_currentSortOrder == SortOrder.Date ? "▴" : " ");
            Console.Write("Дата             ");
            Console.WriteLine(Vertical);
        }

        private void DrawRecord(HistoryRecord record)
        {
            Console.Write(Vertical);
            Console.Write($"  {record.Id + 1, -4}");
            Console.Write($"{record.Distance, -12}");
            Console.Write($"{record.VehicleType,-12}");
            Console.Write($"{record.Season,-10}");
            Console.Write($"{record.TotalCost,-13:F2}");
            Console.Write($"{record.Date,-5:dd.MM.yyyy HH:mm} ");
            Console.WriteLine(Vertical);
        }

        private List<HistoryRecord> SortedHistory()
        {
            Console.WriteLine("Need refactor"); 

            return null;
        }

        private void DrawTable()
        {
            DrawTop();
            DrawHeader();
            DrawMiddle();

            foreach (HistoryRecord record in _records)
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
                    _currentSortOrder = SortOrder.Index; break;
                case "2":
                    _currentSortOrder = SortOrder.Distance; break;
                case "3":
                    _currentSortOrder = SortOrder.Transport; break;
                case "4":
                    _currentSortOrder = SortOrder.Season; break;
                case "5":
                    _currentSortOrder = SortOrder.Cost; break;
                case "6":
                    _currentSortOrder = SortOrder.Date; break;
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

            if (_records.Count == 0)
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
}
