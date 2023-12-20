namespace manOfWar
{

    class Program
    {
        static void Main()
        {
            List<int> pirateShip = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            List<int> warship = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            int maxHealth = int.Parse(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "Retire")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                switch (action)
                {
                    case "Fire":
                        int fireIndex = int.Parse(tokens[1]);
                        int damage = int.Parse(tokens[2]);

                        if (fireIndex >= 0 && fireIndex < warship.Count)
                        {
                            warship[fireIndex] -= damage;

                            if (warship[fireIndex] <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                return;
                            }
                        }
                        break;

                    case "Defend":
                        int defendStartIndex = int.Parse(tokens[1]);
                        int defendEndIndex = int.Parse(tokens[2]);
                        damage = int.Parse(tokens[3]);

                        if (defendStartIndex >= 0 && defendEndIndex < pirateShip.Count)
                        {
                            for (int i = defendStartIndex; i <= defendEndIndex; i++)
                            {
                                pirateShip[i] -= damage;

                                if (pirateShip[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken. ");
                                    return;
                                }
                            }
                        }
                        break;

                    case "Repair":
                        int repairIndex = int.Parse(tokens[1]);
                        int health = int.Parse(tokens[2]);

                        if (repairIndex >= 0 && repairIndex < pirateShip.Count)
                        {
                            pirateShip[repairIndex] += health;
                            if (pirateShip[repairIndex] > maxHealth)
                            {
                                pirateShip[repairIndex] = maxHealth;
                            }
                        }
                        break;

                    case "Status":
                        int sectionsToRepair = pirateShip.Count(section => section < 0.2 * maxHealth);
                        Console.WriteLine($"{sectionsToRepair} sections need repair.");
                        break;
                }
            }

            Console.WriteLine($"Pirate ship status: {string.Join(">", pirateShip)}");
            Console.WriteLine($"Warship status: {string.Join(">", warship)}");
        }
    }

}    












