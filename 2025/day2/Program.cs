// Day 2: Gift Shop
// https://adventofcode.com/2025/day/2
// 2025/12/05, 2025/12/29

/*
    Attempts


    894540617728 (too high)
     69553832684
*/

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

    static bool isInvalid(string currID_str, int sections)
    {
        int sections_chkd = 1;
        // Can the string be divided equally into this many sections?
        if(currID_str.Length % sections == 0)
        {
            // Check each section until we find one that is valid
            while(sections_chkd < sections)
            {
                // Compare the current section against the first 
                for(int s1 = 0, sx = currID_str.Length / sections * sections_chkd; sx < currID_str.Length; s1++, sx++)
                {
                    if(currID_str[s1] != currID_str[sx])
                    {
                        return false; // Cannot be invalid if this is true
                    }
                }
                sections_chkd++;
            }
            return true; // If all sections repeat, it is invalid
        }
        return false; // The ID is not invalid (could be invalid with another number of sections)    
    }

    // Test the string with different numbers of sections
    static bool isInvalid_p2(ulong currID_int)
    {
        string currID_str = currID_int.ToString();
        int sections = 2;
        while(sections <= currID_str.Length)
        {
            // If an invalid code, return
            if(isInvalid(currID_str, sections))
            {
                return true;
            }
            // Otherwise, we need to try again
            sections++;
        }

        // Once we've proven there are no repeats, we can say it's valid
        return false;
    }

    private static int Main()
    {
        string[] input;
        string[] tempRange;
        (ulong, ulong) range;
        ulong answer = 0;
        ulong answer2 = 0;

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

                    // Part 2 ~ Same idea, but unknown number of times the pattern repeats in the ID
                    if (isInvalid_p2(currID_int))
                    {
                        answer2 = answer2 + currID_int;
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
        
        Console.WriteLine("Answer 1: " + answer);
        Console.WriteLine("Answer 2: " + answer2);
        return 0;
    }
}