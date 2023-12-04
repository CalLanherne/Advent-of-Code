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
            if (input.Length == 0)
            {
                return 0;
            }

            var firstDigitPattern = @"^[^\d]*(\d)";
            var lastDigitPattern = @"(\d)(?!.*\d)";

            var firstDigit = Regex.Match(input, firstDigitPattern).Groups[1].Value;
            var lastDigit = Regex.Match (input, lastDigitPattern).Groups[1].Value;
            var result = Convert.ToInt32(firstDigit + lastDigit);

            return result;
        }

        public int SolveDay1Part2(string input)
        {
            string[] lines = input.Split("\n");
            int answer = 0;
            foreach (var line in lines)
            {
                answer += ExtractFirstAndLastDigitsAndNumberTextFromString(line);
            }
            return answer;
        }

        private int ExtractFirstAndLastDigitsAndNumberTextFromString(string input)
        {
            if (input.Length == 0)
            {
                return 0;
            }

            Dictionary<string, string> textMapping = new Dictionary<string, string>();
            textMapping.Add("0","0");
            textMapping.Add("1", "1");
            textMapping.Add("2", "2");
            textMapping.Add("3", "3");
            textMapping.Add("4", "4");
            textMapping.Add("5", "5");
            textMapping.Add("6", "6");
            textMapping.Add("7", "7");
            textMapping.Add("8", "8");
            textMapping.Add("9", "9");
            textMapping.Add("zero", "0");
            textMapping.Add("one", "1");
            textMapping.Add("two", "2");
            textMapping.Add("three", "3");
            textMapping.Add("four", "4");
            textMapping.Add("five", "5");
            textMapping.Add("six", "6");
            textMapping.Add("seven", "7");
            textMapping.Add("eight", "8");
            textMapping.Add("nine", "9");




            var firstDigitPattern = @"(one|two|three|four|five|six|seven|eight|nine|zero|\d)";
            var lastDigitPattern = @"(\d|one|two|three|four|five|six|seven|eight|nine|zero)(?!.*(?:\d|one|two|three|four|five|six|seven|eight|nine|zero))";

            var firstDigit = Regex.Match(input, firstDigitPattern).Groups[1].Value;
            var lastDigit = Regex.Match(input, lastDigitPattern).Groups[1].Value;
            var result = Convert.ToInt32(textMapping[firstDigit] + textMapping[lastDigit]);

            return result;
        }

        
    }
}