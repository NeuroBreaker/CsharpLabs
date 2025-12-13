using System;

namespace FifthLab.Utils
{
    /// <summary>
    /// Класс с инструментами для
    /// проверки ввода данных пользователя
    /// </summary>
    class InputHelper
    {

        /// <summary>
        /// Запрашивает ввод у пользователя и парсит его в double тип
        /// </summary>
        public static int GetInt(string message)
        {
            int result;
            string? input;

            do {
                Console.Write(message);
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out result));

            return result;
        }

        /// <summary>
        /// Запрашивает ввод у пользователя и парсит его в double тип
        /// </summary>
        public static double GetDouble(string message)
        {
            double result;
            string? input;

            do {
                Console.Write(message);
                input = Console.ReadLine();
            }
            while (!double.TryParse(input, out result));

            return result;
        }
    }

    /// <summary>
    /// Класс для методов
    /// связанных с bool
    /// </summary>
    class BoolHandler
    {


        /// <summary>
        /// Спрашивает хотите ли выйти до того момента
        /// пока не введёте
        /// y / Y / n / N / Enter(ничего)
        /// </summary>
        /// <returns>bool</returns>
        public static bool Exit()
        {
            bool runnable = true;
    
            while (runnable)
            {
                Console.Clear();
                Console.Write("Вы действительно хотите выйти? [Y/n]: ");
                string? confirm = Console.ReadLine()?.ToLower();
    
                if (confirm == "д" || confirm == "y"
                        || confirm == "" )
                {
                    runnable = false;
                    Console.Clear();
                    return true;
                }
                else if (confirm == "н" || confirm == "n")
                {
                    runnable = false;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("\nВведите либо Enter, либо y, либо n, либо д, либо н.");
                    Console.WriteLine("Другие варианты не примаются");

                    Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
                    Console.ReadKey();
                }
            }
            return false;
        }

        /// <summary>
        /// Выводит ✅/❌в консоль при передаче bool
        /// </summary>
        public static void PrintBool(bool boolean)
        {

            if (boolean)
            {
                Console.WriteLine("✅ Верно");
            }
            else 
            {
                Console.WriteLine("❌Неверно");
            }
        }
    }
}
