
//RunTaskSeven();
//RunTaskEight();
RunTaskNine();


void RunTaskSeven()
{
    int start = int.Parse(Console.ReadLine());
    int end = int.Parse(Console.ReadLine());
    Thread evens = new Thread(() => PrintEvenNumbers(start, end));
    evens.Start();
    evens.Join();
    Console.WriteLine("Thread finished work.");
    void PrintEvenNumbers(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}

void RunTaskEight()
{
    string command;
    while(true)
    {
        command = Console.ReadLine();
        if(command == "show")
        {
            Console.WriteLine(SumNumbers1To1000());
        }
    }
    static int SumNumbers1To1000()
    {
        return Task.Run(() =>
        {
            int result = 0;
            for (int i = 0; i <= 1000; i++)
            {
                if (i % 2 == 0)
                {
                    result += i;
                }
            }

            return result;
        }).Result;
    }
}

void RunTaskNine()
{
    long sum = 0;
    var task = Task.Run(() =>
    {
        for (long i = 0; i <= 100_000_000; i++)
        {
            if (i % 2 == 0)
            {
                sum += i;
            }
        }
    });

    while(true)
    {
        string command = Console.ReadLine();

        if(command == "exit")
        {
            return;
        }
        else if (command == "show")
        {
            Console.WriteLine(sum);
        }
    }
}

