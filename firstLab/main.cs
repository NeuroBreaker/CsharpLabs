using System;

class Program
{

    static double parsing(char num)
    {

        Console.WriteLine($"Введите число {num}: ");
        while (!double.TryParse(Console.ReadLine(), out double n))
        {
            Console.WriteLine($"\nВведите число {num}: ");
        }

        return n;
    }
    
    static void Main(string[] args)
    {

        // 1 пункт
        const double E = Math.E;
        const double PI = Math.PI;

        double a, b;

        // 2 пункт
        Console.Clear();

        a = parsing('a');
        b = parsing('b');

        // 3 пункт
        double task2 = PI * (Math.Log(Math.Pow(b, 5)) / (Math.Sin(a) + 1));

        // 4 пункт
        Console.WriteLine($"\nВторой вариант: {Math.Round(task2, 2)}");

        // End
        Console.WriteLine("\nНажмите любую клавишу для завершения программы ...");
        Console.ReadKey();
    }
}
