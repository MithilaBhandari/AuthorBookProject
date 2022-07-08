using AuthorProject.DataClasses;
using AuthorProject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.Repositiory
{
    public class AuthorRepositiory : AuthorBookContext
    {
        public AuthorBookContext RepoAuthor { get; set; }
        List<Author> list = new List<Author>();

        public AuthorRepositiory()
        {
            RepoAuthor = new AuthorBookContext();
        }
        public Author GetAuthorId(int id)
        {
            list = GetAuthorList();
            var a = list.Where(i => i.AuthorID == id).Select(m => m).FirstOrDefault();
            return a;
        }

        public List<Author> GetAuthorList()
          {
            RepoAuthor = new AuthorBookContext();
            var a = RepoAuthor.Authors.Include("Books").ToList();
            // return RepoAuthor.Authors.Include("Book").ToList();
            return a;
        }

        public AuthorData AddOperration(Author auth)
        {
            AuthorData authorData = new AuthorData();
            authorData.Error = RemoveDuplicate(auth);
        
            if (RepoAuthor.Authors.ToList().Exists(i => i.AuthorID == auth.AuthorID))
            {
                authorData.author = RepoAuthor.Authors.FirstOrDefault(i => i.AuthorID == auth.AuthorID);
                
            }
            else
            {
                authorData.author = RepoAuthor.Authors.Add(auth);
            }

            RepoAuthor.SaveChanges();

            return authorData;
        }

        public string RemoveDuplicate(Author author)
        {
            if (RepoAuthor.Authors.ToList().Exists(i => i.Name == author.Name && i.Email == author.Email))
            {
                return "Should not have same Values";
            }

            return string.Empty;
        }    

        public Author UpdateOperation(Author author)
        {
            var aa = RepoAuthor.Authors.FirstOrDefault(i => i.AuthorID == author.AuthorID);
            aa.Name = author.Name;
            aa.Place = author.Place;
            aa.Email = author.Email;
            aa.DOB= author.DOB;
            RepoAuthor.SaveChanges();
            return aa;
        }
        public void DeleteOperation(int id)
        {
            var delete = RepoAuthor.Authors.Where(i => i.AuthorID == id).FirstOrDefault();
            RepoAuthor.Authors.Remove(delete);
            RepoAuthor.SaveChanges();
        }

        //public void UpdateOperation(int id)
        //{
        //    Author ai ;           
        //}
    }
}
