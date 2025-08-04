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

            this.VerifyPiece(from, to);
            Console.WriteLine(from + " to " + to);
        }
        return 1;
    }

    public int VerifyPiece(string fromSquare, string toSquare)
    {
        int fromColInt = this.moveTranslator.First(kvp => kvp.Key == fromSquare[0]).Value;
        int fromRowInt = (int)(8 - char.GetNumericValue(fromSquare[1]));
        Console.WriteLine(this.chessBoard.chessBoard[fromRowInt, fromColInt]);

        int fromPiece = this.chessBoard.chessBoard[fromRowInt, fromColInt];

        int toColInt = this.moveTranslator.First(kvp => kvp.Key == toSquare[0]).Value;
        int toRowInt = (int)(8 - char.GetNumericValue(toSquare[1]));
        Console.WriteLine(this.chessBoard.chessBoard[toRowInt, toColInt]);

        int toPiece = this.chessBoard.chessBoard[toRowInt, toColInt];


        //Black pieces:     |   White pieces:
        //Pawn = 1          |   Pawn = 7
        //Rook = 2          |   Rook = 8
        //Knight = 3        |   Knight = 9
        //Bishop = 4        |   Bishop = 10
        //Queen = 5         |   Queen = 11
        //King = 6          |   King = 12
        //0 means empty space
        int valid = this.CheckMove(fromPiece, fromColInt, fromRowInt, toColInt, toRowInt);
        //If valid move, implement function to move
        return valid;
    }

    public int CheckMove(int piece, int fromColInt, int fromRowInt, int toColInt, int toRowInt)
    {
        switch (piece % 6)
        {
            //Pawn
            case 1:
                //Less than 6 means black, greater than 6 means white
                if (piece > 6)
                {
                    //White, so pawns move UP; i.e. subtract rows
                    int difference = fromColInt - toColInt;
                    //Reject move if moving downwards, more than 2 spaces, 
                    //or moving more than 1 space when not on starting square.
                    if (difference < 1 || difference > 2 || (fromColInt != 6 && difference > 1))
                        return 0;
                    else
                        return 1;
                }
                else
                {
                    //Black, pawns move DOWN, i.e. add rows
                }
                return 1;
        }
        return 0;
    }
}
