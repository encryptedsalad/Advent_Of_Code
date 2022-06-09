using Geometry;

class Day4 {
    static void Main(String[] args) {
        String[] data = System.IO.File.ReadAllText($"./{args[0]}").Split("\n");
        Line[] lines = new Line[data.Length];
        int max = 0;
        for(int i = 0; i < data.Length; i++) {
            String[] pairs = data[i].Split(" -> ");
            String[] pair1 = pairs[0].Split(",");
            String[] pair2 = pairs[1].Split(",");
            lines[i] = new Line(Int32.Parse(pair1[0]), Int32.Parse(pair1[1]), 
                    Int32.Parse(pair2[0]), Int32.Parse(pair2[1]));
            // lines[i].PrintLine();
            if (lines[i].getMax() > max)
                max = lines[i].getMax();
        }
        Board board = new Board(max);
        foreach(Line l in lines) {
            board.drawLine(l);
        }
        // board.print();
        System.Console.WriteLine(board.countTwos());
    }

}