class Day3 {
    static void Main(String[] args) {
        string[] lines = System.IO.File.ReadAllText($"./{args[0]}").Split("\n"); 
        int gammaRate = 0;
        int epsilonRate = 0;
        for(int i = 0; i < lines[0].Length; i++) {
            int numOnes = 0;
            int numZeroes = 0;
            for(int j = 0; j < lines.Length; j++) {
                if (lines[j][i] == '0') {
                    numZeroes++;
                } else if (lines[j][i] == '1') {
                    numOnes++;
                } else {}
            }
            if (numZeroes > numOnes) {
                epsilonRate += (1 << (lines[0].Length - i - 1));
            } else {
                gammaRate += (1 << (lines[0].Length - i - 1));
            }
        }
        System.Console.WriteLine("gamma rate is: {0}", gammaRate);
        System.Console.WriteLine("epsilon rate is: {0}", epsilonRate);
        System.Console.WriteLine("product is: {0}", epsilonRate * gammaRate);
    }
}