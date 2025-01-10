

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your text:");
        string message = Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Enter the sender's name:");
        string sender = Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Enter the receiver's name:");
        string receiver = Console.ReadLine();
        Console.Clear();

        IEncoder encoder = new Encode();

        Console.WriteLine("Choose the encoding method (1 or 2 or 3):");
        string choice = Console.ReadLine();
        Console.Clear();

        int[] encodedMessage = null;
        
        string encodedMessage2= null;
        
        if (choice == "1")
        {
            encodedMessage = encoder.EncodeMethod1(sender, receiver, message);
        }
        else if (choice == "2")
        {
            encodedMessage = encoder.EncodeMethod2(sender, receiver, message);
        }
        else if (choice == "3")
        {
            encodedMessage2 = encoder.EncodeMethod3(message);
        }
        else
        {
            Console.WriteLine("Invalid option.");
            return;
        }

        


        Console.WriteLine("Enter file path:");
        string path = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Enter the file's name:");
        string filename = Console.ReadLine();
        Console.Clear();

        // ذخیره فایل‌ها
        if (encodedMessage2 == null && encodedMessage != null)
        {
            SaveAsTxt(encodedMessage, Path.Combine(path, filename + ".txt"));
            SaveAsIni(encodedMessage, Path.Combine(path, filename + ".ini"));
            SaveAsCsv(encodedMessage, Path.Combine(path, filename + ".csv"));
        }
        else if (encodedMessage2 != null && encodedMessage == null)
        {
            SaveAsTxt2(encodedMessage2, Path.Combine(path, filename + ".txt"));
        }

        Console.WriteLine("Done.");
    }

    static void SaveAsTxt2(string data, string filePath)
    {

        File.WriteAllText(filePath, string.Join(" ", data));
    }

    static void SaveAsTxt(int[] data, string filePath)
    {

        File.WriteAllText(filePath, string.Join(" ", data)); 
    }

    

    static void SaveAsIni(int[] data, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("[EncodedData]");
            for (int i = 0; i < data.Length; i++)
            {
                writer.WriteLine($"Value{i + 1}={data[i]}");
            }
        }
    }

    static void SaveAsCsv(int[] data, string filePath)
    {
        File.WriteAllText(filePath, string.Join(",", data));
    }

}