using AuthorProject.DataClasses;
using AuthorProject.Repositiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.Models
{
   public class BookModel:BookRepositiory
    {
        public BookRepositiory BookRepo { get; set; }

        public Book BooKObject { get; set; }
        public Author author { get; set; }
        public BookModel()
        {
            BookRepo = new BookRepositiory();
            BooKObject = new Book();
            BooKObject.DateOfPublish = new DateTime(1900, 01, 01);
            BooKObject.Author = author;
        }

        public void GetBookModelId(int id)
        {
            BooKObject = BookRepo.GetBookId(id);
        }
        public List<Book> GetModelBookList(int? id)
        {

            return BookRepo.GetBookList(id);
        }

        public Book ModelBookAddOperation(Book b)
        {
            return BookRepo.AddBookOpeartion(b);
        }
        public void ModelBookDeleteOperation(int id)
        {
            BookRepo.DeleteBookOperation(id);
        }
    }
}
