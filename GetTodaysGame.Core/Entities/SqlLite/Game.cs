using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTodaysGame.Entities.SqlLite
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary key property

        public string AwayTeamName { get; set; } = string.Empty;
        public int AwayTeamWins { get; set; }
        public int AwayTeamLosses { get; set; }

        public string HomeTeamName { get; set; } = string.Empty;
        public int HomeTeamWins { get; set; }
        public int HomeTeamLosses { get; set; }
        public string DateSubmitted { get; set; } = string.Empty;
    }
}
