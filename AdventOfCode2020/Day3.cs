using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day3
    {
        public static async Task SolvePart1Async()
        {
            var tree = 0;
            var open = 0;
            var index = 0;
            using (var reader = File.OpenText("Input\\Day3.txt"))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var s = line;
                    try
                    {
                        while (s.Length <= index) s += line;

                        if (s[index] == '.')
                        {
                            var c = s.Substring(0, index) + "O" + s.Substring(index, s.Length - index);
                            Console.WriteLine(c);
                            open++;
                        }
                        else
                        {
                            var c = s.Substring(0, index) + "X" + s.Substring(index, s.Length - index);
                            Console.WriteLine(c);
                            tree++;
                        }
                    }
                    catch (Exception e)
                    {
                    }

                    index += 3;
                }
            }

            Console.WriteLine($"open: {open} Trees: {tree}");
            Console.ReadLine();
        }

        public static async Task SolvePart2Async()
        {
            var trees = new List<int>
            {
                await countTrees(1, 1),
                await countTrees(3, 1),
                await countTrees(5, 1),
                await countTrees(7, 1),
                await countTrees(1, 2)
            };

            long product = 1;
            foreach (var factor in trees)
            {
                product = product * factor;
                Console.WriteLine($"Number of tress {factor}");
            }

            Console.WriteLine($"Product = {product}");
            Console.ReadLine();
        }

        private static async Task<int> countTrees(int right, int down)
        {
            var treeCount = 0;
            var openCount = 0;
            var index = 0;
            using (var reader = File.OpenText("Input\\Day3.txt"))
            {
                string line;
                var downIndex = -1;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    downIndex++;
                    if (downIndex == 1)
                        index += right;
                    if (downIndex < down)
                    {
                        Console.WriteLine(line);
                        continue;
                    }

                    var s = line;
                    try
                    {
                        while (s.Length <= index) s += line;

                        if (s[index] == '.')
                            openCount++;
                        else
                            treeCount++;
                    }
                    catch (Exception e)
                    {
                    }

                    if (downIndex == down) downIndex = 0;
                }
            }

            Console.WriteLine($"open: {openCount} Trees: {treeCount} Sum: {openCount + treeCount}");
            return treeCount;
        }
    }
}