using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    public class PadCodes
    {
        public Dictionary<String, List<String>> codes { get; set; } = new Dictionary<string, List<String>>
        {
            {"1", new List<String> { "&", "'", "(" } },
            {"2", new List<String> { "A", "B", "C"} },
            {"3", new List<String> { "D", "E", "F"} },
            {"4", new List<String> { "G", "H", "I"} },
            {"5", new List<String> { "J", "K", "L"} },
            {"6", new List<String> { "M", "N", "O"} },
            {"7", new List<String> { "P", "Q", "R","S"} },
            {"8", new List<String> { "T", "U", "V"} },
            {"9", new List<String> { "W", "X", "Y","Z"} },
            {"0", new List<String> { " "} },
            {"*", new List<String> { "-1"} },
            {"#", new List<String> { "1"} }
        };

        public Boolean IsValidCode(String code)
        {
            if (!this.codes.ContainsKey(code.ToString()))
            {
                return false;
            }

            return true;
        }

    }
}

