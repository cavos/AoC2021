using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    internal class Day03_binaryDiagnostic
    {
        public static void Solve_pt1()
        {
            var binaryReadings = ReadPuzzleInput();
            int[] zerosCount = CountZeroBits(binaryReadings);

            string gammaRate = string.Empty;
            string epsilonRate = string.Empty;
            int readingsCount = binaryReadings.Count() / 2;
            foreach (var coeff in zerosCount)
            {
                gammaRate += coeff > readingsCount ? '0' : '1';
                epsilonRate += coeff > readingsCount ? '1' : '0';
            }

            Console.WriteLine("Day 03-1: power consumption of submarine is: " + (Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2)));
        }

        public static void Solve_pt2()
        {
            var binaryReadings = ReadPuzzleInput().ToList();
            ReadingNode root = new();
            ConstructTree(binaryReadings, root);
            string oxygenGeneratorRating = ReadOxygenGeneratorRating(root);
            string co2ScrubberRating = ReadCo2ScrubberRating(root);

            Console.WriteLine("Day 03-2: life support rating of submarine is: " + (Convert.ToInt32(oxygenGeneratorRating, 2) * Convert.ToInt32(co2ScrubberRating, 2)));
        }

        private static string ReadOxygenGeneratorRating(ReadingNode root)
        {
            string oxygenGeneratorRating = string.Empty;
            ReadingNode? rnode2 = root;
            while (true)
            {
                if (rnode2 == null || rnode2.IsLeaf())
                    break;
                if (rnode2.Zeros?.Count > rnode2.Ones?.Count)
                {
                    oxygenGeneratorRating += '0';
                    rnode2 = rnode2.Zeros;
                }
                else
                {
                    oxygenGeneratorRating += '1';
                    rnode2 = rnode2.Ones;
                }
            }

            return oxygenGeneratorRating;
        }

        private static string ReadCo2ScrubberRating(ReadingNode root)
        {
            string co2ScrubberRating = string.Empty;
            ReadingNode? rnode2 = root;
            while (true)
            {
                if (rnode2 == null || rnode2.IsLeaf())
                    break;
                if (rnode2.Ones == null || rnode2.Zeros?.Count <= rnode2.Ones?.Count)
                {
                    co2ScrubberRating += '0';
                    rnode2 = rnode2.Zeros;
                }
                else
                {
                    co2ScrubberRating += '1';
                    rnode2 = rnode2.Ones;
                }
            }

            return co2ScrubberRating;
        }

        private static void ConstructTree(List<string> binaryReadings, ReadingNode root)
        {
            foreach (var reading in binaryReadings)
            {
                ReadingNode? rnode = root;
                foreach (var bit in reading)
                {
                    if (bit == '1')
                    {
                        if (rnode.Ones == null)
                            rnode.Ones = new ReadingNode();
                        rnode = rnode.Ones;
                    }
                    else
                    {
                        if (rnode.Zeros == null)
                            rnode.Zeros = new ReadingNode();
                        rnode = rnode.Zeros;
                    }
                    rnode.Count += 1;
                }
            }
        }

        private class ReadingNode
        {
            public int Count { get; set; }
            public ReadingNode? Zeros { get; set; }
            public ReadingNode? Ones { get; set; }

            public bool IsLeaf()
            {
                return Zeros==null && Ones==null;
            }

            //public int depth { get; set; }
            //public List<string> zeros { get; set; }
            //public List<string> ones { get; set; }
        }

        private static string FindReadingByMask(List<string> readings, string mask)
        {
            string reading = string.Empty;
            while (true)
            {
                var candidateList = readings.FindAll(x => x.StartsWith(mask));
                if (candidateList.Count == 1)
                {
                    reading = candidateList[0];
                    break;
                }
                else
                    mask = mask[0..^1];
            }

            return reading;
        }

        private static int[] CountZeroBits(IEnumerable<string> binaryReadings)
        {
            int[] zerosCount = new int[binaryReadings.First().Length];
            foreach (var reading in binaryReadings)
            {
                for (int i = 0; i < reading.Length; ++i)
                    if (reading[i] == '0')
                        zerosCount[i]++;
            }

            return zerosCount;
        }

        private static IEnumerable<String> ReadPuzzleInput()
        {
            return File.ReadLines("puzzle_input/day03.txt");
        }
    }
}
