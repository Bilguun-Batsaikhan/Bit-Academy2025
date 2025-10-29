using Dapper;
using DapperExample.Entities;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;

namespace DapperExample
{
    internal class Program
    {
        private static readonly string _connectionString = "Server=localhost;Database=LibraryDb;User Id=sa;Password=bitspa.1;TrustServerCertificate=true";
        static async Task Main(string[] args)
        {
            // await GetCategoriesAsync method before serialize and print it out.
            //Console.WriteLine(JsonSerializer.Serialize(await GetCategoriesAsync()));
            IEnumerable<Book> books = GetBooks();
            Console.WriteLine(JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true }));

            //Convert.ToInt16(Console.Readline())
            Console.WriteLine("Press 1 to insert a new book, otherwise press any to exit");
            int.TryParse(Console.ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    Console.WriteLine("Name: ");
                    var name = Console.ReadLine();

                    Console.WriteLine("CategoryId: ");
                    var categoryId = Console.ReadLine();

                    Console.WriteLine("ISBN: ");
                    var isbn = Console.ReadLine();

                    Console.WriteLine("Publication date: ");
                    var publicationDate = Console.ReadLine();

                    var book = new Book()
                    {
                        Name = name ?? string.Empty,
                        Category = new Category { CategoryId = Convert.ToInt32(categoryId), Name = string.Empty },
                        ISBN = isbn,
                        PublicationDate = DateTime.Parse(publicationDate ?? DateTime.Now.ToString("dd/MM/yyyy"))
                    };
                    AddRecord(book);
                    break;
                default:
                    Console.WriteLine("NO!");
                    break;
            }

            static async Task<IEnumerable<Category>> GetCategoriesAsync()
            {
                // Create new connection
                using SqlConnection connection = new SqlConnection(_connectionString);
                // Open the connection
                connection.Open();

                var categories = await connection.QueryAsync<Category>("SELECT Id, Name FROM Categories WHERE Id IN @Ids", new { Ids = new int[] { 1, 2, 3 } });
                return categories;
            }

            static IEnumerable<Book> GetBooks()
            {
                var query = "SELECT B.Id, B.Name, BD.ISBN, BD.PublicationDate, C.Id AS CategoryId, C.Name, A.Id AS AuthorId, A.FirstName, A.LastName"
                    + " FROM BookAuthors AS BA"
                    + " INNER JOIN Books AS B ON B.Id = BA.BookId"
                    + " INNER JOIN Categories AS C ON C.Id = B.CategoryId"
                    + " INNER JOIN BookDetails BD ON BD.BookId = B.Id"
                    + " INNER JOIN Authors AS A ON A.Id = BA.AuthorId;";

                using var con = new SqlConnection(_connectionString);
                con.Open();

                return con.Query<Book, Category, Author, Book>(query, (book, category, author) =>
                {
                    book.Category = category;
                    book.Authors.Add(author);
                    return book;
                }, splitOn: "CategoryId, AuthorId");
            }

            static void AddRecord(Book book)
            {
                var query = "INSERT INTO Books VALUES(@name, @categoryId)";

                using var con = new SqlConnection(_connectionString);
                con.Open();

                con.Execute(query, new { book.Name, book.Category?.CategoryId });

                var newId = con.ExecuteScalar("SELECT @@IDENTITY");

                query = "INSERT INTO BookDetails VALUES(@bookId, @isbn, @publicationDate)";
                con.Execute(query, new { BookId = Convert.ToInt32(newId), book.ISBN, book.PublicationDate });
            }
        }
    }
}
