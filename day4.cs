using System.Text.RegularExpressions;
using System;
class BingoBoard {
    int[,] board;
    bool[,] state;
    int dimension;
    bool inPlay;

    // constructs the bingo board from a string
    public BingoBoard(String[] strBoard) {
        // assume that the board is a perfect square
        inPlay = true;
        dimension = strBoard.Length;
        board = new int[dimension, dimension];
        state = new bool[dimension, dimension];
        for (int i = 0; i < dimension; i++) {
            strBoard[i] = strBoard[i].Trim();
            String[] numbers = Regex.Replace(strBoard[i], "  ", " ").Split(" ");
            for (int j = 0; j < numbers.Length; j++) {
                board[i,j] = Int32.Parse(numbers[j]);
                state[i,j] = false;
            }
        }
    }

    // adds a new number to the board. If there is a bingo, returns true
    public bool checkNewNumber(int number) {
        if(!inPlay) {
            return false;
        }
        for(int i = 0; i < dimension; i++) {
            for(int j = 0; j < dimension; j++) {
                if(board[i,j] == number) {
                    state[i,j] = true;
                    // there might be multiple of the same number?
                    if(checkBingo()) {
                        inPlay = false;
                        return true;
                    }
                    return false;
                }
            }
        }
        return false;
    }

    private bool checkBingo() {
        for(int i = 0; i < dimension; i++) {
            // check the ith column
            for(int j = 0; j < dimension; j++) {
                if(!state[i,j]) {
                    break;
                } else if(j == dimension - 1) { 
                    return true;
                }
            }
            // check the ith row
            for(int j = 0; j < dimension; j++) {
                if(!state[j,i]) {
                    break;
                } else if(j == dimension - 1) {
                    return true;
                }
            }
        }
        // check the diagonals
        // for(int i = 0; i < dimension; i++) {
        //     if(!state[i,i]) {
        //         break;
        //     } else if(i == dimension - 1) {
        //         return true;
        //     }
        // }
        // for(int i = 0; i < dimension; i++) {
        //     if(!state[i, dimension - 1 - i]) {
        //         break;
        //     } else if(i == dimension - 1) {
        //         return true;
        //     }
        // }
        return false;
    }

    public void printBoard() {
        System.Console.WriteLine("Printing Board:");
        for(int i = 0; i < dimension; i++) {
            for(int j = 0; j < dimension; j++) {
                if(board[i,j] < 10) {
                    System.Console.Write(" ");
                }
                if(state[i,j]) {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }
                System.Console.Write(board[i,j]);
                Console.ResetColor();
                System.Console.Write(" ");

            }
            System.Console.WriteLine();
        }
    }

    // the score of the board is the sum of all elements not in the board
    public int getScore() {
        int sum = 0;
        for(int i = 0; i < dimension; i++) {
            for(int j = 0; j < dimension; j++) {
                if(!state[i,j]) {
                    sum += board[i,j];
                }
            }
        }
        return sum;
    }
}

class Day4 {
    static void Main(String[] args) {
        // first we split the data into the numbers and the bingo boards
        String[] data = System.IO.File.ReadAllText($"./{args[0]}").Split("\n\n");
        // foreach(String datum in data) {
        //     System.Console.WriteLine("First String:\n");
        //     System.Console.WriteLine(datum);
        // }
        String[] strNumbers = data[0].Split(",");
        int[] numbers = new int[strNumbers.Length];
        for(int i = 0; i < strNumbers.Length; i++) {
            numbers[i] = Int32.Parse(strNumbers[i]);
        }

        BingoBoard[] boards = new BingoBoard[data.Length - 1];
        for(int i = 1; i < data.Length; i++) {
            boards[i-1] = new BingoBoard(data[i].Split("\n"));
        }

        int winningBoard = 0;
        int winningScore = 0;
        int winningNumber = 0;
        foreach(int number in numbers) {
            for(int i = 0; i < boards.Length; i++) {
                if (boards[i].checkNewNumber(number)) {
                    // boards[i].printBoard();
                    winningBoard = i;
                    winningScore = boards[i].getScore();
                    winningNumber = number;
                    // uncomment in order to get the first winning board
                    // System.Console.WriteLine("Board Number:");
                    // System.Console.WriteLine(winningBoard);
                    // boards[winningBoard].printBoard();
                    // System.Console.WriteLine("Score of this board:");
                    // System.Console.WriteLine(winningScore);
                    // System.Console.WriteLine("Winning Number:");
                    // System.Console.WriteLine(winningNumber);
                    // System.Console.WriteLine("Product:");
                    // System.Console.WriteLine(winningScore * winningNumber);
                    // return;
                }
            }
        }
        System.Console.WriteLine("Board Number:");
        System.Console.WriteLine(winningBoard);
        boards[winningBoard].printBoard();
        System.Console.WriteLine("Score of this board:");
        System.Console.WriteLine(winningScore);
        System.Console.WriteLine("Winning Number:");
        System.Console.WriteLine(winningNumber);
        System.Console.WriteLine("Product:");
        System.Console.WriteLine(winningScore * winningNumber);
    }
}
