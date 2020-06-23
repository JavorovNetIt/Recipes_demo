using Recipes.Data.Models;
using Recipes.Data.Services;
using Recipes.Data.Services.Contracts;
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
    public partial class RecipesListForm : Form
    {
        public BindingSource recipeBindingSource = new BindingSource();
        private AuthorFileService authorService = new AuthorFileService();
        private RecipeFileService recipeFileService = new RecipeFileService();
        public RecipesListForm()
        {
            InitializeComponent();

            InitilizeRecipesColumns();

            recipeBindingSource.DataSource = new List<Recipe>();
            gvRecipes.DataSource = recipeBindingSource;
        }

        public RecipesListForm(List<Recipe> recipes)
        {
            InitializeComponent();

            InitilizeRecipesColumns();

            recipeBindingSource.DataSource = recipes;
            gvRecipes.DataSource = recipeBindingSource;
        }

        private void InitilizeRecipesColumns()
        {
            gvRecipes.AutoGenerateColumns = false;

            DataGridViewColumn col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "Име";
            col.DataPropertyName = "Name";
            col.ReadOnly = true;
            gvRecipes.Columns.Add(col);

            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "Съдържание";
            col.DataPropertyName = "Content";
            col.ReadOnly = true;
            gvRecipes.Columns.Add(col);

            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "Автор";
            col.DataPropertyName = "AuthorName";
            col.ReadOnly = true;
            gvRecipes.Columns.Add(col);
        }

        private void btnSaveRecipe_Click(object sender, EventArgs e)
        {
            Recipe recipe = new Recipe();

            if (recipeFileService.CheckNameUniqness(tbName.Text))
            {
                MessageBox.Show("Вече съществува рецепта с това име");
                RefreshUIState();

                return;
            }

            recipe.Name = tbName.Text;
            recipe.Content = tbContent.Text;
            Author author = authorService.GetModelByName(tbAuthor.Text);

            if (author == null)
            {
                MessageBox.Show("Няма такъв автор моля опитайте отново");
                RefreshUIState();

                return;
            }
            recipe.Author = author;

            recipeFileService.Save(recipe);

            RefreshUIState();


        }

        private void RefreshUIState()
        {
            tbName.Text = string.Empty;
            tbContent.Text = string.Empty;
            tbAuthor.Text = string.Empty;

            List<Recipe> recipes = recipeFileService.GetAllModels();

            foreach (var recipe in recipes)
            {
                recipe.Author = authorService.GetModelByID(recipe.AuthorID);
            }

            recipeBindingSource.DataSource = recipes;
            recipeBindingSource.ResetBindings(false);


        }
    }
}
