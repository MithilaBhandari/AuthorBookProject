using AuthorProject.DataClasses;
using AuthorProject.DTO;
using AuthorProject.Repositiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.Models
{
    public class AuthorModel: AuthorRepositiory
    {
        public AuthorRepositiory RepoObject { get; set; }
        public BookRepositiory BookRep { get; set; }
        public Author Auth { get; set; }

        public Book Book { get; set; }

        public AuthorModel()
        {
            RepoObject = new AuthorRepositiory();
            BookRep = new BookRepositiory();
            Auth = new Author();
            Auth.DOB = new DateTime(1900, 01, 01);
        }
        public void GetIdModel(int id)
        {
          Auth= RepoObject.GetAuthorId(id);
        }

        public List<Author> GetAuthorModelList()
        {
            return RepoObject.GetAuthorList();
        }
        public List<Book> GetBookModelList(int? id)
        {
            return BookRep.GetBookList(id);
        }
        public AuthorData GetAuthorModelAdd(Author a)
        {
            return RepoObject.AddOperration(a);
        }
        public void GetAuthorModelDelete(int id)
        {
            RepoObject.DeleteOperation(id);
        }
        public Author GetUpdateModel(Author id)
        {
           return RepoObject.UpdateOperation(id);
        }

        public List<Book> GetModelBookList(int? id)
        {

            return BookRep.GetBookList(id);
        }
        public void ModelBookDeleteOperation(int id)
        {
            BookRep.DeleteBookOperation(id);
        }
        public Book ModelAddBookOpeartion(Book book)
        {
           return BookRep.AddBookOpeartion(book);
        }

    }
}
