using Recipes.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipes_Demo
{
    public partial class AuthorsListForm : Form
    {
        public BindingSource authorBindingSource = new BindingSource();
        public AuthorsListForm()
        {
            InitializeComponent();

            InitilizeAuthorsColumns();
        }

        public AuthorsListForm(List<Author> authors)
        {
            InitializeComponent();

            InitilizeAuthorsColumns();

            authorBindingSource.DataSource = authors;

            gvAuthors.DataSource = authorBindingSource;
        }

        private void InitilizeAuthorsColumns()
        {
            gvAuthors.AutoGenerateColumns = false;

            DataGridViewColumn col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "Име";
            col.DataPropertyName = "Name";
            col.ReadOnly = true;
            gvAuthors.Columns.Add(col);

            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "Дата на създаване";
            col.DataPropertyName = "DateCreated";
            col.ReadOnly = true;
            gvAuthors.Columns.Add(col);


        }
    }
}
