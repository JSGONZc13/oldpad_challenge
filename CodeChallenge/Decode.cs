using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    public class Decode
    {
        // Decode the input code based on the pad codes, returning the corresponding character
        public String DecodedInput(String code)
        {
            PadCodes padCodes = new PadCodes();
            String keyCodes = code[0].ToString();
            List<String> codes = new List<String>();
            if (padCodes.codes.ContainsKey(keyCodes))
            {
                codes = padCodes.codes[keyCodes];
                int codePressCount = code.Length;
                int codePosition = (codePressCount - 1) % codes.Count;
                return codes[codePosition];
            }
            else
            {
                return "?";
            }
        }

        // Clean the decoded message parts by removing the last part if it is "-1" (delete) and joining the rest
        public string CleanMessageParts(List<string> decodedCodes)
        {
            List<string> cleanString = new List<string>();

            foreach (string code in decodedCodes)
            {
                if (code == "-1")
                {
                    if (cleanString.Count > 0)
                    {
                        cleanString.RemoveAt(cleanString.Count - 1);
                    }
                }
                else
                {
                    cleanString.Add(code);
                }
            }

            return string.Join("", cleanString).Replace("1", "");
        }

        // Decode the input message, validating it and returning the decoded message or an error message
        public String DecodedMessage(String input)
        {
            ValidateCodeList validateCodeList = new ValidateCodeList();
            String decodedCode = "";
            if (String.IsNullOrEmpty(input.ToUpper()!))
            {
                decodedCode = "ERROR: EMPTY CODE"; // If the input is null or empty, return an error message
            }
            else
            {
                List<String> codes = validateCodeList.GetCodesList(input); // Get the list of codes from the input
                if (!codes.Any())
                {
                    decodedCode = "ERROR: CHECK CHARACTERS"; // If the list has non valid codes, return an error message

                }
                else
                {
                    if (codes[codes.Count - 1] != "#")
                    {
                        decodedCode = "ERROR: MISSING #"; // Check if the last code is "#", indicating the end of the message
                    }
                    else
                    {
                        Decode decode = new Decode();
                        List<String> decodedCodes = new List<String>();
                        foreach (String code in codes)
                        {
                            decodedCodes.Add(decode.DecodedInput(code)); // Decode each code in the list
                        }
                        decodedCode = $"{decode.CleanMessageParts(decodedCodes)}"; // Clean the decoded message parts and join them
                    }
                }
            }
            return decodedCode;
        }
    }
}
