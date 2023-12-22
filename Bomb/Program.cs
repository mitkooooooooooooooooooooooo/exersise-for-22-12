namespace Bomb
{
    class Program
    {
        static void Main()
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            // int createdBombs = int.Parse(Console.ReadLine());
            Dictionary<string, int> createdBombs = new Dictionary<string, int>  // got a litlle help for that one 
        {
            {"Cherry Bombs", 0},
            {"Datura Bombs", 0},
            {"Smoke Decoy Bombs", 0}
        };

            while (bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                int currentEffect = bombEffects.Peek();
                int currentCasing = bombCasings.Peek();
                int sum = currentEffect + currentCasing;

                if (sum == 40)
                {
                    createdBombs["Datura Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (sum == 60)
                {
                    createdBombs["Cherry Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (sum == 120)
                {
                    createdBombs["Smoke Decoy Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else
                {
                    bombCasings.Push(bombCasings.Pop() - 5);
                }

                if (createdBombs.All(pair => pair.Value >= 3))
                {
                    break;
                }
            }

            if (createdBombs.All(pair => pair.Value >= 3))
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");

            foreach (var bomb in createdBombs.OrderBy(b => b.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }

}