using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Enums;

namespace ExerciseEF.App
{
    internal class Program
    {
        private static readonly JsonSerializerOptions _options = new() { WriteIndented = true, ReferenceHandler = ReferenceHandler.IgnoreCycles };

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console() // <-- requires Serilog.Sinks.Console
                .CreateLogger();

            try
            {
                Log.Information($"App info: {Assembly.GetExecutingAssembly().FullName}");
                using var context = new AppDbContext();
                // Ensure database exists
                try { context.Database.Migrate(); } catch { context.Database.EnsureCreated(); }
                while(true)
                {
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Create new playlist");
                    Console.WriteLine("2. Add new game");
                    Console.WriteLine("3. Add new user");
                    Console.WriteLine("4. Print out playlist");
                    Console.WriteLine("5. List all available games");
                    Console.WriteLine("6. List all users");
                    Console.WriteLine("7. Update a game");
                    Console.WriteLine("8. Delete a game");
                    Console.WriteLine("Enter any other number to exit");

                    var option = Convert.ToInt16(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            try
                            {
                                Console.Write("Enter playlist name: ");
                                var playlistName = Console.ReadLine() ?? string.Empty;
                                if (string.IsNullOrWhiteSpace(playlistName))
                                {
                                    Console.WriteLine("Playlist name cannot be empty.");
                                    break;
                                }

                                var allUsers = context.Users.ToList();
                                if (allUsers.Count == 0)
                                {
                                    Console.WriteLine("No users found. Create a user first (option 3).");
                                    break;
                                }

                                Console.WriteLine("Select a user by Id:");
                                foreach (var u in allUsers)
                                {
                                    Console.WriteLine($"{u.UserId}: {u.FirstName} {u.LastName} - {u.Email}");
                                }
                                Console.Write("User Id: ");
                                if (!int.TryParse(Console.ReadLine(), out var userId))
                                {
                                    Console.WriteLine("Invalid user Id.");
                                    break;
                                }
                                var user = context.Users.FirstOrDefault(u => u.UserId == userId);
                                if (user is null)
                                {
                                    Console.WriteLine("User not found.");
                                    break;
                                }

                                var newList = new GameList
                                {
                                    GameListName = playlistName.Trim(),
                                    UserId = user.UserId
                                };
                                context.GameList.Add(newList);
                                context.SaveChanges();
                                Console.WriteLine("Playlist created:");
                                Console.WriteLine(JsonSerializer.Serialize(newList, _options));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Failed to create playlist: {e.Message}");
                            }
                            break;
                        case 2:
                            try
                            {
                                var newGame = CreateGame(context);
                                if (newGame == null) {
                                    Console.WriteLine("Failed to create new game");
                                    break;
                                }
                                context.Games.Add(newGame!);
                                context.SaveChanges();
                                Console.WriteLine("Game added:");
                                Console.WriteLine(JsonSerializer.Serialize(newGame, _options));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Failed to add game: {e.Message}");
                            }
                            break;
                        case 3:
                            try
                            {
                                Console.Write("Enter first name: ");
                                var first = Console.ReadLine() ?? string.Empty;
                                Console.Write("Enter last name: ");
                                var last = Console.ReadLine() ?? string.Empty;
                                Console.Write("Enter email (optional): ");
                                var email = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(last))
                                {
                                    Console.WriteLine("First and last name are required.");
                                    break;
                                }

                                var newUser = new User
                                {
                                    FirstName = first.Trim(),
                                    LastName = last.Trim(),
                                    Email = string.IsNullOrWhiteSpace(email) ? null : email!.Trim()
                                };
                                context.Users.Add(newUser);
                                context.SaveChanges();
                                Console.WriteLine("User created:");
                                Console.WriteLine(JsonSerializer.Serialize(newUser, _options));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Failed to create user: {e.Message}");
                            }
                            break;
                        case 4:
                            var gamelist = context.GameList
                                .Include(gl => gl.Games).ToList();
                            Console.WriteLine(JsonSerializer.Serialize(gamelist, _options));
                        break;
                        case 5:
                            var games = context.Games.ToList();
                            Console.WriteLine(JsonSerializer.Serialize(games,_options));
                        break;
                        case 6:
                            var users = context.Users.ToList();

                            Console.WriteLine(JsonSerializer.Serialize(users, _options));
                        break;
                        case 7:
                            try
                            {
                                UpdateGameInteractive(context);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Failed to update game: {e.Message}");
                            }
                            break;
                        case 8:
                            games = context.Games.ToList();
                            Console.WriteLine("Enter game Id to delete.");
                            foreach(var game in games)
                            {
                                Console.WriteLine($"{game.GameId}: {game.GameName}");
                            }
                            int.TryParse(Console.ReadLine(), out int gameId);
                            var gameToDelete = games.FirstOrDefault(g => g.GameId == gameId);
                            if(gameToDelete == null)
                            {
                                Console.WriteLine("Failed to delete the game");
                                break;
                            }
                            games.Remove(gameToDelete);
                            context.SaveChanges();
                            break;
                        default:
                            return;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        static Game? CreateGame(AppDbContext context)
        {
            var allLists = context.GameList.AsNoTracking().ToList();
            if (allLists.Count == 0)
            {
                Console.WriteLine("No playlists found. Create a playlist first (option 1).");
                return null; // Maybe throw an exception for better handling
            }

            Console.WriteLine("Select a playlist by Id:");
            foreach (var gl in allLists)
            {
                Console.WriteLine($"{gl.GameListId}: {gl.GameListName} (UserId: {gl.UserId})");
            }
            Console.Write("Playlist Id: ");
            if (!int.TryParse(Console.ReadLine(), out var listId))
            {
                Console.WriteLine("Invalid playlist Id.");
                return null;
            }
            var targetList = context.GameList.FirstOrDefault(gl => gl.GameListId == listId);
            if (targetList is null)
            {
                Console.WriteLine("Playlist not found.");
                return null;
            }

            Console.Write("Enter game name: ");
            var gameName = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(gameName))
            {
                Console.WriteLine("Game name cannot be empty.");
                return null;
            }

            Console.WriteLine("Select a genre by number:");
            var genres = Enum.GetValues(typeof(GameGenre)).Cast<GameGenre>().ToArray();
            for (int i = 0; i < genres.Length; i++)
            {
                Console.WriteLine($"{i}: {genres[i]}");
            }
            Console.Write("Genre #: ");
            if (!int.TryParse(Console.ReadLine(), out var genreIndex) || genreIndex < 0 || genreIndex >= genres.Length)
            {
                Console.WriteLine("Invalid genre.");
                return null;
            }
            var genre = genres[genreIndex];

            Console.Write("Enter gameplay hours (integer): ");
            if (!int.TryParse(Console.ReadLine(), out var hours) || hours < 0)
            {
                Console.WriteLine("Invalid hours.");
                return null;
            }

            Console.Write("Enter studio: ");
            var studio = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(studio))
            {
                Console.WriteLine("Studio cannot be empty.");
                return null;
            }

            var newGame = new Game
            {
                GameName = gameName.Trim(),
                Genre = genre,
                GameplayHours = hours,
                Studio = studio.Trim(),
                GameListId = targetList.GameListId
            };
            return newGame;
        }

