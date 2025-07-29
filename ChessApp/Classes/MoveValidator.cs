namespace ChessApp.Classes;

public class MoveValidator
{
    public string lastMove { get; set; }
    private char[] digits { get; set; }
    private List<KeyValuePair<char, int>> moveTranslator { get; set; }
    public ChessBoard chessBoard { get; set; }

    public MoveValidator(ChessBoard chessBoard)
    {
        this.lastMove = "";
        this.digits = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
        this.moveTranslator = new List<KeyValuePair<char, int>>()
        {
            new KeyValuePair<char, int>('a', 0),
            new KeyValuePair<char, int>('b', 1),
            new KeyValuePair<char, int>('c', 2),
            new KeyValuePair<char, int>('d', 3),
            new KeyValuePair<char, int>('e', 4),
            new KeyValuePair<char, int>('f', 5),
            new KeyValuePair<char, int>('g', 6),
            new KeyValuePair<char, int>('h', 7),
        };

        this.chessBoard = chessBoard;
    }
    public void InputMove()
    {
        string move = Console.ReadLine();

        if (move != null && this.ValidateMove(move) == 1)
        {
            //Store move in DB and then advance board state 
            this.lastMove = move;
        }
    }

    public int ValidateMove(string move)
    {
        int pieceToMove = move.IndexOfAny(digits);
        if (pieceToMove != -1)
        {
            var from = move.Substring(0, pieceToMove + 1);
            var to = move.Substring(pieceToMove + 1);

            this.VerifyPiece(from);
            Console.WriteLine(from + " to " + to);
        }
        return 1;
    }

    public int VerifyPiece(string square)
    {
        int colInt = this.moveTranslator.First(kvp => kvp.Key == square[0]).Value;
        Console.WriteLine(this.chessBoard.chessBoard[(int)(8 - char.GetNumericValue(square[1])), colInt]);
        //No piece found on that tile
        int piece = this.chessBoard.chessBoard[(int)(8 - char.GetNumericValue(square[1])), colInt];

        if (piece == 0)
            return 0;
        else
            return 1;
    }
}
