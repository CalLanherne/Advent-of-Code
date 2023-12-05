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
            Dictionary<string, Dictionary<long, long>> allMapping = new Dictionary<string, Dictionary<long, long>>();
            for (var i = 1; i < blocks.Length; i++)            {
                
                var block = blocks[i];
                var lines = block.Split("\n").ToList();
                var header = lines[0].ToString();
                lines.RemoveAt(0);
                string[] dataString = lines.ToArray();
                Dictionary<long, long> mapping = new Dictionary<long, long>();
                foreach (var dataLine in dataString) 
                {
                    var rangeData = Array.ConvertAll(whitespaceRegex.Split(dataLine), long.Parse);
                    var sourceStart = rangeData[1];
                    var destinationStart = rangeData[0];
                    var count = rangeData[2];
                    for(var j = 0;j < count; j++)
                    {
                        mapping.Add(sourceStart + j, destinationStart + j);                        
                    }
                }
                if (header != null)
                {
                    allMapping.Add(header, mapping);
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

        private long MapSourceDestination(long source, Dictionary<long, long> map)
        {
            long destination;
            if (!map.TryGetValue(source,out destination))
            {
                destination = source;
            }
            return destination;
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