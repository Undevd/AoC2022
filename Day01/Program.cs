namespace Day01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int runningTotal = 0;
            SortedSet<int> calories = new SortedSet<int>();
            foreach (string line in File.ReadLines(@"Calories.txt"))
            {
                if(line == String.Empty)
                {
                    calories.Add(runningTotal);
                    runningTotal = 0;
                    continue;
                }
                runningTotal += int.Parse(line);
            }
            Console.WriteLine($"Part A {calories.Last()}");
            Console.WriteLine($"Part B {calories.TakeLast(3).Sum()}");
        }
    }
}