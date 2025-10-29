using Biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Classes
{
    internal class Library<T> where T : ILibraryItems
    {
        List<T> books;
        public Library()
        {
            books = new List<T>();
        }
        public void AddBook(T book)
        {
            books.Add(book);
            //Console.WriteLine($"{book.Name} is added to the library");
        }

        public List<T> SearchBooks(string bookName, int bookId = 0)
        {
            return bookId != 0 ? books.Where(b => b.Name == bookName && b.ISBN == bookId).ToList() : books.Where(b => b.Name == bookName).ToList();
        }

        public List<T> BorrowBooks(string bookName, int bookId = 0) {
            List<T> foundBooks = SearchBooks(bookName, bookId);
            if(foundBooks.Count <= 0)
            {
                throw new BookException($"{nameof(T)} not found");
            }
            if(foundBooks.All(b => !b.Available))
            {
                throw new BookException($"{nameof(T)} not found");
            }
            List<T> booksToReturn = foundBooks.Where(b => b.Available).ToList();
            booksToReturn.ForEach(b => b.Available = false);
            return booksToReturn;
        }

        public void PrintAllBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Name} - Available: {book.Available}");
            }
        }
    }
}
