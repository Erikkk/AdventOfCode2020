using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day4
    {
        public static async Task SolvePart1Async()
        {
            var valid = 0;
            var invalid = 0;
            var passport = new Dictionary<string, string>();
            using (var reader = File.OpenText("Input\\Day4.txt"))
            {
                string s;

                while ((s = await reader.ReadLineAsync()) != null)
                {
                    if (string.IsNullOrWhiteSpace(s))
                    {
                        if (validatePassport(passport))
                            valid++;
                        else
                            invalid++;

                        passport = new Dictionary<string, string>();
                        continue;
                    }

                    foreach (var keyValue in s.Split(' '))
                    {
                        var kv = keyValue.Split(':');
                        passport.Add(kv[0], kv[1]);
                    }
                }
            }

            if (passport.Count > 0)
            {
                if (validatePassport(passport))
                    valid++;
                else
                    invalid++;
            }

            Console.WriteLine($"valid: {valid} invalid: {invalid}");
            Console.ReadLine();
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
            var valid = 0;
            var invalid = 0;
            var passport = new Dictionary<string, string>();
            using (var reader = File.OpenText("Input\\Day4.txt"))
            {
                string s;

                while ((s = await reader.ReadLineAsync()) != null)
                {
                    if (string.IsNullOrWhiteSpace(s))
                    {
                        if (validatePassport2(passport))
                            valid++;
                        else
                            invalid++;

                        passport = new Dictionary<string, string>();
                        continue;
                    }

                    foreach (var keyValue in s.Split(' '))
                    {
                        var kv = keyValue.Split(':');
                        passport.Add(kv[0], kv[1]);
                    }
                }
            }

            if (passport.Count > 0)
            {
                if (validatePassport2(passport))
                    valid++;
                else
                    invalid++;
            }

            Console.WriteLine($"valid: {valid} invalid: {invalid}");
            Console.ReadLine();
        }

        private static bool validatePassport2(Dictionary<string, string> passport)
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
                {
                    var v = validateValue(value.Key, value.Value);
                    template[value.Key] = v;
                }

            var correct = template.All(a => a.Value || a.Key == "cid");
            return correct;
        }

        private static bool validateValue(string key, string value)
        {
            switch (key)
            {
                case "byr": return Regex.IsMatch(value, @"^(19[2-9][0-9]|200[0-2])$", RegexOptions.None);
                case "iyr": return Regex.IsMatch(value, @"^(201[0-9]|2020)$", RegexOptions.None);
                case "eyr": return Regex.IsMatch(value, @"^(202[0-9]|2030)$", RegexOptions.None);
                case "hgt":
                    return Regex.IsMatch(value, @"^(1([5-8][0-9]|9[0-3])cm|(59|6[0-9]|7[0-6])in)$", RegexOptions.None);
                case "hcl": return Regex.IsMatch(value, @"^#([0-9a-f]{6})$", RegexOptions.None);
                case "ecl": return Regex.IsMatch(value, @"^(amb|blu|brn|gry|grn|hzl|oth)$", RegexOptions.None);
                case "pid": return Regex.IsMatch(value, @"^([0-9]{9})$", RegexOptions.None);
                case "cid": return true;
            }

            return false;
        }
    }
}