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
    public partial class AuthorList1 : Form
    {
        public AuthorViewModel AVM { get; set; }
       
        public AuthorList1()
        {
            InitializeComponent();
            AVM = new AuthorViewModel();
            DoBinding();
        }

        private void DoBinding()
        { 
            dataGridView1.DataSource= AVM.GetViewModelList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AuthorDetails authorDetails = new AuthorDetails(null);
            authorDetails.AuthorReLoadEvent += Bookreload;
            authorDetails.Show();
        }

        private void Bookreload()
        {
            DoBinding();
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    AuthorDetails authorDetails = new AuthorDetails(Convert.ToInt32(dataGridView1.CurrentRow.Cells["AuthorID"].Value));
        //    authorDetails.Show();
        //}

        private void buttonDelete_Click(object sender, EventArgs e)
        {
                var delete = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AuthorID"].Value);
                AVM.ViewModelDeleteOp(delete);
                DoBinding();
            
            //var delete = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AuthorID"].Value);
            //AVM.ViewModelDeleteOp(delete);
            //DoBinding();
            
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            AuthorDetails authorDetails = new AuthorDetails(Convert.ToInt32(dataGridView1.CurrentRow.Cells["AuthorID"].Value));
            authorDetails.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AuthorDetails authorDetails = new AuthorDetails(Convert.ToInt32(dataGridView1.CurrentRow.Cells["AuthorID"].Value));
            authorDetails.AuthorReLoadEvent += Bookreload;
            authorDetails.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        //    AuthorDetails authorDetails = new AuthorDetails(Convert.ToInt32(dataGridView1.CurrentRow.Cells["AuthorID"].Value));
        //    authorDetails.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
