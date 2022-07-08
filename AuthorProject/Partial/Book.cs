using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.DataClasses
{
    public partial class Book
    {
        [NotMapped]
        public string AuthorName => Author?.Name;
        //public string BookID =>  Book
       
    }

}
