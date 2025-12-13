using System;
using System.Diagnostics;

using FifthLab.Utils;

namespace FifthLab.ArrayUtils
{
    
    /// <summary>
    /// Класс со всеми методами для сортировок массива
    /// </summary>
    class Arrays {

        int _size;
        int[,] _array;

        public Arrays()
        {
            _size = 10;                        
        }

        // Запрашивает размер массива, возвращает его
        int InputArraySize()
        {
            int arraySize;
            do {
                arraySize = InputHelper.GetInt("Выберите размер для массива: ");

                if (arraySize < 1)
                {
                    Console.WriteLine("Массив не может состоять из 0 и меньше элементов");
                }
            }
            while(arraySize < 1);

            return arraySize;
        }

        // Заполнение массива случайными значениями
        int[] FillArray(int[] array)
        {
            
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int num = rnd.Next(-9, 9);
                array[i] = num;
            }

            return array;
        }

        // При вызове этого метода указывается размер создаваемого массива
        // После этого он заполняется методом FillArray
        int[] ArrayInitialization(int size)
        {
            int[] array = new int[size];
            FillArray(array);

            return array;
        }

        // Возвращает клон передаваемого массива
        int[] CloneArray(int[] array)
        {
            int size = array.Length;
            int[] cloneArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                cloneArray[i] = array[i];    
            }

            return cloneArray;
        }

        // Вывод массива в консоль
        void OutputArray(int[] array)
        {
            int size = array.Length;
            if (size > 10)
            {
                Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массива больше 10");
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    Console.Write("{0} ", array[i]);
                }
                Console.WriteLine();
            }
        }

        // Создаёт клон передаваемого массива, сортирует его методом пузырька и после возвращает
        int[] BubbleSorting(int[] array)
        {
            int size = array.Length;
            int[] sortingArray = CloneArray(array);
            for (int i = 0; i < size - 1; i++) {
                for (int j = 0; j < size - 1 - i; j++)
                {
                    if (sortingArray[j] > sortingArray[j+1])
                    {
                        int temp = sortingArray[j];
                        sortingArray[j] = sortingArray[j+1];
                        sortingArray[j+1] = temp;
                    }
                }
            }

            return sortingArray;
        }
        
        // Создаёт клон передаваемого массива, сортирует его методом вставок и после возвращает
        int[] InsertSorting(int[] array)
        {
            int size = array.Length;
            int[] sortingArray = CloneArray(array);
            for (int i = 1; i < size; ++i)
            {
                int j = i - 1;
                int temp = sortingArray[i];
                while (j >= 0 && sortingArray[j] > temp)
                {
                    sortingArray[j + 1] = sortingArray[j];
                    --j;
                }
                sortingArray[j + 1] = temp;
            }

            return sortingArray;
        }

        /// <summary>
        /// Метод для сравнения сортировок
        /// </summary>
        public void ArraysSorting()
        {
            Console.Clear();

            Console.WriteLine("Добро пожаловать в метод сравнения сортировок массива");

            int arraySize = InputArraySize();
            int[] array = ArrayInitialization(arraySize);

            Console.WriteLine("Неотсортированный массив:");
            OutputArray(array);

            Stopwatch stopwatchBubble = new Stopwatch();
            stopwatchBubble.Start();
            int[] bubbleSortingArray = BubbleSorting(array);
            stopwatchBubble.Stop();

            Console.WriteLine($"\nВремя выполнения сортировки пузырьком: {stopwatchBubble.ElapsedMilliseconds} миллисекунд");
            Console.WriteLine("Отсортированный массив:");
            OutputArray(bubbleSortingArray);

            Stopwatch stopwatchInsert = new Stopwatch();
            stopwatchInsert.Start();
            int[] insertSortingArray = InsertSorting(array);
            stopwatchInsert.Stop();

            Console.WriteLine($"\nВремя выполнения сортировки вставками: {stopwatchInsert.ElapsedMilliseconds} миллисекунд");
            Console.WriteLine("Отсортированный массив:");
            OutputArray(insertSortingArray);

            if (stopwatchInsert.ElapsedMilliseconds > stopwatchBubble.ElapsedMilliseconds)
            {
                var difference = stopwatchInsert.ElapsedMilliseconds - stopwatchBubble.ElapsedMilliseconds;
                Console.WriteLine($"\nАлгоритм сортировки пузырьком оказался быстрее на {difference} миллисекунд");
            }
            else
            {
                var difference = stopwatchBubble.ElapsedMilliseconds - stopwatchInsert.ElapsedMilliseconds;
                Console.WriteLine($"\nАлгоритм сортировки вставками оказался быстрее на {difference} миллисекунд");
            }


            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
            Console.ReadKey();
        }
    }
}
