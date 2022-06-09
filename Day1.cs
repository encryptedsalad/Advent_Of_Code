using System;

// my first C# program!
class Day1 {
    static void Main(String[] args) {
        string input = System.IO.File.ReadAllText($"./{args[0]}");
        string[] lines = input.Split("\n");
        int[] nums = new int[lines.Length];
        int numgreater = 0;        
        nums[0] = Int32.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++) {
            nums[i] = Int32.Parse(lines[i]);
            if (nums[i] > nums[i-1]) {
                numgreater++;
            }
        }
        System.Console.WriteLine(numgreater);
    }
}