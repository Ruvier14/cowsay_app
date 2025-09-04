using System;
using System.Diagnostics; 

#System provides acess to classes like console


class Program {
	static void Main(string[] args) 
	 {
		 Console.Write("Enter what you want for the cow to say: ");
		# waits for user type and press enter
		 string userInput = Console.ReadLine();


		 ProcessStartInfo psi = new ProcessStartInfo 
		 {
			 Filename = "wsl",
			 Arguments = "cowsay \"{userInput}\"",
			 RedirectStandardOuput = true,
			 UseShellExecute = false,
			 CreateNoWindow, true
		 };

		 using (Process process = Process.Start(psi))
		{
			string result = process.StandardOutput.ReadToEnd();
			process.WaitforExit();
			Console.WriteLine(result);
		}
	 }

}
