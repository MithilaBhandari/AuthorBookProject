using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.DataClasses
{
   public partial class Author
    {
        [NotMapped]
        public int CountBooks => Books?.Count??0;

     }
}
