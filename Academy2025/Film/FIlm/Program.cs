namespace FIlm;

using Dapper;
using Entities;
using Entities.Entities;
using Microsoft.Data.SqlClient;

internal class Program
{
    private static readonly string _connectionString = "Server=localhost;Database=Film;User Id=sa;Password=bitspa.1;TrustServerCertificate=true";
    static void Main(string[] args)
    {
        Start();
    }
    static void Start()
    {
        while (true)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. List");
            Console.WriteLine("3. Search Film by name");
            Console.WriteLine("4. Search Film by genre");
            Console.WriteLine("Enter any other key to exit");
            var films = GetFilms();
            var choice = Console.ReadLine();
            if (choice == "1")
            {
                AddFilmRecord();
            }
            else if (choice == "2")
            {
                DisplayList(films);
            }
            else if (choice == "3")
            {
                Console.WriteLine("Insert film name");
                var filmName = Console.ReadLine();
                if(filmName == null)
                {
                    continue;
                }
                try
                {
                    var filmByName = films.First(f => f.Name.Equals(filmName, StringComparison.OrdinalIgnoreCase));

                    Console.WriteLine(filmByName);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("Not found");
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (choice == "4")
            {
                Console.WriteLine("Choose film genre number");
                var genres = GetGenres();
                foreach (var genre in genres)
                {
                    Console.WriteLine(genre);
                }
                try
                {
                    int.TryParse(Console.ReadLine(), out int genreChoice);
                    var chosenGenre = genres.Where(g => g.GenreId == genreChoice).FirstOrDefault();
                    var filmsByGenre = films.Where(f => f.Genres.Any(g => g.GenreName == chosenGenre.GenreName));
                    DisplayList(filmsByGenre);
                } catch(NullReferenceException e) { 
                    Console.WriteLine("The genre you chose doesn't exist"); 
                }
            }
            else
            {
                Console.WriteLine("Exiting...");
                return;
            }
        }
    }
    static IEnumerable<Film> GetFilms()
    {
        var query = @"
        SELECT f.Film_Id AS FilmId, f.[Name], f.[Description],
               t.[Type_Id] AS TypeId, t.[TypeName], t.[Description] AS TypeDescription,
               d.[Details_Id] AS DetailsId, d.[Duration], d.[ReleaseDate], d.[Rating],
               g.[Genre_Id] AS GenreId, g.[GenreName]
        FROM Film f
        JOIN Type t ON f.Type_Id = t.Type_Id
        JOIN Details d ON d.Details_Id = f.Details_Id
        JOIN GenreFilm gd ON f.Film_Id = gd.Film_Id
        JOIN Genre g ON gd.Genre_Id = g.Genre_Id;";

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var filmDictionary = new Dictionary<int, Film>();

        var films = connection.Query<Film, Type, Details, Genre, Film>(
            query,
            (film, type, details, genre) =>
            {
                //Tries get a Film value from Dictionary if exists just add the genre
                if (!filmDictionary.TryGetValue(film.FilmId, out var existingFilm))
                {
                    film.Type = type;
                    film.Details = details;
                    film.Genres = new List<Genre> { genre };
                    filmDictionary[film.FilmId] = film;
                }
                else
                {
                    ((List<Genre>)existingFilm.Genres).Add(genre);
                }

                return film;
            },
            splitOn: "TypeId,DetailsId,GenreId"
        );

        return filmDictionary.Values;
    }
    static IEnumerable<Genre> FilterGenresById(int[] ids, IEnumerable<Genre> genres)
    { 
        if (ids is null || genres is null) 
        return Enumerable.Empty<Genre>(); 
        
        var idSet = ids.ToHashSet();
        
        return genres.Where(g => g != null && idSet.Contains(g.GenreId)); 
    }

    static IEnumerable<Type> GetTypes()
    {
        var query = @"SELECT Type_Id AS TypeId, TypeName FROM Type";
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection.Query<Type>(query);
    }
    static IEnumerable<Genre> GetGenres()
    {
        var query = @"SELECT Genre_Id AS GenreId, GenreName FROM Genre";
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection.Query<Genre>(query);
    }
    static int AddType(string typeName, string description)
    {
        var query = @"INSERT INTO Type (TypeName, Description) VALUES (@TypeName, @Description);
                  SELECT CAST(SCOPE_IDENTITY() AS int);";
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        try
        {
            var newTypeId = connection.ExecuteScalar<int>(query, new { TypeName = typeName, Description = description });
            return newTypeId;
        }
        catch (SqlException ex)
        {

            if (ex.Number == 2627 || ex.Number == 2601)
            {
                throw new InvalidOperationException($"Type '{typeName}' already exists.", ex);
            }
            throw;
        }
    }
    static void DisplayList<T>(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
    static void InsertFilm(Film film)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var query = "INSERT INTO Details VALUES(@Duration, @ReleaseDate, @Rating)";
        connection.Execute(query, new
        {
            film.Details?.Duration,
            film.Details?.ReleaseDate,
            film.Details?.Rating
        });

        var newId = connection.ExecuteScalar<int>("SELECT @@IDENTITY");

        query = "INSERT INTO Film VALUES(@Name, @Description, @TypeId, @DetailsId)";
        connection.Execute(query, new
        {
            film.Name,
            film.Description,
            TypeId = film.Type?.TypeId,
            DetailsId = newId
        });

        newId = connection.ExecuteScalar<int>("SELECT @@IDENTITY");
        var genreQuery = "INSERT INTO GenreFilm (Film_Id, Genre_Id) VALUES (@FilmId, @GenreId);";

        foreach (var genre in film.Genres)
        {
            connection.Execute(genreQuery, new { FilmId = newId, GenreId = genre.GenreId });
        }

    }
    static void UpdateFilm(Film film)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        
    }
    static Film CreateFilm(Type selectedType, IEnumerable<Genre> selectedGenres)
    {
        Console.Write("Enter film name: ");
        var name = Console.ReadLine();
        Console.Write("Enter film description: ");
        var description = Console.ReadLine();

        int duration;
        while (true)
        {
            Console.Write("Enter duration in minutes: ");
            if (int.TryParse(Console.ReadLine(), out duration) && duration > 0) break;
            Console.WriteLine("Invalid duration. Enter a positive integer.");
        }

        DateTime releaseDate;
        while (true)
        {
            Console.Write("Enter release date (YYYY-MM-DD): ");
            var input = Console.ReadLine();
            if (DateTime.TryParse(input, out releaseDate)) break;
            Console.WriteLine("Invalid date. Try again.");
        }

        int rating;
        while (true)
        {
            Console.Write("Enter rating (integer 1-10): ");
            if (int.TryParse(Console.ReadLine(), out rating) && (rating > 0 && rating < 11)) break;
            Console.WriteLine("Invalid rating. Enter an integer 1-10.");
        }

        var details = new Details
        {
            Duration = duration,
            ReleaseDate = releaseDate,
            Rating = rating
        };

        var film = new Film
        {
            Name = name,
            Description = description,
            Type = selectedType,
            Details = details,
            Genres = selectedGenres
        };

        return film;
    }
    static void AddFilmRecord()
    {
        var types = GetTypes(); // fetch from DB
        DisplayList(types);

        Console.Write("Choose a type by ID or enter 'new' to add: ");
        var input = Console.ReadLine();

        int typeId;

        if (input == "new")
        {
            Console.Write("Enter new type name: ");
            var typeName = Console.ReadLine();
            Console.Write("Enter new type description: ");
            var typeDescription = Console.ReadLine();
            try
            {
                typeId = AddType(typeName, typeDescription);
                Console.WriteLine($"New type created with Id: {typeId}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        else
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Type name cannot be empty.");
                return;
            }

            int.TryParse(input, out typeId);
            var selected = types.Where(t => t.TypeId == typeId).First();
            Console.WriteLine($"Selected type is: {selected}");
            var genres = GetGenres();
            DisplayList(genres);
            Console.Write("Enter comma-separated existing Genre_Id values (e.g., 1,2): ");
            var genreInput = Console.ReadLine() ?? string.Empty;
            var genreIds = genreInput
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.TryParse(s, out var id) ? id : (int?)null)
                .Where(id => id.HasValue)
                .Select(id => id!.Value)
                .ToArray();

            if (genreIds.Length == 0)
            {
                Console.WriteLine("No valid Genre_Id values provided. Skipping AddRecord test.");
                return;
            }
            var selectedGenres = FilterGenresById(genreIds, genres);
            var mockFilm = CreateFilm(selected, selectedGenres);

            InsertFilm(mockFilm);
            Console.WriteLine("Mock film inserted via AddRecord.");
        }
    }
}


