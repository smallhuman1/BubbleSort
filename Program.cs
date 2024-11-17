using System; 

public static class BubbleSort
{
    public static void Sort<T>(T[] array, Func<T, T, bool> comparer)
    {
        if (array == null || array.Length <= 1)
            return;

        int n = array.Length;
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < n - 1; i++)
            {
                if (comparer(array[i], array[i + 1]))
                {
                    T temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    swapped = true;
                }
            }
            n--;
        } while (swapped);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n\n버블 정렬 테스트");
        {
            int[] array = { 31, 41, 59, 26, 53, 58, 93, 2, 3, 84 };
            bool[] boolArray = { true, false, true, false, true, false, true, false };

            Console.WriteLine("\n불리언 배열 정렬:");
            BubbleSort.Sort(boolArray, (left, right) => left && !right); 
            PrintArray(boolArray);

            Console.WriteLine("\n정수 배열 오름차순 정렬:");
            BubbleSort.Sort(array, (left, right) => left > right); 
            PrintArray(array);

            Console.WriteLine("\n정수 배열 내림차순 정렬:");
            BubbleSort.Sort(array, (left, right) => left < right); 
            PrintArray(array);

            Console.WriteLine("\n정수 배열 코사인 값 기준 정렬:");
            double toDegree = 180 / Math.PI;
            BubbleSort.Sort(array, (left, right) =>
                Math.Cos(left * toDegree) > Math.Cos(right * toDegree));
            PrintArray(array);
        }
    }

    static void PrintArray<T>(T[] array)
    {
        foreach (var item in array)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }
}
