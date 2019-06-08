using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Battleship_Console_Game
{
    public static class FileReaderAndWriter
    {
        public static List<Score> GetScores()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directoryInfo.FullName, "battleshipScore.json");
            var scores = DeserializeScores(fileName);
            
            return scores; 
        }

        public static void SetScores(GameSetup battle, Score score)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directoryInfo.FullName, "battleshipScore.json");
            var scores = battle.Scores;

            SerializeScoreToFile(scores, fileName);
        }

        public static void DisplayScore()
        {
            var scores = GetScores();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Environment.NewLine);
            Console.WriteLine("╔═╗┌─┐┌─┐┬─┐┌─┐");
            Console.WriteLine("╚═╗│  │ │├┬┘├┤ ");
            Console.WriteLine("╚═╝└─┘└─┘┴└─└─┘");
            Console.ResetColor();
            foreach (var score in scores)
            { 
                Console.WriteLine($"Player Name: {score.PlayerName}");
                Console.WriteLine($"Games Won: {score.GamesWon}");
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
