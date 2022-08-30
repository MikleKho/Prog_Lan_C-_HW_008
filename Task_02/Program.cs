// Задача 2: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.
int Prompt(string message)
{
    System.Console.Write(message);
    string readValue = Console.ReadLine();
    int result = int.Parse(readValue);
    return result;
}

int[,] MassRndInject(int[,] massInside)
{
    Random rnd = new Random();

    for (int i = 0; i < massInside.GetLength(0); i++)
    {
        for (int j = 0; j < massInside.GetLength(1); j++)
        {
            massInside[i, j] = rnd.Next(0, 10);
        }
    }

    return massInside;
}

int FindInMassRowsMinSum(int[,] massInside)
{
    int numberMinMassSumRowIn = 1;
    int rowSumTemp = 0;

    for (int i = 0; i < massInside.GetLength(0); i++)
    {
        int rowSum = massInside[i, 0];

        for (int j = 1; j < massInside.GetLength(1); j++)
        {
            rowSum = rowSum + massInside[i, j];
        }
        if (i == 0) rowSumTemp = rowSum;
        if (rowSum < rowSumTemp)
        {
            rowSumTemp = rowSum;
            numberMinMassSumRowIn = i + 1;
        }

        System.Console.WriteLine($"Сумма элементов строки {i + 1} равна {rowSum} ");
    }

    return numberMinMassSumRowIn;
}



void MassPrintInt(int[,] massInside, string messageIn)
{
    System.Console.WriteLine(messageIn);

    for (int i = 0; i < massInside.GetLength(0); i++)
    {
        for (int j = 0; j < massInside.GetLength(1); j++)
        {
            System.Console.Write($"  {massInside[i, j]}");
        }
        System.Console.WriteLine();
    }

    return;
}

int massNumberRows = Prompt("Введите количество строк массива (>= 1) -->  ");
int massNumberColumns = Prompt("Введите количество столбцов массива (>= 1) -->  ");

int[,] mass = new int[massNumberRows, massNumberColumns];
mass = MassRndInject(mass);
MassPrintInt(mass, "Массив -->");

int numberMinMassSumRow = FindInMassRowsMinSum(mass);
System.Console.WriteLine($"Номер строки в массиве с минимальной суммой элементов ---> {numberMinMassSumRow}");
