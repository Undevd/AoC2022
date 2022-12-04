namespace Day03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var total = 0;
            var groups = new List<List<string>>();
            var group = new List<string>();

            foreach (string backpack in File.ReadLines(@"Backpacks.txt"))
            {
                group.Add(backpack);

                if(group.Count == 3)
                {
                    groups.Add(group);

                    var match = GroupMatch(group).ToCharArray();
                    group = new List<string>();

                    total += ToPriority(match.FirstOrDefault());
                }
            }
            Console.WriteLine(total);
        }

        public static List<string> ToCompartments(string backpack)
        {
            return new List<string>
            {
                backpack.Substring(0, backpack.Length / 2),
                backpack.Substring(backpack.Length /2)
            };
        }

        public static string FindMatch(string compartmentA, string compartmentB)
        {
            return compartmentA.AsEnumerable().Where(x => compartmentB.Contains(x)).FirstOrDefault().ToString();
        }

        public static string GroupMatch(List<string> backpacks)
        {

            var matches = backpacks[0].AsEnumerable().Where(x => backpacks[1].Contains(x)).ToList();
            return matches.AsEnumerable().Where(x => backpacks[2].Contains(x)).FirstOrDefault().ToString();
        }

        public static int ToPriority(char item)
        {
            var code = (int)item;

            if(code >= (int)'a' && code <= (int)'z')
            {
                return (int)item - ((int)'a' - 1);
            }
            else
            {
                return (int)item - (int)'A' + 27;
            }
            
        }
    }
}