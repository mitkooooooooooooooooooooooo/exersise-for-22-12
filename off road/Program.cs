namespace off_road
{
   

    class Program
    {
        static void Main()
        {
            List<int> initialFuel = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> consumptionIndexes = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> neededFuel = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> reachedAltitudes = new List<int>();
            bool failedToReachTop = false;

            while (initialFuel.Count > 0 && neededFuel.Count > 0)
            {
                int currentFuel = initialFuel.Last();
                int currentConsumptionIndex = consumptionIndexes.First();
                int currentNeededFuel = neededFuel.First();

                int result = currentFuel - currentConsumptionIndex;

                if (result >= currentNeededFuel)
                {
                    reachedAltitudes.Add(currentNeededFuel);
                    initialFuel.RemoveAt(initialFuel.Count - 1);
                    consumptionIndexes.RemoveAt(0);
                    neededFuel.RemoveAt(0);
                }
                else
                {
                    if (reachedAltitudes.Count > 0)
                    {
                        failedToReachTop = true;
                        break;
                    }
                    else
                    {
                        failedToReachTop = true;
                        break;
                    }
                }
            }

            if (failedToReachTop)
            {
                Console.WriteLine("John failed to reach the top.");

                if (reachedAltitudes.Count > 0)
                {
                    Console.WriteLine($"Reached altitudes: {string.Join(", ", reachedAltitudes.Select(a => $"Altitude {a}"))}");
                }
                else
                {
                    Console.WriteLine("John didn't reach any altitude.");
                }
            }
            else
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }
        }
    }

}