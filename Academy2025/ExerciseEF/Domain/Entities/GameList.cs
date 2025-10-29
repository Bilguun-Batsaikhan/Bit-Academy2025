using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GameList
    {
        public int GameListId { get; set; }
        public string GameListName { get; set; } = string.Empty;
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
