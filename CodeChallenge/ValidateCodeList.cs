using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    public class ValidateCodeList
    {
        PadCodes padCodes = new PadCodes();

        public Boolean ValidateCodes(String input)
        {
            foreach (char item in input)
            {
                if (!padCodes.IsValidCode(item.ToString()))
                {
                    return false;
                }
            }
            return true;
        }
        public List<String> GetCodesList(String input)
        {
            List<String> result = new List<String>();
            if (String.IsNullOrEmpty(input))
            {
                result = new List<String>();
            }
            else
            {
                String cleanedInput = input.Trim().Replace(" ", "");
                if (ValidateCodes(cleanedInput))
                {
                    String[] blocks = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    foreach (String block in blocks)
                    {
                        if (block.Length == 0) continue;
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(block[0]);

                        for (int i = 1; i < block.Length; i++)
                        {
                            if (block[i] == block[i - 1])
                            {
                                stringBuilder.Append(block[i]);
                            }
                            else
                            {
                                result.Add(stringBuilder.ToString());
                                stringBuilder.Clear();
                                stringBuilder.Append(block[i]);
                            }
                        }

                        result.Add(stringBuilder.ToString());
                    }
                }
                else
                {
                    result = new List<String>();
                }
            }
            return result;
        }
    }
}
