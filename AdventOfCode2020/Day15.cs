using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day15
    {
        public static async Task SolvePart1Async()
        {
            var lines = new List<( string operation, int argument)?>();
            int accumulator = 0;

            using (var reader = File.OpenText("Input\\Day15.txt"))
            {
                string s;

                while ((s = await reader.ReadLineAsync()) != null)
                {
                    var spoken = s.Split(",").Select(a => int.Parse(a)).ToList();

                    for (var i = spoken.Count; i < 2020; i++)
                    {
                        var lastSpoken = spoken[(i - 1)];
                        var length = spoken.Count - 2;
                        var secondLastIndex = spoken.FindLastIndex(length, length + 1, (i1 => i1 == lastSpoken));
                        var newValue = 0;
                        if (secondLastIndex != -1)
                            newValue = i - 1 - secondLastIndex;
                        if (i % 10000 == 0)
                            Console.WriteLine($"Turn {i + 1} Spoken {newValue}");
                        if (i > 30000000 - 2)
                            Console.WriteLine($"Turn {i + 1} Spoken {newValue}");
                        spoken.Add(newValue);
                    }
                }
            }


            Console.WriteLine($"accumulator is {accumulator} ");
            Console.ReadLine();
        }


        public static async Task SolvePart2Async()
        {
            int accumulator = 0;
            var start = DateTime.Now;
            using (var reader = File.OpenText("Input\\Day15.txt"))
            {
                string s;
                while ((s = await reader.ReadLineAsync()) != null)
                {
                    var lines = new Dictionary<int, int>();
                    var spoken = s.Split(",").Select(a => int.Parse(a)).ToList();
                    for (var index = 0; index < spoken.Count; index++)
                    {
                        var sp = spoken[index];
                        lines.Add(sp, index);
                    }

                    var newValue = 0;
                    var lastSpoken = spoken[(^1)];
                    var i = spoken.Count - 1;
                    for (; i < 30000000 - 1; i++)
                    {
                        // var secondLastIndex = -1;
                        if (lines.ContainsKey(lastSpoken))
                        {
                           var secondLastIndex = lines[lastSpoken];
                            lines[lastSpoken] = i;
                            lastSpoken = i - secondLastIndex;
                        }
                        else
                        {
                            lines.Add(lastSpoken, i);
                            lastSpoken = 0;
                        }

                        // if (i % 1000000 == 0)
                        //     Console.WriteLine($"Turn {i + 2} Spoken {newValue}");
                        // if (i > 30000000 - 3)
                        //     Console.WriteLine($"Turn {i + 2} Spoken {newValue}");
                        // lastSpoken = newValue;
                        // Console.WriteLine($"Turn {i + 2} Spoken {newValue}");
                    }

                    Console.WriteLine($"Turn {i + 2} Spoken {newValue}");
                }
            }

            var end = DateTime.Now.Subtract(start);
            Console.WriteLine($"Finished in {end} ");
            Console.ReadLine();
        }


        public static async 

        Task
Bichis()
        {

            int accumulator = 0;
            var start = DateTime.Now;
            var times = 30000000;
            var current = (double)0;
            using (var reader = File.OpenText("Input\\Day15.txt"))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {


                    start = DateTime.Now;
                    var parts = line.Trim().Split(',');
                    var spoken = new Dictionary<double, int>();
                    var count = 1;
                    current = (double) 0;

                    foreach (var p in parts)
                    {
                        spoken.Add(double.Parse(p), count);
                        current = double.Parse(p);
                        count++;
                    }

                    while (count < times + 1)
                    {
                        if (spoken.ContainsKey(current) && spoken[current] != count - 1)
                        {
                            var a = count - 1;
                            var b = spoken[current];
                            var sum = a - b;

                            spoken[current] = count - 1;
                            current = sum;
                        }
                        else
                        {
                            if (!spoken.ContainsKey(current))
                            {
                                spoken.Add(current, count - 1);
                            }

                            current = 0;
                        }

                        count++;
                    }

                    //Console.WriteLine("Number of time spoken: " + current.ToString());
                }

                Console.WriteLine(DateTime.Now - start);
                Console.WriteLine(current.ToString());

       
            }
        }
    }
}