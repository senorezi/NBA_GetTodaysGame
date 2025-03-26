using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GetTodaysGame.Entities.ScheduleLeague
{
    public class GameDate
    {
        [JsonPropertyName("gameDate")]
        public string Date { get; set; }
        public List<Game> Games { get; set; }

    }
}
