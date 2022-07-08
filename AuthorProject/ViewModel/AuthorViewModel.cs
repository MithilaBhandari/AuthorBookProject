using AuthorProject.DataClasses;
using AuthorProject.DTO;
using AuthorProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.ViewModel
{
   public class AuthorViewModel :Abstract_Class.AbstractClassNotify
    {
        public AuthorModel authorModel { get; set; }

        //public BookModel BM { get; set; }
        //  public Author Auth { get; set; }

        public AuthorViewModel()
        {
            authorModel = new AuthorModel();
            //BM = new BookModel();
            //Auth = new Author();
        }

        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        //public event PropertyChangedEventHandler PropertyChanged;

        public void GetIdViewModel(int id)
        {
             authorModel.GetIdModel(id);
        }
        public List<Author> GetViewModelList()
        {
            return authorModel.GetAuthorModelList();
        }
        public AuthorData ViewModelAddOp()
        {
            return authorModel.GetAuthorModelAdd(authorModel.Auth);
        }
        public void ViewModelDeleteOp(int id)
        {
            authorModel.GetAuthorModelDelete(id);
        }
        public Author GetUpdateViewModel()
        {
           return authorModel.GetUpdateModel(authorModel.Auth);
        }

        // Book Model

        //public Book ViewModelAddOpeartion()
        //{
        //    return BM.ModelBookAddOperation(BM.BooKObject);
        //}

        //public void ViewModelDeleteOpeartion(int id)
        //{
        //    BM.ModelBookDeleteOperation(id);
        //}

        //public List<Book> GetBookViewModelList(int? id)
        //{
        //    return authorModel.GetBookModelList(id);
        //}

        public string AName
        {
            get
            {   
                return authorModel.Auth.Name;
            }
 

            set
            {
                authorModel.Auth.Name = value;
                NotifyPropertyChanged();
            }
        }
        public string APlace
        {
            get
            {
                return authorModel.Auth.Place;
            }
            set
            {
                authorModel.Auth.Place = value;
                NotifyPropertyChanged();
            }
        }
        public DateTime ADate
        {
            get
            {
                return authorModel.Auth.DOB;
            }
            set
            {
                authorModel.Auth.DOB = value;
                NotifyPropertyChanged();
            }
        }
        public string AEmail
        {
            get
            {
                 return authorModel.Auth.Email;
            }
            set
            {
                authorModel.Auth.Email = value;
                NotifyPropertyChanged();
            }
        }
        public int AuthId
        {
            get
            {
                return authorModel.Auth.AuthorID;
            }
            set
            {
                authorModel.Auth.AuthorID = value;
                NotifyPropertyChanged();
            }
        }
        public List<Book> ABooks
        {
            get
            {
                return authorModel.Auth.Books;
            }
            set
            {
                authorModel.Auth.Books = value;
                NotifyPropertyChanged();
            }
        }
        public int BookCount
        {
            get
            {
                return authorModel.Auth.CountBooks;
            }
        }
        public List<Book> GetViewModelBookList(int? id)
        {

            return authorModel.GetBookModelList(id);
        }
        public void ModelBookDeleteOperation(int id)
        {
            authorModel.ModelBookDeleteOperation(id);
        }
        public Book ViewModelAddBookOpeartion()
        {
            return authorModel.ModelAddBookOpeartion(authorModel.Book);
        }
    }
}
