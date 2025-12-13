using System;

using FifthLab.Utils;

namespace FifthLab.Guess
{
    /// <summary>
    /// Класс игры в угадайку
    /// </summary>
    class GuessGame
    {

        // Часть кода из первой лабораторной работы
        static double CalculateMethod(double a, double b)
        {
            const double PI = Math.PI;

            double result = PI * (Math.Log(Math.Pow(b, 5)) / (Math.Sin(a) + 1)); // Решение для второго варианта

            return Math.Round(result, 2);
        }

        // Запрашивает ответ 3 раза, если
        // ответ верный, то цикл прервётся
        static void Guess(double result)
        {

            for (int i = 3; i > 0; i--) 
            {
                Console.WriteLine($"Количество попыток: {i}");
                double guess = InputHelper.GetDouble("Ваш ответ(с округлением до двух знаков после запятой): ");
                if (guess == result)
                {
                    BoolHandler.PrintBool(true);
                    i = 0;
                }
                else
                {
                    BoolHandler.PrintBool(false);
                }
            }
        }

        /// <summary>
        /// Метод, вызываемый при выборе из меню
        /// </summary>
        public static void GuessAnswer() 
        {
            Console.Clear();
    
            Console.WriteLine("Задача:\nf = π(ln b^5 / sin(a) + 1)");

            double a, b;

            a = InputHelper.GetDouble("Введите число a: ");
            b = InputHelper.GetDouble("Введите число b: ");

            if ((Math.Sin(a) + 1) == 0)
            {
                Console.WriteLine("Деление на ноль невозможно"); 
                Console.WriteLine("\nПопробуйте снова");
                Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
                Console.ReadKey();

                GuessAnswer();
            }

            double result = CalculateMethod(a, b);

            Guess(result);

            Console.WriteLine($"\nОтвет: {result}");
            Console.WriteLine("\nВведите любую клавишу для продолжения ... ");
            Console.ReadKey();
        }
    }
}
