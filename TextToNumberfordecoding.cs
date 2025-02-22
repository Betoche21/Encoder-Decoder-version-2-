﻿



public class TextToNumber
{
    
    private static readonly Dictionary<char, int> charToNumber = new Dictionary<char, int>
    {
        {'a', 1}, {'b', 2}, {'c', 3}, {'d', 4}, {'e', 5}, {'f', 6}, {'g', 7}, {'h', 8}, {'i', 9},
        {'j', 10}, {'k', 11}, {'l', 12}, {'m', 13}, {'n', 14}, {'o', 15}, {'p', 16}, {'q', 17},
        {'r', 18}, {'s', 19}, {'t', 20}, {'u', 21}, {'v', 22}, {'w', 23}, {'x', 24}, {'y', 25},
        {'z', 26},
        {' ', 27}, 
        {'.', 28}, 
        {',', 29}, 
        {'!', 30}, 
        {'?', 31}, 
        {'"', 32}, 
        {'-', 33}, {'(', 34}, {')', 35}, {':', 46},
        {'0', 36}, {'1', 37}, {'2', 38}, {'3', 39}, {'4', 40}, {'5', 41}, {'6', 42}, {'7', 43}, {'8', 44}, {'9', 45},

    };

   
    // converting
    public static string ConvertNumbersToText(IEnumerable<int> numbers)
    {
        Dictionary<int, char> numberToChar = charToNumber.ToDictionary(x => x.Value, x => x.Key);
        return string.Concat(numbers.Select(n => numberToChar.ContainsKey(n) ? numberToChar[n].ToString() : ""));
    }
}