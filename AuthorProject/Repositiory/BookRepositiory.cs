using AuthorProject.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.Repositiory
{
   public class BookRepositiory:AuthorBookContext
    {
        public AuthorBookContext RepObjBook { get; set; }
        List<Book> bookList = new List<Book>();

        public BookRepositiory()
        {
            RepObjBook = new AuthorBookContext();
        }

        public Book GetBookId(int id)
        {
            return Books.Where(i => i.BookId == id).Select(m => m).FirstOrDefault();
            
        }
        public List<Book> GetBookList(int? id)
        {
            if(!id.HasValue)
            {
                return new List<Book>();
            }
            RepObjBook = new AuthorBookContext();
            var boolList =  RepObjBook.Books.Where(i=> i.Author.AuthorID == id.Value).ToList();
            var author = RepObjBook.Authors.Where(i => i.AuthorID == id.Value).FirstOrDefault();
            if(author != null)
            foreach (var item in boolList)
            {
                    item.Author = author;
            }
            return boolList;
        }

        public Book AddBookOpeartion(Book book)
        {
            Book b = null;
  
            b = RepObjBook.Books.Add(book);
           
            RepObjBook.SaveChanges();
            return b;
        }

        public void DeleteBookOperation(int id)
        {
            var delete = RepObjBook.Books.Where(i => i.BookId == id).FirstOrDefault();
            RepObjBook.Books.Remove(delete);
            RepObjBook.SaveChanges();            
        }
    }
}
