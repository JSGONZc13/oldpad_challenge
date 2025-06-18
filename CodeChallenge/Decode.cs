using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    public class Decode
    {
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

        public String DecodedMessage(String input)
        {
            ValidateCodeList validateCodeList = new ValidateCodeList();
            String decodedCode = "";
            if (String.IsNullOrEmpty(input.ToUpper()!))
            {
                decodedCode = "The code is not valid, check and try again";
            }
            else
            {
                List<String> codes = validateCodeList.GetCodesList(input);
                if (!codes.Any())
                {
                    decodedCode = "The code is not valid, check the characters";

                }
                else
                {
                    if (codes[codes.Count - 1] != "#")
                    {
                        decodedCode = "The code is not valid, check if # is at the end of the message";
                    }
                    else
                    {
                        Decode decode = new Decode();
                        List<String> decodedCodes = new List<String>();
                        foreach (String code in codes)
                        {
                            decodedCodes.Add(decode.DecodedInput(code));
                        }
                        decodedCode = $"Decoded code: {decode.CleanMessageParts(decodedCodes)}";
                    }
                }
            }
            return decodedCode;
        }
    }
}
