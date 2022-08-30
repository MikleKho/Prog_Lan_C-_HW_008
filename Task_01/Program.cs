﻿// Задача 1: Задайте двумерный массив. Напишите программу, которая 
// упорядочит по убыванию элементы каждой строки двумерного массива.
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

int[,] SortingInMassRows(int[,] massInside)
{
    for (int i = 0; i < massInside.GetLength(0); i++)
    {
        bool changeElementFlag = true;
        int elementTemp = massInside[i, 0];
        while (changeElementFlag)
        {
            changeElementFlag = false;
            for (int j = 1; j < massInside.GetLength(1); j++)
            {
                if (massInside[i, j] > massInside[i, j-1])
                {
                elementTemp = massInside[i,j-1];
                massInside[i, j-1] = massInside[i,j];
                massInside[i,j] = elementTemp;
                changeElementFlag = true;
                }
            }
        }
    }

    return massInside;
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
mass = SortingInMassRows(mass);
MassPrintInt(mass, "Массив с сортировкой строк по убыванию -->");

