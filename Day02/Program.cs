using Day02.Extensions;

namespace Day02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int scoreA = 0, scoreB = 0;
            foreach (string round in File.ReadLines(@"Rounds.txt"))
            {
                var x = round.Split(' ');
                scoreA += Process(x[0].ToShape(), x[1].ToShape());
                scoreB += Process(x[0].ToShape(), ParseResult(x[0].ToShape(), x[1]));
            }
            Console.WriteLine($"Part A {scoreA}");
            Console.WriteLine($"Part B {scoreB}");
        }

        private static int Process(Shape them, Shape me)
        {
            // Lose - 0
            // Draw - 3
            // Win - 6
            int score = ((int)me);

            if(them.Equals(me))
            {
                score += 3;
            }
            else if(
                (them == Shape.Rock && me == Shape.Paper) ||
                (them == Shape.Paper && me == Shape.Scissors) ||
                (them == Shape.Scissors && me == Shape.Rock))
            {
                score += 6;
            }

            return score;
        }

        private static Shape ParseResult(Shape them, string result)
        {
            Shape outcome;
            switch(result)
            {
                case "X":
                    if(them == Shape.Rock) { outcome = Shape.Scissors; }
                    else if (them == Shape.Paper) { outcome = Shape.Rock; }
                    else { outcome = Shape.Paper; }
                    break;
                case "Z":
                    if (them == Shape.Rock) { outcome = Shape.Paper; }
                    else if (them == Shape.Paper) { outcome = Shape.Scissors; }
                    else { outcome = Shape.Rock; }
                    break;
                    default: { outcome = them; break; }

            }
            return outcome;
        }
    }
}