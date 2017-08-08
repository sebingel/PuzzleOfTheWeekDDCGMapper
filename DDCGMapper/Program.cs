using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static void Main()
    {
        var patterns = new List<KeyValuePair<string, int>>();

        int numberOfLines = int.Parse(Console.ReadLine());
        int numberOfPatterns = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfPatterns; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string pattern = inputs[0];
            int tempo = int.Parse(inputs[1]);

            patterns.Add(new KeyValuePair<string, int>(pattern, tempo));
        }

        //var patternInput = new List<string> { "X000 2", "00XX 3" };
        //int numberOfLines = 7;
        //int numberOfPatterns = 2;
        //for (int i = 0; i < numberOfPatterns; i++)
        //{
        //    string[] inputs = patternInput[i].Split(' ');
        //    string pattern = inputs[0];
        //    int tempo = int.Parse(inputs[1]);

        //    patterns.Add(new KeyValuePair<string, int>(pattern, tempo));
        //}

        for (int i = numberOfLines; i > 0; i--)
        {
            var patternsForLine = patterns.FindAll(x => i % x.Value == 0);

            Console.WriteLine(AccumulatePatterns(patternsForLine));
        }
    }

    private static string AccumulatePatterns(List<KeyValuePair<string, int>> patternsForLine)
    {
        var result = new char[4];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = patternsForLine.Any(x => x.Key[i] == 'X') ? 'X' : '0';
        }

        return string.Join(string.Empty, result);
    }
}