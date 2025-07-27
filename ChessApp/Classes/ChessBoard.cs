namespace ChessApp.Classes;

public class ChessBoard
{
    public int[,] chessBoard { get; set; }

    public void InitializeChessBoard()
    {
        //Black pieces:     |   White pieces:
        //Pawn = 1          |   Pawn = 7
        //Rook = 2          |   Rook = 8
        //Knight = 3        |   Knight = 9
        //Bishop = 4        |   Bishop = 10
        //Queen = 5         |   Queen = 11
        //King = 6          |   King = 12
        this.chessBoard = new int[8, 8]
        {
            {2,3,4,5,6,4,3,2},
            {1,1,1,1,1,1,1,1},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {7,7,7,7,7,7,7,7},
            {8,9,10,11,12,10,9,8}
        };
    }

    public void PrintChessBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write($"| {this.chessBoard[i, j]} ");
            }
            Console.WriteLine("|");
        }
    }
}