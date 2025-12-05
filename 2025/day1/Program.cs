// Day 1: Secret Enterance
// https://adventofcode.com/2025/day/1
// 2025/12/03

/* Attempts
    52
    35
    1158
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

        int landZero = 0;
        int dialMax = 100;
        int dialCurr = 50;
        char direction;
        int distance;

        // For each input
        foreach (var line in File.ReadLines("day1-input.txt"))
        {
            // Parse input
            direction = line[0];
            if (int.TryParse(line.Substring(1), out distance))
            {
                // Check and move in the direction for +R/-L
                dialCurr = direction == 'R' ? dialCurr + distance : dialCurr - distance;

                // Console.Write(dialCurr + " % " + dialMax + " ");
                dialCurr = mod(dialCurr, dialMax);
                // Console.WriteLine(" = " + dialCurr);

                // If 0, landZero++
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
        return 0;
    }
}