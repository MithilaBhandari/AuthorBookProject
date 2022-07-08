using AuthorProject.DataClasses;
using AuthorProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.ViewModel
{
   public class BookViewModel : Abstract_Class.AbstractClassNotify
    {
        public BookModel BMObject { get; set; }
        //public Book BookObject { get; set; }

        public BookViewModel()
        {
            BMObject = new BookModel();
           // BookObject = new Book();
        }

        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        //public event PropertyChangedEventHandler PropertyChanged;

        public void GetBookViewModelID(int id)
        {
            BMObject.GetBookModelId(id);
        }

        public List<Book> GetBookViewModelList(int? id)
        {
            return BMObject.GetModelBookList(id);
        }

        public Book ViewModelAddOpeartion(Author author)             //to get the ID of Author
        {
            BMObject.BooKObject.Author = author;
            return BMObject.ModelBookAddOperation(BMObject.BooKObject);
        }

        public void ViewModelDeleteOpeartion(int id)
        {
            BMObject.ModelBookDeleteOperation(id);
        }
        public int ID  //////////////////
        {
            get
            {
                return BMObject.BooKObject.BookId;
            }
        }

        public string NameBook
        {
            get
            {
                return BMObject.BooKObject.BookName;
            }
            set
            {
                BMObject.BooKObject.BookName = value;
                NotifyPropertyChanged();
            }
        }
        public DateTime PublishDate
        {
            get
            {
                return BMObject.BooKObject.DateOfPublish;
            }
            set
            {
                BMObject.BooKObject.DateOfPublish = value;
                NotifyPropertyChanged();
            }
        }
      
        public string BookLanguage
        {
            
            get
            {
                
                return BMObject.BooKObject.Language;
            }
            set
            {
                BMObject.BooKObject.Language = value;
                NotifyPropertyChanged();
            }
        }
        public double BookVersion
        {
            get
            {
                return BMObject.BooKObject.version;
            }
            set
            {
                BMObject.BooKObject.version = value;
                NotifyPropertyChanged();
            }
        }

        public int BookAuthorId
        {
            get
            {
                return BMObject.BooKObject.BookId;
            }
            set
            {
                BMObject.BooKObject.BookId = value;
            }
        }

        public string BookValidation()
        {
            StringBuilder sb = new StringBuilder();
            if(string.IsNullOrEmpty(NameBook))
            {
                sb.Append("BookName Cannot be Empty");
            }
            else if(string.IsNullOrEmpty(BookLanguage))
            {
                sb.Append("BookLanguage cannot be Empty");
            }
            return sb.ToString();
        }


        //public int BookCount
        //{
        //    get
        //    {
        //        return BMObject.BooKObject.CountBooks;
        //    }
        //    set
        //    {
        //        BMObject.BooKObject.CountBooks = value;
        //    }
        //}

    }
}
