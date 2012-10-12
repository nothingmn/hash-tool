using System;
using System.Collections.Generic;
using System.Text;

namespace hash
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && !args[0].StartsWith("/") && !string.IsNullOrEmpty(args[0]))
            {
                args[0] = "/r:" + args[0];
            }
            Arguments parsedArgs = new Arguments();
            if (Parser.ParseArgumentsWithUsage(args, parsedArgs))
            {
                if(string.IsNullOrEmpty(parsedArgs.File) && string.IsNullOrEmpty(parsedArgs.RawInput))
                {
                    Console.WriteLine("You must specify the inputs with either the /f or /r parameter (or use /? for help).");
                    return;
                }
                string input = "";
                string output = "";
                if (!string.IsNullOrEmpty(parsedArgs.RawInput))
                {
                    input = parsedArgs.RawInput;
                }
                else
                {
                    if (!string.IsNullOrEmpty(parsedArgs.File))
                    {
                        if (!System.IO.File.Exists(parsedArgs.File))
                        {
                            Console.WriteLine("File specified with the /f FILE parameter, must exist.");
                            return;
                        }
                        input = System.IO.File.ReadAllText(parsedArgs.File);
                    }
                    else
                    {
                        input = string.Join(" ", args);
                    }
                }
				System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
				sw.Start ();
                output = Hash.GetHash(input, parsedArgs.Type);
				sw.Stop ();
                if (!string.IsNullOrEmpty(parsedArgs.Out))
                {
                    System.IO.File.WriteAllText(parsedArgs.Out, output);
                }
                else
                {
                    if (parsedArgs.Verbose)
                    {
						int max = 100;
						if(input.Length<max) max = input.Length;
						string inputMessage = input.Substring(0, max);
						if(!string.IsNullOrEmpty(parsedArgs.File)) inputMessage = parsedArgs.File + " (file)";
                        Console.WriteLine(string.Format("Input:{0}", inputMessage));
                        Console.WriteLine(string.Format("Output:{0}", output));
                        Console.WriteLine(string.Format("Duration:{0}ms", sw.ElapsedMilliseconds));
                    }
                    else
                    {
                        Console.WriteLine(output);
                    }
                }
            }
        }
    }
}