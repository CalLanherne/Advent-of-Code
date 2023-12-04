using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Advent_of_Code.Data
{
    public class Day2Service
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
            string[] games = input.Split("\n");
            var answer = 0;
            
            return answer;
        }

        private int SolveDay3Part2(string input)
        {
            string[] games = input.Split("\n");
            
            return answer;
        }
    }
}