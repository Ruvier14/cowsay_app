using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter something for the cow to say: ");
        string? userInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("No input provided.");
            return;
        }

        // debug this and make sure to call cowsay in wsl
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "cowsay",
            Arguments = $"\"{userInput}\"",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };


    }
}

