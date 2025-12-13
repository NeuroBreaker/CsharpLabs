using System;
using System.Diagnostics;

namespace FifthLab.ArrayUtils
{
    
    /// <summary>
    /// Класс со всеми методами для сортировок массива
    /// </summary>
    class ArraySorter {

        private int _size;
        private int[] _array;

        public ArraySorter() : this(10) {}

        public ArraySorter(int size)
        {
            this._size = size;
            this._array = new int[_size];
        }

        // Заполнение массива случайными значениями
        private void FillArray()
        {
            
            Random rnd = new Random();
            for (int i = 0; i < _array.Length; i++)
            {
                int num = rnd.Next(-9, 9);
                _array[i] = num;
            }
        }

        // Возвращает клон передаваемого массива
        private int[] CloneArray(int[] array)
        {
            int size = array.Length;
            int[] cloneArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                cloneArray[i] = array[i];    
            }

            return cloneArray;
        }

        /// <summary>
        /// Вывод массива в консоль
        /// </summary>
        public void OutputArray(int[] array)
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
        private int[] BubbleSorting(int[] array)
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
        private int[] InsertSorting(int[] array)
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

            Console.WriteLine("Неотсортированный массив:");
            FillArray();
            OutputArray(_array);

            Stopwatch stopwatchBubble = new Stopwatch();
            stopwatchBubble.Start();
            int[] bubbleSortingArray = BubbleSorting(_array);
            stopwatchBubble.Stop();

            Console.WriteLine($"\nВремя выполнения сортировки пузырьком: {stopwatchBubble.ElapsedMilliseconds} миллисекунд");
            Console.WriteLine("Отсортированный массив:");
            OutputArray(bubbleSortingArray);

            Stopwatch stopwatchInsert = new Stopwatch();
            stopwatchInsert.Start();
            int[] insertSortingArray = InsertSorting(_array);
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


            Console.WriteLine("\nВведите Enter для продолжения ...");
            Console.ReadKey();
        }
    }
}
