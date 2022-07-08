using AuthorProject.DataClasses;
using AuthorProject.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthorProject.View
{
    public partial class AuthorDetails : Form
    {
        public delegate void AuthorEvent();
        public AuthorEvent AuthorReLoadEvent;

        public delegate void BookCloseEvent();
        public BookCloseEvent CloseEvent;


        public AuthorViewModel authorViewModel { get; set; }
        //public BookViewModel bookViewModel { get; set; }
        //public BookViewModel BVM { get; set; }
        public AuthorDetails(int? id)
        {
            InitializeComponent();
            authorViewModel = new AuthorViewModel();
           // bookViewModel = new BookViewModel();
           // BVM = new BookViewModel();
            DoBinding();
            DoBindingBook();
            dataGridView.AutoGenerateColumns = false; 
        }
       
        private void DoBindingBook()
        {
            var a = authorViewModel.GetViewModelBookList(authorViewModel.AuthId);    ///////////////
            dataGridView.DataSource = a;

        }

        public AuthorDetails(int id)
        {
            InitializeComponent();
            authorViewModel = new AuthorViewModel();
            authorViewModel.GetIdViewModel(id); 
            DoBinding();
            DoBindingBook();
        }

        private void DoBinding()
        {
           dataGridView.AutoGenerateColumns = false;

            textBoxName.DataBindings.Add("Text", authorViewModel, nameof(authorViewModel.AName));
            textBoxPlace.DataBindings.Add("Text", authorViewModel, nameof(authorViewModel.APlace));
            textBoxEmail.DataBindings.Add("Text", authorViewModel, nameof(authorViewModel.AEmail));
            dateTimePickerDate.DataBindings.Add("Text", authorViewModel, nameof(authorViewModel.ADate));
            dataGridView.DataSource = authorViewModel.ABooks;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BookDetails bd = new BookDetails(Convert.ToInt32(dataGridView.CurrentRow.Cells["BookId"].Value));
            bd.BookEvents += ReLoad;
            bd.Show();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            authorViewModel.ViewModelAddBookOpeartion();
            MessageBox.Show("Record Saved Sucessfully");
            string validObject = Validation();
            MessageBox.Show(validObject);
                       
            var aa = authorViewModel.ViewModelAddOp();
            if(aa.Error != null)
            {
                MessageBox.Show(aa.Error);
                return;
            }
            //Add(new Author() { Name = AVM.AName, Place= AVM.APlace, Email = AVM.AEmail});
            
            MessageBox.Show("Record Saved Successfully");
            Clear();
            AuthorReLoadEvent?.Invoke();
            //}            
        }

      
        public string Validation()
        {
            StringBuilder sb = new StringBuilder();

            if ( string.IsNullOrEmpty(textBoxName.Text))
            {
                sb.Append("Name cannot be Duplicate or Empty");
                
            }
            else if ( string.IsNullOrEmpty(textBoxEmail.Text))
            {
                sb.Append("Email cannot be Duplicate or Empty");
                
            }
            return sb.ToString();
           
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //AuthorDetails authorDetails = new AuthorDetails(Convert.ToInt32(dataGridView1.CurrentRow.Cells["AuthorID"].Value));
            //authorDetails.BookReloadEvent += Bookreload;
            //authorDetails.Show();
            //AuthorDetails authorDetails = new AuthorDetails(Convert.ToInt32(AVM.AuthId));
            //int value = Convert.ToInt32(authorDetails);
            authorViewModel.ViewModelDeleteOp(authorViewModel.AuthId);
            AuthorReLoadEvent?.Invoke();
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            BookDetails bookDetails = new BookDetails(authorViewModel.AuthId);
            bookDetails.BookEvent1 += ReLoad;
            bookDetails.bookViewModel.BMObject.author= authorViewModel.authorModel.Auth;  //Foreign Key  AuthorId to  AuthorId in Book
            bookDetails.SelectedAuthor = authorViewModel.authorModel.Auth;
            bookDetails.Show();

            //BookDetails bookDetails1 = new BookDetails(AVM.AuthId);
            //bookDetails.BookEvents += ReLoad;
            //bookDetails.Show();

            //AuthorDetails authorDetails2 = new AuthorDetails(null); ;
            //authorDetails2.BookReloadEvent1 += ReLoad;
        }

        private void ReLoad()
        {
            DoBindingBook();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //var delete = Convert.ToInt32(dataGridView.CurrentRow.Cells["AuthorID"].Value);
            //AVM.ViewModelDeleteOp(delete);

            var delete = Convert.ToInt32(dataGridView.CurrentRow.Cells["BookId"].Value);
            authorViewModel.ModelBookDeleteOperation(delete);  /////////////
            DoBindingBook();

        }
        public void GetID(int id)
        {
            //BVM.GetBookViewModelID(id);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            AuthorReLoadEvent?.Invoke();
            this.Close();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BookDetails ad = new BookDetails(Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value));
            ad.BookEvents += ReLoad;
            ad.Show();
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Update();

        }
        public void Update()
        {
            authorViewModel.GetUpdateViewModel();
            MessageBox.Show("Record Updated Successfully");
            AuthorReLoadEvent?.Invoke();
        }
        public void Clear()
        {
            textBoxName.Text = "";
            textBoxPlace.Text = "";
            textBoxEmail.Text = "";
        }
    }
}
  