// Day 1: Secret Enterance
// https://adventofcode.com/2025/day/1
// 2025/12/03

/* Attempts
    52
    35
    1158

    47236
    46078
    4553
    5711
    9241
*/

internal class Program
{
    private static int Main(string[] args)
    {
        // https://stackoverflow.com/a/1082938
        int mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        int landZero = 0;  // How many times does the dial stop on zero
        int dialMax = 100; // One larger than the max dial number, otherwise you could never have the biggest dial number (99 % 99 = 0)
        int dialCurr = 50; 
        char direction;    // What direction do we need to spin (L means numbers decrease, R means numbers increase)
        int distance;      // How far do we need to spin the dial
        int passZero = 0;  // How many times does the dial pass zero
        int currToZero;    // How far is the dial from zero
        int timesRound;    // How many times will the dial spin 360 degrees

        // For each input
        foreach (var line in File.ReadLines("day1-input.txt"))
        {
            // Parse input
            direction = line[0];
            if (int.TryParse(line.Substring(1), out distance))
            {
                // Will it go around multiple times? How many?
                timesRound = distance / dialMax; 
                    
                // Will the remainder (not mod) pass zero? 
                currToZero = direction == 'L' ? dialCurr : dialMax - dialCurr;
                if((distance % dialMax) > currToZero && dialCurr != 0) // Check that the dial doesn't start on zero
                {
                    passZero++;
                }
                passZero = passZero + timesRound;
                //Console.Write("Total pass: " + passZero + " times round: " + timesRound);

                // Part 1 ~ will it land on zero? 
                // Check and move in the direction for +R/-L
                dialCurr = direction == 'R' ? dialCurr + distance : dialCurr - distance;

                //Console.Write(dialCurr + " % " + dialMax + " ");
                dialCurr = mod(dialCurr, dialMax);
                //Console.WriteLine(" = " + dialCurr);
                //Console.WriteLine (" curr: " + dialCurr);

                // Does the dial land on zero?
                if (dialCurr == 0)
                {
                    landZero++;
                }

                //Console.WriteLine(dialCurr);
            }
            else
            {
                Console.WriteLine("Error parsing input");
                return -1;
            }
        }

        Console.WriteLine("Number of zeros: " + landZero);
        Console.WriteLine("Number pass zero: " + (passZero + landZero));
        return 0;
    }
}