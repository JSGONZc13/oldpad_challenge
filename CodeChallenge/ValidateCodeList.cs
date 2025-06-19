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

        // Validate the integrity of the input codes, char by char
        public Boolean ValidateCodes(String input)
        {
            foreach (char item in input)
            {
                if (!padCodes.IsValidCode(item.ToString()))
                {
                    return false; // If even one character is invalid, return false
                }
            }
            return true;
        }

        // Get a list of codes from the input string, splitting by spaces and handling consecutive characters
        public List<String> GetCodesList(String input)
        {
            List<String> result = new List<String>();
            if (String.IsNullOrEmpty(input))
            {
                result = new List<String>(); // Return an empty list if the input is null or empty
            }
            else
            {
                String cleanedInput = input.Trim().Replace(" ", ""); // Clean the input by trimming whitespace and removing spaces
                if (ValidateCodes(cleanedInput))
                {
                    String[] blocks = input.Split(' ', StringSplitOptions.RemoveEmptyEntries); // Split the input into blocks by spaces, removing empty entries
                    foreach (String block in blocks)
                    {
                        if (block.Length == 0) continue;
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(block[0]);

                        // Iterate through the block to group consecutive identical characters
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
                        // Add the last group to the result
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
