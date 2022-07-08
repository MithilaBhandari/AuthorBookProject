using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.DataClasses
{
    public partial class Author
    {
        [Key]
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public List<Book> Books { get; set; }
    }
}
