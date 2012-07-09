using System;
using System.Collections.Generic;
using System.Linq;
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
                    Console.WriteLine("You must specify the inputs with either the /f or /r parameter.");
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

                output = Hash.GetHash(input, parsedArgs.Type);

                if (!string.IsNullOrEmpty(parsedArgs.Out))
                {
                    System.IO.File.WriteAllText(parsedArgs.Out, output);
                }
                else
                {
                    if (parsedArgs.Verbose)
                    {
                        Console.WriteLine("Input:");
                        Console.WriteLine(input);
                        Console.WriteLine("Output:");
                        Console.WriteLine(output);
                    }
                    else
                    {
                        Console.WriteLine(input + "=" + output);
                    }
                }
            }
        }
    }
}