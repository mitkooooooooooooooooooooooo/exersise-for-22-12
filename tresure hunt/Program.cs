namespace tresure_hunt
{
     class Program
     {
        static void Main()
        {
            List<string> treasureChest = Console.ReadLine().Split('|').ToList();

            string command;
            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                switch (action)
                {
                    case "Loot":
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            if (!treasureChest.Contains(tokens[i]))
                            {
                                treasureChest.Insert(0, tokens[i]);
                            }
                        }
                        break;

                    case "Drop":
                        int index = int.Parse(tokens[1]);
                        if (index >= 0 && index < treasureChest.Count)
                        {
                            string removedItem = treasureChest[index];
                            treasureChest.RemoveAt(index);
                            treasureChest.Add(removedItem);
                        }
                        break;

                    case "Steal":
                        int count = int.Parse(tokens[1]);
                        count = Math.Min(count, treasureChest.Count);
                        List<string> stolenItems = treasureChest.Skip(treasureChest.Count - count).ToList();
                        treasureChest.RemoveRange(treasureChest.Count - count, count);
                        Console.WriteLine(string.Join(", ", stolenItems));
                        break;
                }
            }

            if (treasureChest.Count > 0)
            {
                double averageGain = treasureChest.Sum(item => item.Length) / (double)treasureChest.Count;
                Console.WriteLine($"Average treasure gain: {averageGain:F2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
     }

}