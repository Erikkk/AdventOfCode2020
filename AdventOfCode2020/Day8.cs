using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day8
    {
        public static async Task SolvePart1Async()
        {
            var lines = new List<( string operation, int argument)?>();
            int accumulator = 0;

            using (var reader = File.OpenText("Input\\Day8.txt"))
            {
                string s;

                while ((s = await reader.ReadLineAsync()) != null)
                {
                    var kv = s.Split(" ");
                    lines.Add(item: (kv[0], int.Parse(kv[1])));
                }
            }

            int index = 0;

            int skippFix = 0;

            var result = Recurse(lines, index, ref accumulator, true);

            Console.WriteLine($"accumulator is {accumulator} ");
            Console.ReadLine();
        }

        private static bool? Recurse(List<(string operation, int argument)?> lines, int index, ref int accumulator,
            bool retry, bool change = false)
        {
            var newLines = new (string operation, int argument)?[lines.Count];
            lines.CopyTo(newLines);
            if (!lines[index].HasValue)
            {
                return false;
            }

            int i = index;
            int newIndex = index;
            int newAccumulator = accumulator;
            var operation = lines[index].Value.operation;

            if (change)
            {
                if (operation == "jmp")
                    operation = "nop";
                else if (operation == "nop")
                {
                    operation = "jmp";
                }
                else
                {
                    // error
                }
            }

            calc(operation, newLines[index].Value.argument, ref newIndex, ref newAccumulator);

            if (newIndex == lines.Count)
            {
                Console.WriteLine("finished");
                return null;
            }

            newLines[i] = null;
            var result = Recurse(newLines.ToList(), newIndex, ref newAccumulator, retry);
            if (result == null || result == true)
            {
                accumulator = newAccumulator;
                return result;
            }
            else if (retry) // retry
            {
                //invalid termination
                Console.WriteLine($"Invalid termination. Accumulator is {accumulator}, Operation {operation}");
                newAccumulator = accumulator;
                result = Recurse(newLines.ToList(), newIndex, ref newAccumulator, false, true);
                if (result == null || result == true)
                {
                    accumulator = newAccumulator;
                    return result;
                }
            }

            return false;
        }

        private static void calc(string operation, int argument, ref int index, ref int accumulator)
        {
            switch (operation)
            {
                case "acc":
                    accumulator += argument;
                    index++;
                    break;
                case "jmp":
                    index += argument;
                    break;
                case "nop":
                    index++;
                    break;
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
                }
            }

            Console.WriteLine($"My Seat ID ");
            Console.ReadLine();
        }
    }
}