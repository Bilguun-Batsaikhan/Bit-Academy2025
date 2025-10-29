using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class EFExtensions
    {
        public static void SeedData(this ModelBuilder builder)
        {
            builder.Entity<Game>().HasData(
                new Game { GameId = 1, GameName = "Portal", Genre = GameGenre.Puzzle, GameplayHours = 8, Studio = "Valve", GameListId = 1 }
            );

            builder.Entity<GameList>().HasData(
                new GameList { GameListId = 1, GameListName = "Backlog", UserId = 1 }
            );

            builder.Entity<User>().HasData(
                new User { UserId = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com" }
            );
        }
    }
}
