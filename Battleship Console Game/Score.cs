
using Newtonsoft.Json;

namespace BattleshipConsoleGame
{

    public class RootObject
    {
        public Score[] Score { get; set; }
    }

    public class Score
    {
        [JsonProperty(PropertyName = "player_id")]
        public int PlayerId { get; set; }
        [JsonProperty(PropertyName = "player_name")]
        public string PlayerName { get; set; }
        [JsonProperty(PropertyName = "games_won")]
        public int GamesWon { get; set; }
        [JsonProperty(PropertyName = "games_lost")]
        public int GamesLost { get; set; }
        [JsonProperty(PropertyName = "total_played")]
        public int TotalPlayed
        {
            get
            {
                return GamesWon + GamesLost;
            }
        }
        [JsonProperty(PropertyName = "average_won")]
        public int AverageWon
        {
            get
            {
                return (GamesWon / TotalPlayed) * 100;
            }
        }
        [JsonProperty(PropertyName = "ships_sunk")]
        public int ShipsSunk { get; set; }
    }


}
