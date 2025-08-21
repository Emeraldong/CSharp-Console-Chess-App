namespace ChessApp.Classes;

public class Pawn : ChessPiece
{
    //for En Passant
    public int canBeEnPassant { get; set; }
    public int team { get; }
    private int hasMoved { get; set; }
    private int canPromote { get; set; }

    public Pawn(int[] coordinate) : base(coordinate)
    {
        this.canBeEnPassant = 0;
        this.hasMoved = 0;
        this.canPromote = 0;
        this.coordinate = coordinate;

        //1 is black, 2 is white
        this.team = coordinate[0] == 1 ?1:2;
    }

    public int CanEnPassant(ref ChessBoard chessBoard)
    {
        //Check left and right for enemy pawns.
        //Check left
        int leftCheck = 0;
        int rightCheck = 0;
        int enemyPawn = this.team == 1 ? 7 : 1;
        if (this.coordinate[1] - 1 >= 0)
        {
            leftCheck = chessBoard.chessBoard[this.coordinate[0], this.coordinate[1] - 1];
        }
        //Check right
        if (this.coordinate[1] + 1 < 8)
        {
            rightCheck = chessBoard.chessBoard[this.coordinate[0], this.coordinate[1] + 1];
        }
        //If present and is pawn, check their "canBeEnPassant" flag.
        if (leftCheck == enemyPawn || rightCheck == enemyPawn)
        {
            
        }
        return 0;
    }
}