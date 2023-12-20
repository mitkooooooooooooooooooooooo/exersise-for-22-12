namespace worms_and_hOleS_yummy
{
    
    class Program
    {
        static void Main()
        {
            List<int> worms = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> holes = Console.ReadLine().Split().Select(int.Parse).ToList();

            int matchesCount = 0;

            for (int i = worms.Count - 1; i >= 0; i--)
            {
                if (holes.Count == 0)
                {
                    break;
                }

                if (worms[i] == holes[0])
                {
                    matchesCount++;
                    worms.RemoveAt(i);
                    holes.RemoveAt(0);
                }
                else
                {
                    holes.RemoveAt(0);
                    worms[i] -= 3;

                    if (worms[i] <= 0)
                    {
                        worms.RemoveAt(i);
                    }
                }
            }

            Console.WriteLine($"Matches: {matchesCount}");

            if (worms.Count == 0)
            {
                Console.WriteLine("Every worm found a suitable hole!");
            }
            else if (holes.Count == 0)
            {
                Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
            }
            else
            {
                Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
                Console.WriteLine($"Holes left: {string.Join(", ", holes)}");
            }
        }
    }

}