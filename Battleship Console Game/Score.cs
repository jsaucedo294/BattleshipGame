
using Newtonsoft.Json;

namespace Battleship_Console_Game
{

    public class RootObject
    {
        public Score[] Score { get; set; }
    }

    public class Score
    {
        [JsonProperty(PropertyName = "player_name")]
        public string PlayerName { get; set; }
        [JsonProperty(PropertyName = "games_won")]
        public int GamesWon { get; set; }
        [JsonProperty(PropertyName = "total_played")]
        public int TotalPlayed { get; set; }
        [JsonProperty(PropertyName = "average_won")]
        public int AverageWon { get; set; }
        [JsonProperty(PropertyName = "ships_sunk")]
        public int ShipsSunk { get; set; }
    }


}
