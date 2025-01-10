class MorseCodeConverter
{
    private static readonly Dictionary<string, char> morseCodeDictionary = new Dictionary<string, char>
    {
        { ".-", 'A' }, { "-...", 'B' }, { "-.-.", 'C' }, { "-..", 'D' }, { ".", 'E' },
        { "..-.", 'F' }, { "--.", 'G' }, { "....", 'H' }, { "..", 'I' }, { ".---", 'J' },
        { "-.-", 'K' }, { ".-..", 'L' }, { "--", 'M' }, { "-.", 'N' }, { "---", 'O' },
        { ".--.", 'P' }, { "--.-", 'Q' }, { ".-.", 'R' }, { "...", 'S' }, { "-", 'T' },
        { "..-", 'U' }, { "...-", 'V' }, { ".--", 'W' }, { "-..-", 'X' }, { "-.--", 'Y' },
        { "--..", 'Z' }, { "-----", '0' }, { ".----", '1' }, { "..---", '2' }, { "...--", '3' },
        { "....-", '4' }, { ".....", '5' }, { "-....", '6' }, { "--...", '7' }, { "---..", '8' },
        { "----.", '9' }, { "/", ' ' }, {"..--..", '?'}, {"-.-.--", '!'}, {".-.-.-", '.'}, {"--..--", ','}, {"---...", ':'}, {"-....-", '-'}, {".--..-", '('}, {".--.-...", ')'}, {"--.-..-", '"'},
    };

    public static string ConvertMorseToText(string morseCode)
    {
        string[] morseWords = morseCode.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string result = "";

        foreach (string morseChar in morseWords)
        {
            if (morseCodeDictionary.TryGetValue(morseChar, out char letter))
            {
                result += letter;
            }
        }

        return result;
    }
}
