using System;
using System.Text;

using FifthLab.Utils;
using FifthLab.Guess;
using FifthLab.ArrayUtils;
using FifthLab.Tetris;

// 2 вариант
namespace FifthLab
{

    class Program
    {
    
        static TetrisGame? tetris;

        // Об авторе (вызывается из меню)
        static void AboutAuthor()
        {
            Console.Clear();
            Console.WriteLine("Сделал Рахматулин Родион");
            Console.WriteLine("группа 6105-090301D");
            Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
            Console.ReadKey();
        }
    
        // Вывод меню в консоль
        static void ShowMenu() 
        {
            Console.Clear();
            Console.WriteLine("1. Отгадай ответ");
            Console.WriteLine("2. Об авторе");
            Console.WriteLine("3. Сортировка массива");
            Console.WriteLine("4. Тетрис");
            Console.WriteLine("5. Выход");
            Console.Write("Ваш выбор: ");
        }

        // Меню с выбором
        static bool Menu()
        {
            ShowMenu();
    
            string? choice = Console.ReadLine(); 
    
            switch (choice)
            {
                case "1":
                    GuessGame.GuessAnswer();
                    break;
    
                case "2":
                    AboutAuthor();
                    break;

                case "3":
                    // Пример использования конструктора без параметров
                    ArraySorter arraySorter0 = new ArraySorter();
                    arraySorter0.ArraysSorting();

                    Console.Clear();

                    // Пример использования конструктора с параметрами
                    int size = InputHelper.GetArraySize();
                    ArraySorter arraySorter1 = new ArraySorter(size);
                    arraySorter1.ArraysSorting();

                    break;
    
                case "4":
                    if (tetris is null)
                        tetris = new TetrisGame();

                    tetris?.Tetris();
                    break;

                case "5":
                    return BoolHandler.Exit();
    
                default:
                    Console.Clear();
                    Console.WriteLine("Соответствия не найдено");
                    Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
                    Console.ReadKey();
                    break;
            }

            return false;
        }

        // Точка входа в программу
        // запускает цикл с меню
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding  = Encoding.UTF8;
    
            bool isExit = false;
            while(!isExit)
            {
                isExit = Menu();
            }
        }
    }
}
