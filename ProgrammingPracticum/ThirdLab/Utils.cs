using System;

namespace ThirdLab.Utils
{

    class InputHandler
    {

        // Выводит message, ожидает Enter
        public static void WaitEnter(string message = "Введите Enter для продолжения ...")
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }

        // Метод для продолжения
        public static bool Continue(bool running, string message = "Хотите продолжить? [y/N]: ")
        {

            bool exit = false;

            while (!exit)
            {
                Console.Write(message);
                string? confirm = Console.ReadLine()?.ToLower();

                if (confirm == "y")
                {
                    exit = true; 
                }
                else if (confirm == "" || confirm == "n")
                {
                    running = !running;
                    exit = true;
                }
            }
            return running;
        }

        // Метод для выхода
        public static bool Exit(bool running, string message = "Вы точно хотите выйти? [Y/n]: ")
        {

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.Write(message);
                string? confirm = Console.ReadLine()?.ToLower();

                if (confirm == "" || confirm == "y")
                {
                    running = !running;
                    exit = true; 
                }
                else if (confirm == "n")
                {
                    exit = true;
                }
            }
            return running;
        }

        // Будет отправлять повторно message, пока не запарсит вводимое число
        public static int IntegerParsing(string message)
        {

            string? text;
            int result = 0;
            
            do {
                Console.WriteLine(message);
                text = Console.ReadLine();
            }
            while(!int.TryParse(text, out result) || result <= 0m);

            return result;
        }

        // Будет отправлять повторно message, пока не запарсит вводимое число
        public static double DoubleParsing(string message)
        {
            double result = 0;
            string? text;

            do {
                Console.Write(message);
                text = Console.ReadLine();
            }
            while (!double.TryParse(text, out result) || result <= 0);

            return result;
        }
    }
}
