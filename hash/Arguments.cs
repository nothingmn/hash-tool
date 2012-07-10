using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hash
{
    
    public class Arguments
    {
        [Argument(ArgumentType.AtMostOnce, DefaultValue = Hash.HashType.MD5, HelpText = "Hash algorithm to use.", ShortName = "t")]
        public Hash.HashType Type;

        [Argument(ArgumentType.AtMostOnce, HelpText = "Raw string to hash.", ShortName = "r")]
        public string RawInput;

        [Argument(ArgumentType.AtMostOnce, HelpText = "File to read, and hash.", ShortName = "f")]
        public string File;

        [Argument(ArgumentType.AtMostOnce, HelpText = "File to write the hash result to.", ShortName = "o")]
        public string Out;

        [Argument(ArgumentType.AtMostOnce, DefaultValue = false, HelpText = "Verbose output", ShortName = "v")]
        public bool Verbose;


    }
}
