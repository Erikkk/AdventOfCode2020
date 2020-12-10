using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day5
    {
        public static async Task SolvePart1Async()
        {
            var seats = new List<double>();
            using (var reader = File.OpenText("Input\\Day5.txt"))
            {
                string s;

                while ((s = await reader.ReadLineAsync()) != null)
                {
                    double max = 127, min = 0;
                    var rows = s.Substring(0, 7).ToCharArray();
                    foreach (var upDown in rows)
                    {
                        calc(upDown, ref max, ref min);
                    }

                    var row = min;
                    var columns = s.Substring(7, 3).ToCharArray();
                    min = 0;
                    max = 7;
                    foreach (var leftRight in columns)
                    {
                        calc(leftRight, ref max, ref min);
                    }

                    var column = min;
                    var seat = row * 8 + column;
                    seats.Add(seat);
                    Console.WriteLine($"{s}: row {row}, column {column}, seat ID {seat}");
                }
            }

            Console.WriteLine($"Highest seat ID {(seats.Max())}");
            Console.ReadLine();
        }

        private static void calc(char uppDown, ref double max, ref double min)
        {
            var diff = (max - min);
            var remove = Math.Ceiling(diff / 2.0);
            if (uppDown == 'F' || uppDown == 'L')
            {
                max -= remove;
            }
            else
            {
                min += remove;
            }
        }

        private static bool validatePassport(Dictionary<string, string> passport)
        {
            var template = new Dictionary<string, bool>
            {
                {"byr", false},
                {"iyr", false},
                {"eyr", false},
                {"hgt", false},
                {"hcl", false},
                {"ecl", false},
                {"pid", false},
                {"cid", false}
            };
            foreach (var value in passport)
                if (template.Keys.Contains(value.Key))
                    template[value.Key] = true;

            var correct = template.All(a => a.Value || a.Key == "cid");
            return correct;
        }

        public static async Task SolvePart2Async()
        {
            var seats = new List<double>();
            using (var reader = File.OpenText("Input\\Day5.txt"))
            {
                string s;

                while ((s = await reader.ReadLineAsync()) != null)
                {
                    double max = 127, min = 0;
                    var rows = s.Substring(0, 7).ToCharArray();
                    foreach (var upDown in rows)
                    {
                        calc(upDown, ref max, ref min);
                    }

                    var row = min;
                    var columns = s.Substring(7, 3).ToCharArray();
                    min = 0;
                    max = 7;
                    foreach (var leftRight in columns)
                    {
                        calc(leftRight, ref max, ref min);
                    }

                    var column = min;
                    var seat = row * 8 + column;
                    seats.Add(seat);
                    Console.WriteLine($"{s}: row {row}, column {column}, seat ID {seat}");
                }
            }

            // var frontOrBack = seats.Where(a => !seats.Contains(a - 1) || !seats.Contains(a + 1)).ToArray();
            // foreach (var seatId in frontOrBack)
            // {
            //     seats.Remove(seatId);
            // }
            var allSeats = new List<double>();
            for (double i = seats.Min(); i < seats.Max(); i++)
            {
                allSeats.Add(i);
            }

            foreach (var seat in seats)
            {
                allSeats.Remove(seat);
            }

            Console.WriteLine($"My Seat ID {allSeats[0]}");
            Console.ReadLine();
        }
    }
}