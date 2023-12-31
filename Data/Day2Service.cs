using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Advent_of_Code.Data
{
    public class Day2Service
    {
        public int SolveDay2(string input, int part) =>
            part switch
            {
                1 => SolveDay2Part1(input, 12, 13, 14),
                2 => SolveDay2Part2(input),
                _ => throw new ArgumentOutOfRangeException(nameof(part), $"Unsupported part number {part}"),
            };

        private int SolveDay2Part1(string input, int redNumber, int greenNumber, int blueNumber )
        {
            string[] games = input.Split("\n");
            var answer = 0;
            foreach (string game in games)
            {
                if (MaxValueForColour(game, "green") <= greenNumber && MaxValueForColour(game, "blue") <= blueNumber && MaxValueForColour(game, "red") <= redNumber)
                {
                    var pattern = @"Game (\d+)";
                    var match = Regex.Match(game, pattern);
                    answer += Convert.ToInt32(match.Groups[1].Value);
                }
            }
            return answer;
        }

        private int MaxValueForColour(string game, string colour)
        {
            var pattern = string.Format(@"(\d+)(?: {0})", colour);
            var matches = Regex.Matches(game, pattern);
            List<int> values = new List<int>();
            values.Add(0);
            foreach (Match match in matches)
            {
                values.Add(Convert.ToInt32(match.Groups[1].Value));
            }
            return values.Max();
        }

        private int SolveDay2Part2(string input)
        {
            string[] games = input.Split("\n");
            var answer = 0;
            foreach (string game in games)
            {
                answer += MaxValueForColour(game, "green") * MaxValueForColour(game, "blue") * MaxValueForColour(game, "red");                
            }
            return answer;
        }
    }
}