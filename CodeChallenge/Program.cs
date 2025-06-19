using System;
using CodeChallenge;

class Program
{
    static void Main(string[] args)
    {
        Decode decode = new Decode();
        Console.WriteLine("Enter the code to decode (e.g., '4433555 555666#'):");
        String input = Console.ReadLine()??"";
        Console.WriteLine($"Result: { decode.DecodedMessage(input)}");
    }
}