        static void UpdateGameInteractive(AppDbContext context)
        {
            var games = context.Games.ToList();
            if (games.Count == 0)
            {
                Console.WriteLine("No games found. Add a game first (option 2).");
                return;
            }

            Console.WriteLine("Choose game Id to update");
            foreach (var g in games)
            {
                Console.WriteLine($"{g.GameId}: {g.GameName}");
            }

            Console.Write("Game Id: ");
            if (!int.TryParse(Console.ReadLine(), out var gameId))
            {
                Console.WriteLine("Invalid game Id.");
                return;
            }

            var game = context.Games.FirstOrDefault(g => g.GameId == gameId);
            if (game is null)
            {
                Console.WriteLine("Game not found.");
                return;
            }

            Console.Write($"Game name [{game.GameName}]: ");
            var nameIn = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nameIn))
                game.GameName = nameIn.Trim();

            var genres = Enum.GetValues(typeof(GameGenre)).Cast<GameGenre>().ToArray();
            Console.WriteLine($"Genre (press Enter to keep '{game.Genre}'):");
            for (int i = 0; i < genres.Length; i++)
                Console.WriteLine($"{i}: {genres[i]}");
            Console.Write("Genre # (blank to keep): ");
            var genreRaw = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(genreRaw) &&
                int.TryParse(genreRaw, out var genreIndex) &&
                genreIndex >= 0 && genreIndex < genres.Length)
            {
                game.Genre = genres[genreIndex];
            }

            Console.Write($"Gameplay hours [{game.GameplayHours}]: ");
            var hoursRaw = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(hoursRaw) &&
                int.TryParse(hoursRaw, out var hours) &&
                hours >= 0)
            {
                game.GameplayHours = hours;
            }

            Console.Write($"Studio [{game.Studio}]: ");
            var studioRaw = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(studioRaw))
                game.Studio = studioRaw.Trim();

            var allLists = context.GameList.AsNoTracking().ToList();
            Console.WriteLine($"Playlist Id [{game.GameListId}] (press Enter to keep):");
            foreach (var gl in allLists)
                Console.WriteLine($"{gl.GameListId}: {gl.GameListName} (UserId: {gl.UserId})");
            Console.Write("Playlist Id (blank to keep): ");
            var listRaw = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(listRaw) && int.TryParse(listRaw, out var listId))
            {
                var targetList = context.GameList.FirstOrDefault(gl => gl.GameListId == listId);
                if (targetList is not null)
                    game.GameListId = targetList.GameListId;
                else
                    Console.WriteLine("Playlist not found. Keeping original.");
            }

            context.SaveChanges();
            Console.WriteLine("Game updated:");
            Console.WriteLine(JsonSerializer.Serialize(game, _options));
        }
    }
}
