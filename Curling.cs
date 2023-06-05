using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class MainApp
{
    static void Main(string[] args)
    {
        var lines = GetStdin();
        float minDistOdd = float.MaxValue;
        float minDistEven = float.MaxValue;
        for (int i = 0; i < lines.Length; i++)
        {
            float num1 = float.Parse(lines[i].Split()[0]);
            float num2 = float.Parse(lines[i].Split()[1]);
            float distance = MathF.Sqrt(num1 * num1 + num2 * num2);
            if (i % 2 == 0) // even
            {
                if (distance < minDistEven)
                {
                    minDistEven = distance;
                }
            }
            else // odd
            {
                if (distance < minDistOdd)
                {
                    minDistOdd = distance;
                }
            }
        }
        int oddScore = lines.Where((s, i) => i % 2 == 1)
                            .Count(s => float.Parse(s.Split()[0]) * float.Parse(s.Split()[0]) + float.Parse(s.Split()[1]) * float.Parse(s.Split()[1]) <= minDistEven * minDistEven);
        int evenScore = lines.Where((s, i) => i % 2 == 0)
                            .Count(s => float.Parse(s.Split()[0]) * float.Parse(s.Split()[0]) + float.Parse(s.Split()[1]) * float.Parse(s.Split()[1]) <= minDistOdd * minDistOdd);
        Console.WriteLine($"{evenScore} {oddScore}");
    }

    static string[] GetStdin()
    {
        var list = new List<string>();
        string line;
        while ((line = Console.ReadLine()) != null)
        {
            list.Add(line);
        }
        return list.ToArray();
    }
}