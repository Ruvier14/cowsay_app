using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user
        Console.Write("Enter what you want for the cow to say: ");
        string? userInput = Console.ReadLine();
	
	// if user does not input anything -- then cow does not say anything 
	if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("Cow has nothing to say ");
            return;
        }


        // Setup process to run cowsay inside WSL
	var psi = new ProcessStartInfo("cowsay", userInput)
        {
            RedirectStandardOutput = true,          // capture output
            UseShellExecute = false,                // required for redirection
            CreateNoWindow = true                   // don’t show extra terminal window
        };

        try
        {
            {
		// process to not be nullified read by the system 
		// add ! operator fi the process is not null since if its cowsay
		// then a process exist anyways
		using var process = Process.Start(psi)!;    
                string result = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                Console.WriteLine(result);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error running cowsay: {ex.Message}");
        }
    }
}

