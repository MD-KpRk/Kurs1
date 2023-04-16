
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace std
{

    public static class Program
    {
        const int N = 100000;
        const int K = 1000000;

        public static void Main(string[] args)
        {
            int[] arr = new int[N];
            Random randNum = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = randNum.Next(1, K);
            Stopwatch watch1 = new Stopwatch();

            watch1.Start();
            InsertionSort(arr);
            watch1.Stop();
            Console.WriteLine("Сортировка Вставками: " + watch1.ElapsedMilliseconds + "ms");

            watch1.Reset(); watch1.Start();
            CocktailSort(arr);
            watch1.Stop();
            Console.WriteLine("Шейкерная сортировка: " + watch1.ElapsedMilliseconds + "ms");

            watch1.Reset(); watch1.Start();
            BubbleSort(arr);
            watch1.Stop();
            Console.WriteLine("Сортирвка пузырьком: " + watch1.ElapsedMilliseconds + "ms");
        }

        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void CocktailSort(int[] arr)
        {
            for (int start = 0,end = arr.Length - 1; start < end; start++, end--)
            {
                for (int i = start; i < end; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }
                for (int i = end; i > start; i--)
                {
                    if (arr[i - 1] > arr[i])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
                    }
                }
            }
        }

        static void InsertionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                arr[j + 1] = key;
            }
        }
    }
}