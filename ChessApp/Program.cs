using MongoDB.Driver;
using MongoDB.Bson;

//Set Connection URI
const string uri = "mongodb://localhost:27017";

//Create a client and connect to the server
var client = new MongoClient(uri);

//Connect to specific DB
var database = client.GetDatabase("ChessDB");

Console.WriteLine("Hello, World! I have successfully connected to the ChessDB");
