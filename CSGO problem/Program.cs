namespace CSGO_problem
{
    class Program
    {
        static void Main()
        {
            int initialEnergy = int.Parse(Console.ReadLine());

            int wonBattles = 0;

            string input;
            while ((input = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(input);

                if (initialEnergy < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with  {wonBattles} won battles and {initialEnergy} energy");
                    return;
                }

                initialEnergy -= distance;
                wonBattles++;

                if (wonBattles % 3 == 0)
                {
                    initialEnergy += wonBattles;
                }
            }

            Console.WriteLine($"Won battles: {wonBattles} Energy left: {initialEnergy}");
        }
    }

}