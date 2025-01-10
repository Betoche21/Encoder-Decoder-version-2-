public class Decoder : IDecode
{
    private Dictionary<char, int> alphabetMap;

    public Decoder()
    {
        alphabetMap = new Dictionary<char, int>();
        for (char c = 'a'; c <= 'z'; c++) alphabetMap[c] = c - 'a' + 1;
    }

    private int CalculateKey(string sender, string receiver, int method)
    {
        int senderSum = sender.ToLower().Sum(c => alphabetMap.ContainsKey(c) ? alphabetMap[c] : 0);
        int receiverSum = receiver.ToLower().Sum(c => alphabetMap.ContainsKey(c) ? alphabetMap[c] : 0);

        if (method == 1)
        {
            return senderSum + receiverSum;
        }
        else if (method == 2)
        {
            return (int)Math.Floor((double)(senderSum * receiverSum) / (senderSum + receiverSum));
        }
        else if (method == 3)
        {
            return 0; // No key needed for Morse decoding
        }
        else
        {
            throw new InvalidProgramException("Invalid option");
        }
    }

    private List<int> ReadFile(string filePath)
    {
        string fileExtension = Path.GetExtension(filePath).ToLower();

        if (!File.Exists(filePath))
            throw new FileNotFoundException("File not found!");

        string[] lines = File.ReadAllLines(filePath);
        List<int> numbers = new List<int>();

        if (fileExtension == ".txt" || fileExtension == ".csv")
        {
            numbers = lines.SelectMany(line => line.Split(new[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                           .Select(int.Parse).ToList();
        }
        else if (fileExtension == ".ini")
        {
            foreach (var line in lines)
            {
                var parts = line.Split('=');
                if (parts.Length == 2 && int.TryParse(parts[1], out int number))
                {
                    numbers.Add(number);
                }
            }
        }
        else
        {
            throw new NotSupportedException("Unsupported file format!");
        }

        return numbers;
    }

    public string Decode(string filePath, string sender, string receiver, int method)
    {
        if (method == 3) // Morse decoding
        {
            string morseCode = File.ReadAllText(filePath);
            return MorseCodeConverter.ConvertMorseToText(morseCode);
        }

        List<int> numbers = ReadFile(filePath);
        int key = CalculateKey(sender, receiver, method);
        List<int> decodedNumbers = numbers.Select(n => n - key).ToList();

        return TextToNumber.ConvertNumbersToText(decodedNumbers);
    }
}
