
class Day2 {
    static void Main(String[] args) {
        string[] lines = System.IO.File.ReadAllText($"./{args[0]}").Split("\n");
        int length = 0;
        int depth = 0;
        for(int i = 0; i < lines.Length; i++) {
            string[] command = lines[i].Split(" ");
            if (command[0].Equals("forward")) {
                length += Int32.Parse(command[1]);
            } else if (command[0].Equals("up")) {
                depth -= Int32.Parse(command[1]);
            } else if (command[0].Equals("down")) {
                depth += Int32.Parse(command[1]);
            }
        }
        System.Console.WriteLine(length*depth);
    }
}