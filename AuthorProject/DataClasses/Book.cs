using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.DataClasses
{
    public partial class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateTime DateOfPublish { get; set; }
        public string Language { get; set; }
        public double version { get; set; }
        //[ForeignKey("AuthId")]
        //public int AuthId { get; set; }
        //[ForeignKey("Author")]
        public Author Author { get; set; }
        
    }
}
