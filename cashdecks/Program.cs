namespace cashdecks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] efficiency = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int count = int.Parse(Console.ReadLine());

            int TotalEfficiency = efficiency[0] + efficiency[1] + efficiency[2];
            int time = 0;
            for (int i = 0; i <= 100000; ++i)
            {
                if (count == 0)
                {
                    break;
                }
                if (i % 4 == 0)
                {

                }
                else
                {
                    count -= TotalEfficiency;
                    if (count <= 0)
                    {
                        time = i;
                        break;
                    }
                }
            }
            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}