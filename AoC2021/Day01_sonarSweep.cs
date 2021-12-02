namespace AoC2021
{
    public class Day01_sonarSweep
    {
        public static void Solve_pt1()
        {
            IEnumerable<int> depths = ReadPuzzleInput();
            int increasesCount = SumDepthIncreases(depths);
            Console.WriteLine("Day 01-1: number of times a depth measurement increases: " + increasesCount);
        }

        public static void Solve_pt2()
        {
            var depths = ReadPuzzleInput();
            var averagedDepths = depths.Zip(depths.Skip(1), depths.Skip(2)).Select(x => x.First + x.Second + x.Third);
            int increasesCount = SumDepthIncreases(averagedDepths);
            Console.WriteLine("Day 01-2: number of times a depth measurement (averaged) increases: " + increasesCount);
        }

        private static IEnumerable<int> ReadPuzzleInput()
        {
            return File.ReadAllLines("puzzle_input/day01.txt").Select(x => int.Parse(x));
        }

        private static int SumDepthIncreases(IEnumerable<int> depths)
        {
            return depths.Zip(depths.Skip(1), Tuple.Create).Sum(x => x.Item1 < x.Item2 ? 1 : 0);
        }
    }
}
