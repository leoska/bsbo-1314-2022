using bsbo_1314_2022;
using System;

internal class Program
{
    // Выводит содержимое массива
    static void PrintArr(int[] arr)
    {
        foreach(int i in arr)
        {
            Console.Write($"{i} ");
        }

        Console.WriteLine();
    }

    // Сортировка массива алгоритмом сортировки пузырьком
    static void SortArr()
    {
        int N = 5;
        int[] arr = new int[] { 14, 28, 0, -9, 2 };
        // Перестановки
        // 0) 14, 28, 0, -9, 2
        // 1) 14, 0, 28, -9, 2
        // 2) 14, 0, -9, 28, 2
        // 3) 14, 0, -9, 2, 28

        // Отрезаем хвост
        // 0) 14, 28, 0, -9, 2
        // 1) 14, 0, -9, 2 | 28
        // 2) 0, -9, 2 | 14, 28
        // 3) -9, 0 | 2, 14, 28
        // 4) -9 | 0, 2, 14, 28

        PrintArr(arr);

        bool flagSwap = false;
        for (int i = 0; i < N; i++)
        {
            flagSwap = false;
            for (int j = 0; j < N - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Доп. память
                    // O(2 + 4 + 3 = 9), M(1)
                    //int tmp = arr[j];
                    //arr[j] = arr[j + 1];
                    //arr[j + 1] = tmp;

                    // Без доп памяти
                    // [28, 7]
                    // 1) [28, 35] ([2] = [1] + [2])
                    // 2) [7, 35] ([1] = [2] - [1])
                    // 3) [7, 28] ([2] = [2] - [1])
                    // O(7 + 6 + 7 = 20), M(0)
                    //arr[j + 1] = arr[j + 1] + arr[j];
                    //arr[j] = arr[j + 1] - arr[j];
                    //arr[j + 1] = arr[j + 1] - arr[j];

                    // TupleValue swap
                    // O(6 + k), M(2k)
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    flagSwap = true;
                }
            }

            if (!flagSwap)
                break;
        }

        PrintArr(arr);
    }

    // Пример взаимодействия структур (ValueType)
    static void ValueType()
    {
        ElemValue a = new ElemValue(15);
        ElemValue b = a;

        // a = 15, b = 15
        Console.WriteLine($"a: {a.value}; b: {b.value}");
        b.value = 27;
        // a = 15, b = 27
        Console.WriteLine($"a: {a.value}; b: {b.value}");
    }

    // Пример взаимодействия классов (RefType)
    static void RefType()
    {
        Element a = new Element(15);
        Element b = a;

        // a = 15, b = 15
        Console.WriteLine($"a: {a.value}; b: {b.value}");
        b.value = 27;
        // a = 27, b = 27
        Console.WriteLine($"a: {a.value}; b: {b.value}");
    }

    // Сортировка линейно-связанного списка
    static void SortListElem()
    {
        ListElem list = new ListElem();
        Random rnd = new Random();
        int N = 5;

        for (int i = 0; i < N; i++)
        {
            list.Push(new Element(rnd.Next(0, 100)));
        }

        list.Print();

        bool flagSwap = false;
        for (int i = 0; i < N; i++)
        {
            flagSwap = false;

            for (int j = 0; j < N - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                    flagSwap = true;
                }
            }

            if (!flagSwap)
                break;
        }

        list.Print();
    }

    // Сортировка стэка
    static void SortStackElem()
    {
        StackElem stack = new StackElem();
        Random rnd = new Random();
        int N = 5;

        for (int i = 0; i < N; i++)
        {
            stack.Push(new Element(rnd.Next(0, 100)));
        }

        stack.Print();

        bool flagSwap = false;
        for (int i = 0; i < N; i++)
        {
            flagSwap = false;

            for (int j = 0; j < N - i - 1; j++)
            {
                if (stack[j] > stack[j + 1])
                {
                    (stack[j], stack[j + 1]) = (stack[j + 1], stack[j]);
                    flagSwap = true;
                }
            }

            if (!flagSwap)
                break;
        }

        stack.Print();
    }

    private static void Main(string[] args)
    {
        //SortArr();
        //ValueType();
        //RefType();
        //SortListElem();
        SortStackElem();
    }
}