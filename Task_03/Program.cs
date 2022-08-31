// Задача 3: Задайте две матрицы. Напишите программу, которая будет 
// находить произведение двух матриц.
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

int[,] Multiply_AxB(int[,] mass_A_in, int[,] mass_B_in)
{
    int[,] mass_C_in = new int[mass_A_in.GetLength(0), mass_B_in.GetLength(1)];

    for (int i = 0; i < mass_C_in.GetLength(0); i++)
    {
        for (int j = 0; j < mass_C_in.GetLength(1); j++)
        {
            mass_C_in[i, j] = CalcElementMass(mass_A_in, mass_B_in, i, j);
        }
    }
    return mass_C_in;
}

int CalcElementMass(int[,] mass_A_inIn, int[,] mass_B_inIn, int row, int column)
{
    int result = 0;
    for (int i = 0; i < mass_A_inIn.GetLength(1); i++)
    {
        result = result + mass_A_inIn[row, i] * mass_B_inIn[i, column];
    }
    return result;
}

int[,] mass_A_Prim = { { 2, 4 }, { 3, 2 } };
int[,] mass_B_Prim = { { 3, 4 }, { 3, 3 } };
int[,] mass_C_Prim = new int[2, 2];
mass_C_Prim = Multiply_AxB(mass_A_Prim, mass_B_Prim);
MassPrintInt(mass_C_Prim, "Матрица С (С = А х B, пример из задания) -->");


int mass_A_NumberRows = Prompt("Введите количество строк матрицы A (>= 1) -->  ");
int mass_A_NumberColumns = Prompt("Введите количество столбцов матрицы А (>= 1) -->  ");
int mass_B_NumberColumns = Prompt("Введите количество столбцов матрицы B (>= 1) -->  ");
int mass_B_NumberRows = mass_A_NumberColumns;


int[,] mass_A = new int[mass_A_NumberRows, mass_A_NumberColumns];
mass_A = MassRndInject(mass_A);
MassPrintInt(mass_A, "Матрица A -->");

int[,] mass_B = new int[mass_B_NumberRows, mass_B_NumberColumns];
mass_B = MassRndInject(mass_B);
MassPrintInt(mass_B, "Матрица B -->");

int[,] mass_C = new int[mass_A_NumberRows, mass_B_NumberColumns];
mass_C = Multiply_AxB(mass_A, mass_B);
MassPrintInt(mass_C, "Матрица С (С = А х B) -->");
