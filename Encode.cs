

public class Encode : IEncoder
{
    public int[] EncodeMethod1(string sender, string receiver, string message)
    {
        int senderSum = SumOfCharCodes(sender);
        int receiverSum = SumOfCharCodes(receiver);
        int offset = senderSum + receiverSum;

        return ApplyOffset(message, offset);
    }

    public int[] EncodeMethod2(string sender, string receiver, string message)
    {
        int senderSum = SumOfCharCodes(sender);
        int receiverSum = SumOfCharCodes(receiver);
        int offset = (senderSum * receiverSum) / (senderSum + receiverSum);

        return ApplyOffset(message, offset);
    }

    public string EncodeMethod3(string message) => ConvertToMorse(message);
    


    private string ConvertToMorse(string message)
    {
        Dictionary<char, string> morseDictionary = new Dictionary<char, string>
        {
            {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."},
            {'E', "."}, {'F', "..-."}, {'G', "--."}, {'H', "...."},
            {'I', ".."}, {'J', ".---"}, {'K', "-.-"}, {'L', ".-.."},
            {'M', "--"}, {'N', "-."}, {'O', "---"}, {'P', ".--."},
            {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
            {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"},
            {'Y', "-.--"}, {'Z', "--.."},
            {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
            {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."},
            {'8', "---.."}, {'9', "----."},
            {' ', "/"}, {'?', "..--.."}, {'!', "-.-.--"}, {'.', ".-.-.-"}, {',', "--..--"}, {':', "---..."}, {'-', "-....-"}, {'(', ".--..-"}, {')', ".--.-..."}, {'"', "--.-..-"},
        };

        message = message.ToUpper();
        string morseCode = "";

        foreach (char c in message)
        {
            if (morseDictionary.TryGetValue(c, out string? value))
            {
                morseCode += value + " ";
            }
        }

        return morseCode.Trim();
    }
       


    private int SumOfCharCodes(string text)
    {
        int sum = 0;
        int[] numbers = TextToNumber.ConvertTextToNumbers(text);
        foreach (int num in numbers)
        {
            sum += num;
        }
        return sum;
    }

    private int[] ApplyOffset(string message, int offset)
    {
        int[] messageNumbers = TextToNumber.ConvertTextToNumbers(message);
        for (int i = 0; i < messageNumbers.Length; i++)
        {
            messageNumbers[i] += offset;
        }
        return messageNumbers;
    }

    
}
