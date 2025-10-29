using DbRelationships.Entities;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.ExceptionServices;
using System.Text.Json;

namespace DbRelationships
{
    internal class Program
    {
        private static readonly string _connectionString = "Server=localhost;Database=LibraryDb;User Id=sa;Password=bitspa.1;TrustServerCertificate=true";

        static void Main(string[] args)
        {
            //var books = GetBooks();
            //for (int i = 0; i < books.Count; i++)
            //{
            //    for (int j = i + 1; j < books.Count; j++)
            //    {
            //        if (books[i].Name == books[j].Name && books[i].Authors.Any(x => x != books[j].Authors.First()))
            //        {
            //            books[i].Authors.Add(books[j].Authors.First());
            //            books.RemoveAt(j);
            //        }
            //    }
            //}

            // GroupBy groups books by their Name property.
            // Select processes each group individually.
            // SelectMany flattens all Authors from books in the group into a single sequence.
            // Distinct removes duplicate authors from that sequence.
            // ToList converts the sequence of distinct authors into a List.
            // First selects the first book from the group.
            // The first book's Authors property is updated with the merged list.
            // The modified first book is returned for each group.
            // ToList collects all modified first books into a final list.
            var groupedBooks = GetBooks().GroupBy(b => b.Name).Select(g => { 
                var mergedAuthors = g.SelectMany(x => x.Authors).Distinct().ToList(); 
                var firstBook = g.First(); firstBook.Authors = mergedAuthors; 
                return firstBook; 
            }).ToList();


            foreach (var book in groupedBooks)
            {
                Console.WriteLine();
                Console.WriteLine(JsonSerializer.Serialize(book));
            }
        }

        static List<Book> GetBooks()
        {
            var query = "SELECT B.Id, B.Name, C.Id AS CategoryId, C.Name AS Category, BD.ISBN, BD.PublicationDate, A.Id AS AuthorId, A.FirstName, A.LastName" +
                " FROM BookAuthors AS BA" +
                " INNER JOIN Books AS B ON B.Id = BA.BookId" +
                " INNER JOIN Categories AS C ON C.Id = B.CategoryId" +
                " INNER JOIN BookDetails BD ON BD.BookId = B.Id" +
                " INNER JOIN Authors AS A ON A.Id = BA.AuthorId";

            using var connection = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(query, connection);
            connection.Open();
            var dr = cmd.ExecuteReader();

            if (!dr.HasRows)
            {
                throw new Exception("No records found!");
            }

            var books = new List<Book>();
            var booksDict = new Dictionary<int, Book>();

            while (dr.Read())
            {
                var book = new Book()
                {
                    Id = dr.GetInt32("Id"),
                    Name = dr.GetString("Name"),
                    Category = new Category() { Id = dr.GetInt32("CategoryId"), Name = dr.GetString("Category") },
                    ISBN = dr.GetString("ISBN"),
                    PublicationDate = dr.GetDateTime("PublicationDate"),
                    Authors = [new Author() {
                        Id = dr.GetInt32("AuthorId"),
                        FirstName = dr.GetString("FirstName"),
                        LastName = dr.GetString("LastName") }
                    ]
                };
                if(!booksDict.TryAdd(book.Id, book))
                {
                    booksDict[book.Id].Authors.Add(book.Authors.First());
                }
                books.Add(book);
            }

            return books;
        }
    }
}
