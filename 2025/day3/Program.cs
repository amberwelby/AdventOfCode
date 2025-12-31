// Day 3: Lobby
// https://adventofcode.com/2025/day/3
// 2025/12/30

/*
    Attempts
    


*/

class Program
{   
    private static int Main()
    {
        char temp;
        int curr;
        int joltage = 0;
    
        foreach (var line in File.ReadLines("day3-input.txt"))
        {
            int max = 0;
            int max2 = 0;
            int maxi = -1; // index of max

            // Find highest number (excluding last number)
            for(int i = 0; i < (line.Length - 1); i++)
            {
                // Cast to int, without the baggage of `if(int.TryParse....`
                temp = line[i];
                curr = temp - '0';

                if(curr > max)
                {
                    max = curr;
                    maxi = i;
                }
            }

            // Find highest number after our first number
            for(int i = maxi + 1; i < line.Length; i++)
            {
                temp = line[i];
                curr = temp - '0';

                if(curr > max2)
                {
                    max2 = curr;
                }
            }

            //Console.WriteLine(max + " " + max2 + " new joltage: " + ((max * 10) + max2));
            joltage = joltage + (max * 10) + max2;
        }

        Console.WriteLine("Total Joltage: " + joltage);
        
        return 0;
    }
}
