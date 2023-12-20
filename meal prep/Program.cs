namespace meal_prep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> table = new Dictionary<string, int>();
            table.Add("salad", 350);
            table.Add("soup", 490);
            table.Add("pasta", 680);
            table.Add("steak", 790);

            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> calories = new Stack<int>
                (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int mealsCount = 0;
            int leftOvers = 0;
            bool next = true;
            while (meals.Count > 0 && calories.Count > 0)
            {
                string meal = meals.Peek();
                int curCal = calories.Peek();
                int currMealCal = 0;

                if (next)
                {
                    currMealCal = table[meal];
                }
                else
                {
                    currMealCal = leftOvers;
                }


                if (curCal > currMealCal)
                {
                    meals.Dequeue();
                    calories.Pop();
                    curCal -= currMealCal;
                    calories.Push(curCal);
                    mealsCount++;
                    next = true;
                }
                else
                {
                    calories.Pop();
                    currMealCal -= curCal;
                    leftOvers = currMealCal;
                    next = false;

                    if (calories.Count == 0)
                    {
                        meals.Dequeue();
                        mealsCount++;
                    }

                }

            }

            if (meals.Count <= 0)
            {
                Console.WriteLine($"John had {mealsCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else if (calories.Count <= 0)
            {
                Console.WriteLine($"John ate enough, he had {mealsCount} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}