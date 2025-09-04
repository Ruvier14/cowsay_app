using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter something for the cow to say: ");
        string userInput = Console.ReadLine();

        // Setup process to call cowsay through WSL
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "wsl",                  // Call WSL
            Arguments = $"cowsay \"{userInput}\"", // cowsay inside WSL
            RedirectStandardOutput = true,     // Capture output
            UseShellExecute = false,
            CreateNoWindow = true
        };

        try
        {
            using (Process process = Process.Start(psi))
            {
                string result = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                Console.WriteLine(result);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error running cowsay: " + ex.Message);
        }
    }
}
