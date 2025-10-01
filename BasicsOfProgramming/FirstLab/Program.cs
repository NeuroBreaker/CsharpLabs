using System;

class Program
{

    static double DoubleParsing(string message)
    {
        double result;

        Console.Write(message);
        while (!double.TryParse(Console.ReadLine(), out result))
        {
            Console.Write(message);
        }
    
        return result;
    }

    static void Main(string[] args)
    {

        // 1 пункт
        // const double E = Math.E;
        const double PI = Math.PI;

        double a, b;

        // 2 пункт
        Console.Clear();

        a = DoubleParsing("Введите число a: ");
        b = DoubleParsing("Введите число b: ");

        // 3 пункт
        double task2 = PI * (Math.Log(Math.Pow(b, 5)) / (Math.Sin(a) + 1));

        // 4 пункт
        Console.WriteLine($"\nОтвет на второй вариант: {Math.Round(task2, 2)}");

        // End
        Console.WriteLine("\nНажмите любую клавишу для завершения программы ...");
        Console.ReadKey();
    }
}
