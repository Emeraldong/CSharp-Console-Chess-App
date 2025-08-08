using MongoDB.Driver;
using MongoDB.Bson;
using ChessApp.Classes;

//Set Connection URI
const string uri = "mongodb://localhost:27017";

//Create a client and connect to the server
var client = new MongoClient(uri);

//Connect to specific DB
var database = client.GetDatabase("ChessDB");

Console.WriteLine("Hello, World! I have successfully connected to the ChessDB");

//Create new chessboard instance; Can Access different games via DB moves or create new game in future implementations
var chessBoard = new ChessBoard();

//Create Move Validator to store and validate moves
MoveValidator validator = new MoveValidator(chessBoard);

//New Game
chessBoard.InitializeGame();
chessBoard.InitializeChessBoard();
chessBoard.PrintChessBoard();

while (true)
{
    //Start Accepting Input Here;
    validator.InputMove();
}
