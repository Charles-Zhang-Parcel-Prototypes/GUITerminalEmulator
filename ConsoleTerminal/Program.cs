using System.Diagnostics;

namespace ConsoleTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Directory.GetCurrentDirectory();

            while (true)
            {
                Console.Write($"{workingDirectory}> ");
                string input = Console.ReadLine();

                string[] parameters = input.Split();
                string program = parameters.First();
                string[] arguments = parameters.Skip(1).ToArray();

                if (program == "cd")
                {
                    workingDirectory = string.Join(" ", arguments);
                    continue;
                }

                // Run
                Process process = Process.Start(new ProcessStartInfo()
                {
                    FileName = program,
                    Arguments = string.Join(" ", arguments),

                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = workingDirectory
                });
                process.Start();

                string outputs = process.StandardOutput.ReadToEnd();
                Console.WriteLine(outputs);
            }
        }
    }
}
