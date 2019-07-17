using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BattleshipConsoleGame
{
    public static class FileReaderAndWriter
    {
        public static List<Score> ReadScores()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directoryInfo.FullName, "battleshipScore.json");
            var scores = DeserializeScores(fileName);
            
            return scores; 
        }

        public static void WriteScoreToFile(GameSetup battle)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directoryInfo.FullName, "battleshipScore.json");
            
            SerializeScoreToFile(battle.Scores, fileName);
        }

        public static void ResetScore()
        {
            var emptyScore = new List<Score>();

            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directoryInfo.FullName, "battleshipScore.json");

            SerializeScoreToFile(emptyScore, fileName);
        }
        public static void DisplayScore()
        {
            var scores = ReadScores();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Environment.NewLine);
            Console.WriteLine("╔═╗┌─┐┌─┐┬─┐┌─┐");
            Console.WriteLine("╚═╗│  │ │├┬┘├┤ ");
            Console.WriteLine("╚═╝└─┘└─┘┴└─└─┘");
            Console.ResetColor();
            //Sort List by GamesWon
            var sortedScores = scores.OrderByDescending(s => s.GamesWon).ToList();

            //Print Scores
            foreach (var score in sortedScores)
            { 
                Console.WriteLine($"Player Name: {score.PlayerName}");
                Console.WriteLine($"Games Won: {score.GamesWon}");
                Console.WriteLine($"Games Lost: {score.GamesLost}");
                if (score.TotalPlayed == 0)
                {
                    Console.WriteLine($"Winning Percentage: 0%");
                }
                else
                { 
                    Console.WriteLine($"Winning Percentage: {Math.Round(((double)score.GamesWon / (double)score.TotalPlayed), 2) * 100}%");
                }
                Console.WriteLine($"Ships Sunk: {score.ShipsSunk}");
                Console.Write(Environment.NewLine);
            }
        }
        
        //Read Scores on file
        public static List<Score> DeserializeScores(string fileName)
        {
            var scores = new List<Score>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                scores = serializer.Deserialize<List<Score>>(jsonReader);
            }
            
            return scores;
        }
        
        //Writes Scores on file
        public static void SerializeScoreToFile(List<Score> scores, string fileName)
        {
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, scores);
            }
        }

       
    }
}
