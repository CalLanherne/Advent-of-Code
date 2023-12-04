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
            var span = FindSpan(input);
            string inputLinear = input.Replace("\n", "");
            FindNumbers(inputLinear);
            var answer = 0;
            //foreach ( var line in lines ) 
            //{
            //    FindNonDigitNonPeriod(line);
            //}
            return answer;
        }
        private int FindNonDigitNonPeriod(string line)
        {
            var pattern = @"((?!(\.|\d)).)";
            var match = Regex.Match(line, pattern);

            return 0;
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

        private int FindAdjacentIndices(int start, int stop, int span)
        {
            //build in modular arithmetic
            var previousLineStart = start - span - 1;
            var previousLineStope = stop - span + 1;
            var nextLineStart = start + span - 1;
            return 0;
        }
        private List<Tuple<int, int, int>> FindNumbers(string input)
        {
            var numbers = new List<int>();
            var pattern = @"(\d+)";
            var matches = Regex.Matches(input, pattern);
            List<Tuple<int, int, int>> positions = new List<Tuple<int, int, int>>();
            foreach (Match match in matches)
            {
                positions.Add(Tuple.Create(match.Index, match.Index + match.Value.Length, Convert.ToInt32(match.Value)));
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