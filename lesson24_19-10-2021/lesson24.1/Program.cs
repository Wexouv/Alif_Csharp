using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Reverse()
    {
        // Convert the string to a list and reverse it
        var arr = IO.GetInput<string>("Input a number: ").Select(p => p - '0').Reverse().ToList();

        // Print the array
        for (int i = 0; i < arr.Count; ++i) {
            if (i == 0) IO.Print("[", newLine: false);

            if (i == arr.Count - 1) IO.Print($"{arr[i]}]", newLine: false);
            else {
                IO.Print($"{arr[i]}, ", newLine: false);
            }
        }
        IO.Print("");
    }

    static void Sum()
    {
        var nums = IO.GetInput<string>("Input the array")
            .Split()
            .Select(p => int.Parse(p))
            .ToList();

        var arr = new List<int>();

        arr.Add( nums.Where(p => p > 0).Count() );
        arr.Add( nums.Where(p => p < 0).Sum() );

        IO.Print($"Positives count: {arr[0]}; Sum of negatives: {arr[1]}");
    }

    static void Sort()
    {
        var words_sorted = IO.GetInput<string>("Input words: ").Split().OrderBy(p => p.Length).ToList();

        foreach (var i in words_sorted)
            IO.Print($"{i} ", newLine: false);
    }

    static void Uniq()
    {
        var nums = IO.GetInput<string>("Input the array")
            .Split()
            .Select(p => double.Parse(p))
            .ToList();

        var ans = nums.GroupBy(p => p).Where(p => p.Count() == 1).Select(p => p.Key);

        foreach (var i in ans)
            IO.Print($"{i} ", newLine: false);
    }
    static void Main()
    {
        Reverse();
        Sum();
        Sort();
        Uniq();
    }
}
