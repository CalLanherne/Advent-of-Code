using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Advent_of_Code.Data
{
    public class Day4Service
    {
        public long SolveDay4(string input, int part) =>
            part switch
            {
                1 => SolveDay4Part1(input),
                2 => SolveDay4Part2(input),
                _ => throw new ArgumentOutOfRangeException(nameof(part), $"Unsupported part number {part}"),
            };

        private long SolveDay4Part1(string input)
        {
            string[] cards = input.Split("\n");
            long answer = 0;
            foreach (string card in cards)
            {
                var splitCard = card.Split('|');
                var regex = new Regex(@"\s+");
                var pattern = @"Card \d+:\s*";
                var winningNumbers = regex.Split(Regex.Replace(splitCard[0], pattern, "").TrimEnd());
                var playerNumbers = regex.Split(splitCard[1].Trim());
                var intersection = playerNumbers.Intersect(winningNumbers);                
                var numberOfWinningNumbersInPlayerNumbers = intersection.Count();
                var power = numberOfWinningNumbersInPlayerNumbers - 1;
                if (numberOfWinningNumbersInPlayerNumbers > 0)
                {
                    var cardPoints = 1;
                    while (power > 0)
                    {
                        cardPoints = cardPoints * 2;
                        power--;
                    }
                    answer += cardPoints;
                }
            }
            return answer;
        }

        private long SolveDay4Part2(string input)
        {
            int answer = 0;
            return answer;
        }
    }
}