using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Advent_of_Code.Data
{
    public class Day3Service
    {
        public int SolveDay3(string input, int part) =>
            part switch
            {
                1 => SolveDay3Part1(input),
                2 => SolveDay3Part2(input),
                _ => throw new ArgumentOutOfRangeException(nameof(part), $"Unsupported part number {part}"),
            };

        private int SolveDay3Part1(string input)
        {
            int answer = 0;
            var span = FindSpan(input);
            string inputLinear = input.Replace("\n", "");
            var numbers = FindNumbers(inputLinear);
            var symbols = FindNonDigitNonPeriods(inputLinear);
            foreach (var number in numbers)
            {
                var indices = FindAdjacentIndices(number.Item1, number.Item2, span);
                var intersection = indices.Intersect(symbols).ToArray();
                if (intersection.Length > 0)
                {
                    answer += number.Item3;
                }
            }
            return answer;
        }

        private List<int> FindNonDigitNonPeriods(string input)
        {
            var pattern = @"((?!(\.|\d)).)";
            var matches = Regex.Matches(input, pattern);
            List<int> positions = new List<int>();
            foreach (Match match in matches)
            {
                positions.Add(match.Index);
            }
            return positions;
        }

        private int FindSpan(string input)
        {
            char[] inputArray = input.ToCharArray();
            var i = 0;
            while (inputArray[i] != '\n')
            {
                i++;
            }
            return i;
        }

        private List<int> FindAdjacentIndices(int start, int stop, int span)
        {
            
            var startOfLine = start % span == 0;
            var endOfLine = (stop + 1) % span == 0;

            var previousLineStart = Math.Max(0, startOfLine ? start - span : start - span - 1);
            var previousLineStop = Math.Max(0, endOfLine ? stop - span : stop - span + 1);
            var nextLineStart = startOfLine ? start + span : start + span - 1;
            var nextLineStop = endOfLine ? stop + span : stop + span + 1;

            List<int> indices = Enumerable.Range(previousLineStart, previousLineStop - previousLineStart + 1).ToList();
            indices.AddRange(Enumerable.Range(nextLineStart, nextLineStop - nextLineStart + 1).ToList());
            if (!startOfLine)
            {
                indices.Add(start - 1);
            }
            if (!endOfLine)
            {
                indices.Add(stop + 1);
            }
            return indices;
        }
        private List<Tuple<int, int, int>> FindNumbers(string input)
        {
            var numbers = new List<int>();
            var pattern = @"(\d+)";
            var matches = Regex.Matches(input, pattern);
            List<Tuple<int, int, int>> positions = new List<Tuple<int, int, int>>();
            foreach (Match match in matches)
            {
                positions.Add(Tuple.Create(match.Index, match.Index + match.Value.Length - 1, Convert.ToInt32(match.Value)));
            }
            return positions;
        }

        private int SolveDay3Part2(string input)
        {
            string[] games = input.Split("\n");
            var answer = 0;
            return answer;
        }
    }
}