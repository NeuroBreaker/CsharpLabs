using System;

class Program
{

    static bool isRunning = true;

    static double parsing(char num)
    {

        Console.WriteLine($"Введите число {num}: ");
        while (!double.TryParse(Console.ReadLine(), out double n))
        {
            Console.WriteLine($"\nВведите число {num}: ");
        }

        return n;
    }

    static void firstlab()
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

        if ((Math.Sin(a) + 1) == 0)
        {
            Console.WriteLine("Деление на ноль невозможно"); 
        }
        else
        {
            Console.WriteLine($"\nОтвет: {Math.Round(task2, 2)}");
        }


        // End
        Console.WriteLine("\nНажмите любую клавишу для завершения программы ...");
        Console.ReadKey();
    }

    static void showMenu() {
        Console.Clear();
        Console.WriteLine("1. Отгадай ответ");
        Console.WriteLine("2. Об авторе");
        Console.WriteLine("3. Выход");
        Console.Write("Ваш выбор: ");
    }

    static void guessAnswer() {
        Console.WriteLine("f = π(ln b^5 / sin(a) + 1)");
        Console.WriteLine("Ваш ответ: ");
        string? temp = Console.ReadLine("");
        int guess = int.Parse(temp);

        Console.Clear();
        firstlab();
    }

    static void aboutAuthor() {
        Console.Clear();
        Console.WriteLine("Сделал Рахматулин Родион");
        Console.WriteLine("6105-090301 группа\n");
        Console.WriteLine("Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }

    static void exit() {
        bool runnable = true;

        while (runnable)
        {
            Console.Clear();
            Console.Write("Вы действительно хотите выйти? [Y/n]: ");
            string confirm = Console.ReadLine()?.ToLower();

            if (confirm == "д" || confirm == "y"
                    || confirm == "" )
            {
                isRunning = false;
                runnable = false;
                Console.Clear();
            }
            else if (confirm == "н" || confirm == "n")
            {
                Console.Clear();
                runnable = false;
            }
            else
            {
                Console.WriteLine("Принимаются только символы 'д' и 'н'");
            }
        }
    }

    static void run()
    {
        showMenu();

        string choice = Console.ReadLine(); 

        switch (choice)
        {
            case "1":
                guessAnswer();
                break;

            case "2":
                aboutAuthor();
                break;

            case "3":
                exit();
                break;

            default:
                Console.Clear();
                Console.WriteLine("Нет такого варианта\n");
                break;
        }
    }

    static void Main(string[] args)
    {
        while(isRunning)
        {
            run();
        }
    }
}
