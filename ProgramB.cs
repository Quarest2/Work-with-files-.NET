//The work is done on a macbook :).


//Method that processing an array according to the rule.
static void ArrProcessing(double[][] B,ref double[][] res)
{
    for (int i = 0; i < B.Length; i ++)
    {
        double[] add = new double[B[i].Length / 2];
        res = res.ToList().Append(add).ToArray();
        for(int j = 0; j < B[i].Length; j++)
        {
            if(j % 2 == 1)
            {
                res[i][j/2] = Math.Abs(B[i][j]);
            }
        }
    }
}

// Method that reading the file and saving it in array.
static void ArrReading(string path, ref double[][] B)
{
    try
    {
        //Looking for a file and open it.
        StreamReader sr = new StreamReader(path);
        string line = sr.ReadLine();

        //Checking that the file is not empty.
        if (line == null)
        {
            Console.WriteLine("Error: file is empty");
        }

        //Reading the file line by line and writing the result in B.
        string[] words;
        double[] numbers;
        int len;
        while (line != null)
        {
            words = line.Split('?', StringSplitOptions.RemoveEmptyEntries);
            len = words.Length;
            numbers = new double[len];
            for (int i = 0; i < len; i++)
            {
                if (!double.TryParse(words[i], out numbers[i]))
                {
                    Console.WriteLine("Error: incorrect data provided");
                    B = new double[0][];
                    return;
                }
            }
            B = B.ToList().Append(numbers).ToArray();
            line = sr.ReadLine();
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception: " + e.Message);
    }
}



while (true)
{
    //Telling the user how to end the program.
    Console.WriteLine("If you want to end the program, type 'out' and click enter, else click enter");
    if (Console.ReadLine() == "out")
    {
        break;
    }

    double[][] B = new double[0][];

    // Reading the file and checking that it have right values.
    while (B.Length == 0)
    {
        Console.WriteLine("Please enter the name of file");
        string fileName = Console.ReadLine();
        string path = $"../../../../{fileName}.txt";
        ArrReading(path, ref B);
    }

    //Processing B using the method.
    double[][] res = new double[0][];
    ArrProcessing(B, ref res);


    //Output the array before and after proccessing.
    Console.WriteLine();
    Console.WriteLine("Before:");
    foreach (double[] i in B)
    {
        foreach (double j in i)
        {
            Console.Write(string.Format("{0:f3}", j) + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    Console.WriteLine("After:");
    foreach (double[] i in res)
    {
        foreach (double j in i)
        {
            Console.Write(string.Format("{0:f3}", j) + " ");
        }
        Console.WriteLine();
    }
}
