using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; } = string.Empty;
        public GameGenre Genre { get; set; }
        [NotMapped]
        public string? GenreName => Enum.GetName(Genre);
        public int GameplayHours {get; set; }
        public string Studio { get; set; } = string.Empty;
        //[ForeignKey(nameof(GameList))]
        public int GameListId { get; set; }
        public GameList GameList { get; set; } = null!;
    }
}
