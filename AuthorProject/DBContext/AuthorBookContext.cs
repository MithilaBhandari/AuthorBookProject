using AuthorProject.DataClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject
{
   public  class AuthorBookContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public AuthorBookContext() : base("AuthorBookContext")
        {
            Database.SetInitializer<AuthorBookContext>(new DropCreateDatabaseIfModelChanges<AuthorBookContext>());
        }
    }
}
