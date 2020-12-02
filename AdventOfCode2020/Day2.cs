using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day2
    {
        public static async Task SolvePart1Async()
        {
            var correct = 0;
            var incorrect = 0;
            using (var reader = File.OpenText("Input\\Day2.txt"))
            {
                string s;
                while ((s = await reader.ReadLineAsync()) != null)
                {
                    var b = s.Split(':');
                    var rule = b[0].Split(' ');
                    var c = rule[0].Split('-');
                    var countOccurrences = b[1].Count(a => a == rule[1][0]);
                    var min = int.Parse(c[0]);
                    var max = int.Parse(c[1]);
                    if (countOccurrences >= min && countOccurrences <= max)
                        correct++;
                    else
                        incorrect++;
                }
            }

            Console.WriteLine($"correct: {correct} Incorrect: {incorrect}");
            Console.ReadLine();
        }

        public static async Task SolvePart2Async()
        {
            var correct = 0;
            var incorrect = 0;
            try
            {
                using var reader = File.OpenText("Input\\Day2.txt");
                string s;
                while ((s = await reader.ReadLineAsync()) != null)
                {
                    var b = s.Split(':');
                    var rule = b[0].Split(' ');
                    var c = rule[0].Split('-');

                    var key = rule[1][0];
                    var password = b[1].Trim();
                    var first = int.Parse(c[0]);
                    var second = int.Parse(c[1]);

                    if ((password[first - 1] == key || password[second - 1] == key) &&
                        password[first - 1] != password[second - 1])
                        correct++;
                    else
                        incorrect++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.WriteLine($"correct: {correct} Incorrect: {incorrect}");
            Console.ReadLine();
        }
    }
}