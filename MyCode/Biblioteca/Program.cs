using Biblioteca.Classes;
using Biblioteca.Interfaces;
using System;
using System.Collections.Generic;

namespace Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library<ILibraryItems> library = new Library<ILibraryItems>();
            //Library<OnlineBook> onlineLibrary = new Library<OnlineBook>();

            // Mock Book instances
            var mockBooks = new List<ILibraryItems>
            {
                new Book
                {
                    ISBN = 1001,
                    Name = "The Art of C#",
                    Description = "A comprehensive guide to C# programming.",
                    Available = true,
                    PublishDate = new DateTime(2022, 1, 15)
                },
                new Book
                {
                    ISBN = 1002,
                    Name = "Mastering .NET",
                    Description = "Deep dive into .NET 9 features.",
                    Available = false,
                    PublishDate = new DateTime(2023, 5, 10)
                },
                new Book
                {
                    ISBN = 1003,
                    Name = "Programming Patterns",
                    Description = "Essential design patterns for modern development.",
                    Available = true,
                    PublishDate = new DateTime(2021, 9, 5)
                },
                new Book
                {
                    ISBN = 1004,
                    Name = "Data Structures Explained",
                    Description = "Understanding data structures in C#.",
                    Available = true,
                    PublishDate = new DateTime(2020, 11, 20)
                },
                new Book
                {
                    ISBN = 1005,
                    Name = "Async Programming",
                    Description = "Concurrency and async programming in .NET.",
                    Available = true,
                    PublishDate = new DateTime(2024, 3, 8)
                },
                new Book
                {
                    ISBN = 1006,
                    Name = "Async Programming",
                    Description = "Concurrency and async programming in .NET V2.",
                    Available = true,
                    PublishDate = new DateTime(2024, 3, 8)
                },
                new OnlineBook
                {
                    ISBN = 2001,
                    Name = "C# in the Cloud",
                    Description = "A guide to cloud-based C# development.",
                    Available = true,
                    PublishDate = new DateTime(2023, 2, 12),
                    FileSizeMB = 5.2,
                    FileFormat = "PDF",
                    DownloadURL = "https://example.com/csharp-cloud.pdf"
                },
                new OnlineBook
                {
                    ISBN = 2002,
                    Name = "Modern .NET Web Apps",
                    Description = "Building web applications with .NET 9.",
                    Available = false,
                    PublishDate = new DateTime(2024, 6, 1),
                    FileSizeMB = 7.8,
                    FileFormat = "EPUB",
                    DownloadURL = "https://example.com/dotnet-web.epub"
                },
                new OnlineBook
                {
                    ISBN = 2003,
                    Name = "LINQ Unleashed",
                    Description = "Advanced LINQ techniques and patterns.",
                    Available = true,
                    PublishDate = new DateTime(2022, 10, 18),
                    FileSizeMB = 3.6,
                    FileFormat = "MOBI",
                    DownloadURL = "https://example.com/linq-unleashed.mobi"
                }
            };



            foreach (var book in mockBooks)
            {
                library.AddBook(book);
            }



            //try
            //{
            //    List<Book> books = library.BorrowBooks("Async Programming");
            //    books.ListPrinter();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //try
            //{
            //    List<OnlineBook> onlineBooks = onlineLibrary.BorrowBooks("LINQ Unleashed");
            //    onlineBooks.ListPrinter();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            Console.WriteLine("List of books");
            library.PrintAllBooks();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();

            
            bool exit = false;

            do
            {
                Console.WriteLine("Would you like to search a book or lend a book?");
                Console.WriteLine("1. Search");
                Console.WriteLine("2. Lend");
                Console.WriteLine("3. Exit");
                var choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Enter book name:");
                    var bookName = Console.ReadLine();
                    Console.WriteLine("Enter book ISBN (or press Enter to skip):");
                    var isbnInput = Console.ReadLine();
                    int.TryParse(isbnInput, out int bookId);
                    var foundBooks = library.SearchBooks(bookName, bookId);
                    if (foundBooks.Count > 0)
                    {
                        Console.WriteLine("Found Books:");
                        foundBooks.ListPrinter();
                    }
                    else
                    {
                        Console.WriteLine("No books found with the given criteria.");
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Enter book name to lend:");
                    var bookName = Console.ReadLine();
                    Console.WriteLine("Enter book ISBN (or press Enter to skip):");
                    var isbnInput = Console.ReadLine();
                    int.TryParse(isbnInput, out int bookId);
                    try
                    {
                        var lentBooks = library.BorrowBooks(bookName, bookId);
                        Console.WriteLine("Lent Books:");
                        lentBooks.ListPrinter();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choice == "3")
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please restart the application and choose either 1,2 or 3.");
                }
            } while(!exit);
        }
    }
}
