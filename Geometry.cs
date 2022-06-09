namespace Geometry {
    class Point {
        public int x, y;
        public Point(int x, int y) {
            this.x = x; 
            this.y = y;
        } 
    }
    class Line {
        public Point p1;
        public Point p2;
        public Line(int x1, int y1, int x2, int y2) {
            p1 = new Point(x1, y1);
            p2 = new Point(x2, y2);
        }
        public int squareLength() {
            return (p1.x - p2.x)*(p1.x-p2.x) + (p1.y - p2.y)*(p1.y-p2.y);
        }
        public double Length() {
            return Math.Sqrt(squareLength());
        }
        // 
        public void PrintLine() {
            System.Console.Write("({0},{1}),({2},{3})\n", p1.x, p1.y, p2.x, p2.y);
        }
        // returns the largest x or y value in this line
        public int getMax() {
            return Math.Max(Math.Max(p1.x, p1.y), Math.Max(p2.x, p2.y));
        }
    }
    class Board {
        public int[,] board;
        public int dimension;
        public Board(int dimension) {
            this.dimension = dimension;
            this.board = new int[dimension + 1, dimension + 1];
            // TODO: everything is initialized to 0?
        }
        // for part 1 this method will only work if you have either the x or y coordinates equal
        public void drawLine(Line l) {
            // is there a line that is being drawn?
            if(l.p1.x == l.p2.x || l.p1.y == l.p2.y 
                    // comment out this line to remove diagonals
                    || Math.Abs(l.p1.x - l.p2.x) == Math.Abs(l.p1.y-l.p2.y)
                    ) {
                int max = Math.Max(Math.Abs(l.p1.x - l.p2.x), Math.Abs(l.p1.y-l.p2.y));
                int xSign = Math.Sign(l.p2.x - l.p1.x);
                int ySign = Math.Sign(l.p2.y - l.p1.y);
                for(int i = 0; i <= max; i++) {
                    board[l.p1.x + xSign*i, l.p1.y+ ySign*i]++;
                }
            }
        }
        public void print() {
            for(int i = dimension; i >= 0; i--) {
                for(int j = 0; j <= dimension; j++) {
                    if(board[j,i] == 0) {
                        System.Console.Write("."); 
                    } else {
                        System.Console.Write(board[j,i]);
                    }
                    System.Console.Write(" ");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
        }
        public int countTwos() {
            int twos = 0;
            foreach(int i in board) {
                if(i > 1) {
                    twos++;
                }
            }
            return twos;
        }
    }
}