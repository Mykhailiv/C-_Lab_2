using System;

class Program
{
    // Оголошуємо метод Main
    static void Main(string[] args)
    {
        // Оголошуємо змінні для розмірності матриці
        int n = 4;
        int m = 4;
        // Оголошуємо двовимірний масив для зберігання матриці
        int[,] matrix = new int[n, m];

        // Заповнюємо матрицю випадковими числами від -10 до 10
        Random rnd = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = rnd.Next(-10, 11);
            }
        }

        // Виводимо матрицю на екран
        Console.WriteLine("Matrix:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write("{0,4}", matrix[i, j]);
            }
            Console.WriteLine();
        }

        // Знаходимо суму елементів в тих стовпцях, які не містять від’ємних елементів
        int sum = 0;
        for (int j = 0; j < m; j++)
        {
            bool hasNegative = false;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, j] < 0)
                {
                    hasNegative = true;
                    break;
                }
            }
            if (!hasNegative)
            {
                for (int i = 0; i < n; i++)
                {
                    sum += matrix[i, j];
                }
            }
        }
        Console.WriteLine("Sum of elements in columns without negative elements: {0}", sum);

        // Знаходимо максимум із сум діагоналей, паралельних головній діагоналі матриці
        int maxSum = int.MinValue;
        for (int i = 0; i < n; i++)
        {
            int sum1 = 0;
            int sum2 = 0;
            for (int j = 0; j < m; j++)
            {
                if (i + j < n)
                {
                    sum1 += matrix[i + j, j];
                }
                if (i + j < m)
                {
                    sum2 += matrix[j, i + j];
                }
            }
            if (sum1 > maxSum)
            {
                maxSum = sum1;
            }
            if (sum2 > maxSum)
            {
                maxSum = sum2;
            }
        }
        Console.WriteLine("The maximum sum of elements of diagonals parallel to the main diagonal: {0}", maxSum);
    }
}
