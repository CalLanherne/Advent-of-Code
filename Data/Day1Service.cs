using System;
using System.Text.RegularExpressions;
namespace Advent_of_Code.Data
{
    public class Day1Service
    {
        public int SolveDay1Part1(string input)
        {
            string[] lines = input.Split("\n");
            int answer = 0;
            foreach (var line in lines)
            {
                answer += ExtractFirstAndLastDigitsFromString(line);
            }
            return answer;
        }
        private int ExtractFirstAndLastDigitsFromString(string input)
        {
            var firstDigitPattern = @"^[^\d]*(\d)";
            var lastDigitPattern = @"(\d)(?!.*\d)";

            var firstDigit = Regex.Match(input, firstDigitPattern).Groups[1].Value;
            var lastDigit = Regex.Match (input, lastDigitPattern).Groups[1].Value;
            var result = Convert.ToInt32(firstDigit + lastDigit);

            return result;
        }
        public int SolveDay1Part2(string input)
        {
            return 0;
        }
    }
}