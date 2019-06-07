using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Console_Game
{
    class Score
    {
        public static void ReadAndWriteScore()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directoryInfo.FullName, "Score.csv");
            var file = new FileInfo(fileName);
            if (file.Exists)
            {
                Console.WriteLine("File exists");
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
            
        }
    }
}
