using System;
using CodeChallenge;

class Program
{
    static void Main(string[] args)
    {
        Decode decode = new Decode(); // Create an instance of the Decode class to access its methods
        Console.WriteLine("Enter the code to decode (e.g., '4433555 555666#'):"); // Example input for the dedode process"
        String input = Console.ReadLine()??""; // Read input from the user, defaulting to an empty string if null
        Console.WriteLine($"Result: { decode.DecodedMessage(input)}"); // Call the DecodedMessage method to decode the input and print the result
    }
}