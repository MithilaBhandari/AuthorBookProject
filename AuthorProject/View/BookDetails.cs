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
    public partial class BookDetails : Form
    {
        public delegate void BookCloseEvent();
        public BookCloseEvent BookEvent1;

        public delegate void BookEvent();
        public BookEvent BookEvents;

        private int authorId = 0;

        
        public BookViewModel bookViewModel { get; set; }
        public Author SelectedAuthor { get; set; }
        public BookDetails(int id)  
            //pass Author Id
        {
            InitializeComponent();
            bookViewModel = new BookViewModel();
            authorId = id;
            DoBinding();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(textBox1.Text))
            //{
            //    MessageBox.Show("Enter the BookName");
            //    return;
            //}
            //else if(string.IsNullOrEmpty(textBox3.Text))
            //{
            //    MessageBox.Show("Enter Book Language");
            //    return;
            //}
            string validation = bookViewModel.BookValidation();
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show(validation);
                return;
            }
            else if(string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show(validation);
                return;
            }
            else
            {
                Add();
                MessageBox.Show("Record Saved Sucessfully");
               Clear();
                BookEvent1?.Invoke();
            }

        }
        public void Clear()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        //public void Count()
        //{
        //    bookViewModel.BookCount = 0;
        //    bookViewModel.BookCount += 1;
        //}


        private void Bookreload()
        {
            DoBinding();

        }

        private void BookreLoad()
        {
          
            DoBinding();
        }

        private void DoBinding()
        {
            // BVM.GetBookViewModelList();
            textBox1.DataBindings.Add("Text", bookViewModel, nameof(bookViewModel.NameBook));
            dateTimePicker1.DataBindings.Add("Text", bookViewModel, nameof(bookViewModel.PublishDate));
            textBox3.DataBindings.Add("Text", bookViewModel, nameof(bookViewModel.BookLanguage));
            textBox4.DataBindings.Add("Text", bookViewModel, nameof(bookViewModel.BookVersion));
        }

        public void Add()
        {
            bookViewModel.BookAuthorId = authorId;
            var bb = bookViewModel.ViewModelAddOpeartion(SelectedAuthor);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            bookViewModel.ViewModelDeleteOpeartion(bookViewModel.ID);
            BookEvent1?.Invoke();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
