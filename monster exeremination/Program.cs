namespace monster_exeremination
{  
    class Program
    {
        static void Main()
        {
            List<int> monsters = Console.ReadLine().Split(",").Select(int.Parse).ToList();
            List<int> hits = Console.ReadLine().Split(",").Select(int.Parse).ToList();

            int killedMonsters = 0;

            while (monsters.Count > 0 && hits.Count > 0)
            {
                int monsterArmor = monsters[0];
                int soldierStrike = hits[hits.Count - 1];

                if (soldierStrike >= monsterArmor)
                {
                    monsters.RemoveAt(0);
                    hits.RemoveAt(hits.Count - 1);

                    if (hits.Count > 0)
                    {
                        hits[hits.Count - 1] += soldierStrike - monsterArmor;
                    }
                }
                else
                {
                    monsters[0] -= soldierStrike;
                    hits.RemoveAt(hits.Count - 1);
                    monsters.Add(monsters[0]);
                    monsters.RemoveAt(0);
                }

                killedMonsters++;

                if (monsters.Count == 0)
                {
                    Console.WriteLine("All monsters have been killed!");
                    Console.WriteLine($"Total monsters killed: {killedMonsters}");
                }
                else if (hits.Count == 0)
                {
                    Console.WriteLine("The soldier has been defeated.");
                    Console.WriteLine($"Total monsters killed: {killedMonsters}");
                }
            }
        }
    }

}