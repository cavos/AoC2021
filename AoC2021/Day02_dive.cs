using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    internal class Day02_dive
    {
        public static void Solve_pt1()
        {
            int horizontalPosition = 0;
            int verticalPosition = 0;

            var puzzleInput = ReadPuzzleInput();
            foreach (var step in puzzleInput)
	        {
                if (step.Item1 == "forward")
                    horizontalPosition += step.Item2;
                else if (step.Item1 == "down")
                    verticalPosition += step.Item2;
                else if (step.Item1 == "up")
                    verticalPosition -= step.Item2;
            }

            Console.WriteLine("Day 02-1: horizontal position times vertical position: " + horizontalPosition*verticalPosition);
        }

        public static void Solve_pt2()
        {
            int horizontalPosition = 0;
            int depth = 0;
            int aim = 0;

            var puzzleInput = ReadPuzzleInput();
            foreach (var step in puzzleInput)
            {
                switch (step.Item1)
                {
                    case "down":
                        aim += step.Item2;
                        break;
                    case "up":
                        aim -= step.Item2;
                        break;
                    case "forward":
                        horizontalPosition += step.Item2;
                        depth += aim * step.Item2;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("unsupported command: " + step.Item1);
                }
            }
        
            Console.WriteLine("Day 02-2: horizontal position times vertical position: " + horizontalPosition*depth);
        }

        private static IEnumerable<Tuple<String, int>> ReadPuzzleInput()
        {
            return File.ReadAllLines("puzzle_input/day02.txt").Select(x =>
            {
                var input = x.Split(' ');
                return Tuple.Create(input[0], int.Parse(input[1]));
            });
        }
    }    
}
