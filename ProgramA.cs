//The work is done on a macbook :).

using System.Security;

//Method that initializes an array according to the rule.
static void NewData(ref double[][] A,int N, int M){
    
    double n = 1;
    for (int i = 0; i < N; ++i)
    {
        for (int j = 0; j < M; j++)
        {
            A[i][j] = (Math.Pow(n, 3) / (Math.Pow(n, 2) + 1)) - (3 * Math.Pow(n, 2) / (3 * n - 1));
            n++;
        }
    }

}

int N, M;

while (true)
{
    //Telling the user how to end the program.
    Console.WriteLine("If you want to end the program, type 'out' and click enter, else click enter");
    if (Console.ReadLine() == "out")
    {
        break;
    }

    //Getting the value of N.
    Console.WriteLine("Please enter the value of 'N'");
    while (!int.TryParse(Console.ReadLine(), out N) || N <= 0 || N > 15)
    {
        Console.WriteLine("'N' must be a natural number less than 16!");
    }

    //Getting the value of M.
    Console.WriteLine("Please enter the value of 'M'");
    while (!int.TryParse(Console.ReadLine(), out M) || M <= 0 || M > 10)
    {
        Console.WriteLine("'M' must be a natural number less than 11!");
    }

    //Creating the array A.
    var A = new double[N][];
    for (int i = 0; i < N; i++)
    {
        A[i] = new double[M];
    }


    //Initializing the array A.
    NewData(ref A, N, M);

    //Getting the name of file.
    Console.WriteLine("Please enter the name of file");
    string fileName = Console.ReadLine();

    //Creating the file.
    string path = $"../../../../{fileName}.txt";

    //Writing N and A in file.
    try
    {
        using (StreamWriter s = File.CreateText(path))
        {
            s.WriteLine(N);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (j != M - 1)
                    {
                        s.Write(string.Format("{0:f3}", A[i][j]) + "??");
                    }
                    else
                    { 
                        s.Write(string.Format("{0:f3}", A[i][j]) + "?");
                    }
                }

                s.WriteLine();
                s.WriteLine();
            }
        }
    }
    catch (SecurityException)
    {
        Console.WriteLine("Sorry, we don't have the permissions to change this file.");
    }
    catch (Exception ex)
    {
         Console.WriteLine($"Exception while saving: {ex.Message}.");
    }
}
