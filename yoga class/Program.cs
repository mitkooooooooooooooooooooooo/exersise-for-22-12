namespace yoga_class
{
    class Program
    {
        static void Main()
        {
            
            string[] pricesInput = Console.ReadLine().Split(' ');
           double priceOfBall = double.Parse(pricesInput[0]);
            double priceOfBlock = double.Parse(pricesInput[1]);
            double priceOfMat = double.Parse(pricesInput[2]);

            int numberOfPeople = int.Parse(Console.ReadLine());

            double totalCost = CalculateTotalCost(priceOfBall, priceOfBlock, priceOfMat, numberOfPeople);

            Console.WriteLine($"{totalCost:f2}$ needed for equipment. ");

        }

        static double CalculateTotalCost(double priceOfBall, double priceOfBlock, double priceOfMat, int numberOfPeople)
        {
           
            int matsNeeded = (int)Math.Ceiling(numberOfPeople * 1.20);

           
            int ballsNeeded = numberOfPeople / 5 + numberOfPeople;

           
            double totalCost = (ballsNeeded * priceOfBall) + (numberOfPeople * 2 * priceOfBlock) + (matsNeeded * priceOfMat);

            return totalCost;

        }
    }

}