namespace ChessApp.Classes;

public class GameState
{
    //Counts up
    public int turnNumber { get; set; }

    //Determines which player moves
    public string playerToMove { get; set; }

    //Implement in the future; Include user chosen options for game length.
    // public int timeInMinutes { get; }

    public int whiteTime { get; set; }
    public int blackTime { get; set; }

    public void InitializeGame()
    {
        this.turnNumber = 0;
        this.playerToMove = "black";
        this.whiteTime = this.blackTime = 600;
    }

    public void SubtractTime(int elapsedTime)
    {
        if (this.playerToMove == "white")
        {
            this.whiteTime -= elapsedTime;
        }
        else
        {
            this.blackTime -= elapsedTime;
        }
    }

    public void SwapTurns()
    {
        if (this.playerToMove == "white")
        {
            this.playerToMove = "black";
            Console.WriteLine("Black to move.");
        }
        else
        {
            this.playerToMove = "white";
            Console.WriteLine("White to move.");
            //After black moves, the next turn begins.
            this.turnNumber++;
        }
    }
}