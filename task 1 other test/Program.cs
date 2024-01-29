]namespace task_1_other_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> items = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int startIndex = int.Parse(Console.ReadLine());
            string priceRating = Console.ReadLine();

            int leftsum = 0;
            int rightSum = 0;

            if(priceRating == "cheap")
            {
                leftsum = items
                    .Take(startIndex)
                    .Select(x => x <= items[startIndex])
                    .Sum();
                rightSum = items
                    .Skip (startIndex + 1)
                    .Where(x => x < items[startIndex])
                    .Sum();
            }
            else if (priceRating = "expensive")
            {
                leftsum = items
                    .Take(startIndex + 1)
                    .Select(x => x <= items[startIndex])
                    .Sum();
                rightSum = items
                    .Skip(startIndex)
                    .Where(x => x >= items[startIndex])
                    .Sum();



            }
            if(rightSum < leftsum)
            {

            }


        }
    }
}