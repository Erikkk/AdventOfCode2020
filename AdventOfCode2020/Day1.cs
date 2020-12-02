using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day1
    {
        public static async Task SolvePart1Async()
        {
            var numbers = new List<int>();
            using (var reader = File.OpenText("Input\\Day1.txt"))
            {
                string s;
                while ((s = await reader.ReadLineAsync()) != null) numbers.Add(int.Parse(s));
            }

            foreach (var number in numbers)
            {
                var b = numbers.Where(a => 2020 - a == number);
                foreach (var c in b)
                {
                    Console.WriteLine($"{number} {c} {number * c}");
                    Console.ReadLine();
                    return;
                }
            }
        }

        public static async Task SolvePart2Async()
        {
            var numbers = new List<int>();
            using (var reader = File.OpenText("Input\\Day1.txt"))
            {
                string s;
                while ((s = await reader.ReadLineAsync()) != null) numbers.Add(int.Parse(s));
            }

            foreach (var number in numbers)
            foreach (var number2 in numbers)
            {
                var b = numbers.Where(a => 2020 - number - number2 == a);
                foreach (var c in b)
                {
                    Console.WriteLine($"{number} {c} {number2} {number * number2 * c}");
                    Console.ReadLine();
                    return;
                }
            }
        }
    }
}