// Day 2: Gift Shop
// https://adventofcode.com/2025/day/2
// 2025/12/05

class Program
{
    static bool isValid(ulong currID_int)
    {
        string currID_str = currID_int.ToString();

        // Are there an even number of digits?
        if(currID_str.Length % 2 == 0)
        {
            // Are the first and middle numbers same, etc 
            for(int k = 0, l = currID_str.Length / 2; l < currID_str.Length; k++, l++)
            {
                if(currID_str[k] != currID_str[l])
                {
                    return true; // If there's a set of numbers that don't match, it's valid
                }
            }

            return false; // If it's a complete duplicate, it's invalid abcabc
        }
        
        //Console.WriteLine(currID_int);
        //Console.WriteLine($"\t {currID_str[k]} = {currID_str[l]}");

        return true; // If it's an odd number of digits it's valid
    }


    private static int Main()
    {
        string[] input;
        string[] tempRange;
        (ulong, ulong) range;
        ulong answer = 0;

        // Read in file, split on , to get ranges
        input = File.ReadAllText("day2-input.txt").Split(',');

        // For every range
        for(int i = 0; i < input.Length; i++)
        {
            // Split on - to get upper and lower 
            tempRange = input[i].Split('-');

            // Convert to numbers
            if(ulong.TryParse(tempRange[0], out range.Item1) && ulong.TryParse(tempRange[1], out range.Item2))
            {
                // For every in range
                for(ulong currID_int = range.Item1; currID_int <= range.Item2; currID_int++)
                {
                    // We want to sum all of the numbers that are invalid, which is characterized by being a set of numbers repeated twice
                    if(!isValid(currID_int))
                    {
                        answer = answer + currID_int;
                        //Console.WriteLine($"Answer: {answer}");
                    }
                }
                //Console.WriteLine("-------------------------------------------");
            }
            else
            {
                Console.WriteLine("Error parsing input");
                return -1;
            } 
        }               
        
        Console.WriteLine("Answer: " + answer);
        return 0;
    }
}