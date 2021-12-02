using System.Diagnostics;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Advent of Code 2021!");
Console.WriteLine("");

var stopwatch = new Stopwatch();

AoC2021.Day01_sonarSweep.Solve_pt1();
AoC2021.Day01_sonarSweep.Solve_pt2();
AoC2021.Day02_dive.Solve_pt1();
AoC2021.Day02_dive.Solve_pt2();

Console.WriteLine("");
System.Console.WriteLine("Elapsed time: " + stopwatch.Elapsed);
