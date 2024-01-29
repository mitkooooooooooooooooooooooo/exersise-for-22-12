namespace road_saftey
{

    class Program
    {
        static void Main()
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int totalCarsPassed = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "STOP")
                {
                    Console.WriteLine($"Success!");
                    Console.WriteLine($"{totalCarsPassed} total cars are gone.");
                    return;
                }

                if (input == "light")
                {
                    int currentGreenLight = greenLightDuration;

                    while (currentGreenLight > 0 && cars.Count > 0)
                    {
                        string currentCar = cars.Dequeue();
                        int carLength = currentCar.Length;

                        if (carLength <= currentGreenLight)
                        {
                            totalCarsPassed++;
                            currentGreenLight -= carLength;
                        }
                        else
                        {
                            int charactersLeft = carLength - currentGreenLight;
                            Console.WriteLine($"Accident!");
                            Console.WriteLine($"{currentCar} was crushed at {currentCar[currentCar.Length - charactersLeft]}.");
                            return;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
        }
    }

}