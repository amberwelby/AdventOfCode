// Day 3: Lobby
// https://adventofcode.com/2025/day/3
// 2025/12/30

class Program
{   
    static int joltage2(string line)
    {
        char temp;
        int curr;
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
        return (max * 10) + max2;
    }

    // Could be generic, but joltage12 sounded cooler
    static ulong joltage12(string line)
    {
        char temp;
        char max;
        int maxi = -1; // index of max
        char[] batteries = new char[12];

        for(int n = 12; n > 0; n--)
        {
            max = '0';
            // Starting after the last picked battery and ending with enough remaining to choose from
            for(int i = maxi + 1; i < (line.Length - (n - 1)); i++)
            {
                temp = line[i];

                if(temp > max)
                {
                    max = temp;
                    maxi = i;
                }
            }
            batteries[12-n] = max;
        }

        // Make a char array and int parse instead
        ulong joltages = Convert.ToUInt64(new string(batteries));
        //Console.WriteLine(joltages);
        return joltages;
    }    

    private static int Main()
    {
        int joltage = 0;
        ulong temp_joltage;
        ulong joltage_2 = 0;
    
        foreach (var line in File.ReadLines("day3-input.txt"))
        {
            joltage = joltage + joltage2(line);
            temp_joltage = joltage12(line);
            if(temp_joltage > 0)
            {
                joltage_2 = joltage_2 + temp_joltage;
            }
            else
            {
                Console.WriteLine("Parsing error in function");
                return -1;
            }
        }

        Console.WriteLine("Total Joltage: " + joltage);
        Console.WriteLine("Greater Joltage: " + joltage_2);       
        
        return 0;
    }
}