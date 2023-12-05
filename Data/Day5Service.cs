using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Advent_of_Code.Data
{
    public class Day5Service
    {
        public long SolveDay5(string input, int part) =>
            part switch
            {
                1 => SolveDay5Part1(input),
                2 => SolveDay5Part2(input),
                _ => throw new ArgumentOutOfRangeException(nameof(part), $"Unsupported part number {part}"),
            };

        private long SolveDay5Part1(string input)
        {
            string[] blocks = input.Split("\n\n");
            var whitespaceRegex = new Regex(@"\s+");
            var seedLine = whitespaceRegex.Split(blocks[0]).ToList();
            seedLine.RemoveAt(0);
            var seeds = Array.ConvertAll(seedLine.ToArray(), long.Parse);
            List<long> seedDestination = new List<long>();
            Dictionary<string, List<long[]>> allMapping = new Dictionary<string, List<long[]>>();
            for (var i = 1; i < blocks.Length; i++)            {
                
                var block = blocks[i];
                var lines = block.Split("\n").ToList();
                var header = lines[0].ToString();
                lines.RemoveAt(0);
                string[] dataString = lines.ToArray();
                List<long[]> rules = new List<long[]>();
                foreach (var dataLine in dataString) 
                {
                    var rangeData = Array.ConvertAll(whitespaceRegex.Split(dataLine), long.Parse);
                    rules.Add(rangeData);
                }
                if (header != null)
                {
                    allMapping.Add(header, rules);
                }                
            }

            foreach (var seed in seeds)
            {
                var currentValue = seed;
                foreach (var key in allMapping.Keys)
                {
                    currentValue = MapSourceDestination(currentValue, allMapping[key]);
                }
                seedDestination.Add(currentValue);
            }
            long answer = seedDestination.Min();
            return answer;
        }

        private long MapSourceDestination(long source, List<long[]> rules)
        {
            foreach (var rule in rules)
            {
                if ( source >= rule[1] && source < rule[1] + rule[2])
                {
                    return rule[0] + source - rule[1];
                }
            }
            return source;
        }

        private long SolveDay5Part2(string input)
        {
            string[] cards = input.Split("\n");
            long answer = 0;
            return answer;
        }
        //private int[,] MapFromSourceToDestination(string[] input)
        //{
        //    List<int> sources = new List<int>();
        //    List<int> destination = new List<int>();

        //}
    }
}