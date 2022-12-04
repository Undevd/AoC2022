namespace Day04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var countA = 0;
            var countB = 0;
            foreach (string assignmentStr in File.ReadLines(@"Assignments.txt"))
            {
                var elves = new List<Assignment>();
                var assignments = assignmentStr.Split(",");
                foreach (var a in assignments)
                {
                    elves.Add(new Assignment(a));
                }

                if (DoesOverlapComplete(elves[0], elves[1]))
                {
                    countA += 1;
                    countB += 1;
                }
                else if(DoesOverlapPartial(elves[0], elves[1]))
                {
                    countB += 1;
                }
            }
            Console.WriteLine($"Complete Overlap: {countA}");
            Console.WriteLine($"Partial Overlap: {countB}");
        }

        private static bool DoesOverlapComplete(Assignment a, Assignment b)
        {
            var largest = a.Range >= b.Range ? a : b;
            var smallest = largest.Equals(a) ? b : a;

            return smallest.Lower >= largest.Lower && smallest.Upper <= largest.Upper ? true : false;
        }

        private static bool DoesOverlapPartial(Assignment a, Assignment b)
        {
            var lowest = a.Lower <= b.Lower ? b : a;
            var highest = lowest.Equals(a) ? b : a;

            return (highest.Lower >= lowest.Lower && highest.Lower <= lowest.Upper) ||
                    (highest.Upper >= lowest.Lower && highest.Upper <= lowest.Upper) ? true : false;
        }
    }

    public class Assignment
    {
        public Assignment(string rangeStr)
        {
            var range = rangeStr.Split('-');

            this.Lower = int.Parse(range[0]);
            this.Upper = int.Parse(range[1]);
            Range = Upper - Lower;

        }

        public int Lower;
        public int Upper;
        public int Range;
    }
}