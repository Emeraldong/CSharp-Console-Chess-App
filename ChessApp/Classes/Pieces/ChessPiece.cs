namespace ChessApp.Classes;

public class ChessPiece
{
    public int[] coordinate { get; set; }

    public ChessPiece(int[] coordinate)
    {
        this.coordinate = coordinate;
    }
    public int MovePiece(ref ChessBoard chessBoard, int[] origin, int[] target)
    {
        // target = origin;
        chessBoard.chessBoard[target[0], target[1]] = chessBoard.chessBoard[origin[0], origin[1]];
        // origin = 0;
        chessBoard.chessBoard[origin[0], origin[1]] = 0;
        return 0;
    }
}