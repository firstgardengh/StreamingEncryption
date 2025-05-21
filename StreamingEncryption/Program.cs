using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Threading;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        string url = "https://example.com/file.bin";
        string filename = Path.Combine(Directory.GetCurrentDirectory(), "file.bin");

        Console.WriteLine("Streaming data..");
        Console.WriteLine();

        byte[] image = ProtectedData.Protect(new WebClient().DownloadData(url), null, DataProtectionScope.CurrentUser);

        if (image == null)
            exit("Failed to stream image (null image)");

        Console.WriteLine("File downloaded and encrypted successfully.");
        Console.WriteLine("Press enter to decrypt it and place it on disk.");
        Console.ReadLine();

        File.WriteAllBytes(filename, ProtectedData.Unprotect(image, null, DataProtectionScope.CurrentUser));

        if (!File.Exists(filename))
            exit("Failed to find file");

        Console.WriteLine("Press enter to exit.");
        Console.ReadLine();
        return;
    }

    public static void exit(string msg, int delay = 1500)
    {
        Console.WriteLine(msg);
        Thread.Sleep(delay);
        Environment.Exit(0);
    }
}

