using System;

class Program
{

    static double DoubleParsing(string message)
    {
        double result;
        string input;

        do {
            Console.Write(message);
            input = Console.ReadLine();
        }
        while(!double.TryParse(input, out result));
    
        return result;
    }

    static void Main(string[] args)
    {

        // 1 пункт
        // const double E = Math.E;
        const double PI = Math.PI;

        // 2 пункт
        Console.Clear();

        double a = DoubleParsing("Введите число a: ");
        double b = DoubleParsing("Введите число b: ");

        // 3 пункт
        double task2 = PI * (Math.Log(Math.Pow(b, 5)) / (Math.Sin(a) + 1));

        // 4 пункт
        Console.WriteLine($"\nОтвет на второй вариант: {Math.Round(task2, 2)}");

        // End
        Console.WriteLine("\nНажмите любую клавишу для завершения программы ...");
        Console.ReadKey();
    }
}
